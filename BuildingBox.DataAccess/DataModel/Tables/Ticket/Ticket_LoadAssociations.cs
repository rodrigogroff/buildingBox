
namespace DataModel
{
	public partial class Ticket
	{
		public Ticket LoadAssociations(BuildingBoxDB db)
		{
			sfkState = new EnumTicketState().Get((long)fkTicketState).stName;
			sdtCreation = GetDateTimeString(dtCreation);
			sdtLog = GetDateTimeString(dtLog);

			return this;
		}
	}
}
