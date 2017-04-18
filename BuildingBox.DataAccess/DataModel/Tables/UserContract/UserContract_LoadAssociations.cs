using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class UserContract
	{
		public UserContract LoadAssociations(BuildingBoxDB db)
		{
			sdtCreation = GetDateTimeString(dtCreation);
			
			sfkContractState = new EnumContractState().Get((long)fkContractState).stName;
			sfkCity = new EnumInfraCity().Get((long)fkCity).stName;
			sfkCountry = new EnumInfraCountry().Get((long)fkCountry).stName;
			sfkContinent = new EnumInfraContinent().Get((long)fkContinent).stName;

			states = LoadStates(db);

			return this;
		}

		List<UserContractState> LoadStates(BuildingBoxDB db)
		{
			var lst = (from e in db.UserContractStates
					   where e.fkContract == this.id
					   select e).
					   OrderByDescending ( y=> y.id).
					   ToList();

			var ecs = new EnumContractState();

			foreach (var item in lst)
			{
				item.sfkContractState = ecs.Get((long)item.fkContractState).stName;
				item.sfkUser = db.User((long)item.fkUser).stClientName;
				item.sdtLog = GetDateTimeString(item.dtLog);
			}

			return lst;
		}
	}
}
