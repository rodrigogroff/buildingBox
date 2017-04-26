using LinqToDB;
using System;

namespace DataModel
{
	public partial class UserContract
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			fkUser = user.id;
			dtCreation = DateTime.Now;
			stProtocol = GetProtocol();
			fkContractState = EnumContractState.PendingFirstPayment;

			id = Convert.ToInt64(db.InsertWithIdentity(this));

			db.Insert(new UserContractState
			{
				dtLog = DateTime.Now,
				fkContract = this.id,
				fkContractState = EnumContractState.ContractCreated,
				fkUser = user.id,
			});

			db.Insert(new UserContractState
			{
				dtLog = DateTime.Now,
				fkContract = this.id,
				fkContractState = EnumContractState.PendingFirstPayment,
				fkUser = user.id,
			});

			var bill_id = Convert.ToInt64( db.InsertWithIdentity(new UserContractBill
				{
					fkUser = user.id,
					fkUserContract = this.id,
					bCancelled = false,
					bPending = true,
					dtLog = DateTime.Now,
					nuMonth = DateTime.Now.Month,
					nuYear = DateTime.Now.Year,
					stBillId = GetBillId(),
				}));

			InsertContractDetails(db, bill_id, (long)fkContractType);

			return true;
		}
	}
}
