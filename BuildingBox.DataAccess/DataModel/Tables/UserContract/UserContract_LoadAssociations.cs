﻿using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserContract
	{
		EnumContractState ecs = new EnumContractState();
		
		public UserContract LoadAssociations(BuildingBoxDB db)
		{
			var user = db.GetCurrentUser();

			sfkUser = db.User(this.fkUser).stContactEmail;
			fkClientType = user.fkClientType;
			snuContractValue = GetMoneyString(nuContractValue);
			sdtCreation = GetDateTimeString(dtCreation);			
			sfkContractState = ecs.Get((long)fkContractState).stName;
			sfkCity = new EnumInfraCity().Get((long)fkCity).stName;
			sfkCountry = new EnumInfraCountry().Get((long)fkCountry).stName;
			sfkContinent = new EnumInfraContinent().Get((long)fkContinent).stName;
			stName = stProtocol + " - " + sfkCity;

			states = LoadStates(db);
			pendingBills = LoadBills(db, true);
			bills = LoadBills(db, false);

			return this;
		}

		List<UserContractState> LoadStates(BuildingBoxDB db)
		{
			var lst = (from e in db.UserContractStates
					   where e.fkContract == this.id
					   select e).
					   OrderByDescending ( y=> y.id).
					   ToList();
			
			foreach (var item in lst)
			{
				item.sfkContractState = ecs.Get((long)item.fkContractState).stName;
				item.sfkUser = db.User((long)item.fkUser).stContactEmail;
				item.sdtLog = GetDateTimeString(item.dtLog);
			}

			return lst;
		}

		List<UserContractBill> LoadBills(BuildingBoxDB db, bool pending)
		{
			var lst = (from e in db.UserContractBills
					   where e.fkUserContract == this.id
					   where pending == false || e.bPending == true
					   where e.bCancelled == false
					   select e).
					   OrderByDescending(y => y.id).
					   ToList();

			EnumMonth em = new EnumMonth();

			foreach (var item in lst)
			{
				item.sdtLog = GetDateTimeString(item.dtLog);
				item.snuMonth = em.Get((long)item.nuMonth).stName;
				item.sdtPayment = GetDateTimeString(item.dtPayment);

				item.details = (from e in db.BillDetails
								where e.fkUserContractBill == item.id
								select e).ToList();

				item.snuValue = GetMoneyString(item.details.Sum(y=>y.nuValue));

				foreach (var detail in item.details)
				{
					detail.snuValue = GetMoneyString(detail.nuValue);
				}
			}

			return lst;
		}
	}
}
