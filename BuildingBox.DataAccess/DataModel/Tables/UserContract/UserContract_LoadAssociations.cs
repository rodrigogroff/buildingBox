
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

			return this;
		}
	}
}
