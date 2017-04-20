using LinqToDB;
using System;

namespace DataModel
{
	public partial class UserCustomization
	{
		public bool Create(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			fkUser = user.id;
			dtCreation = DateTime.Now;
			dtUpdate = DateTime.Now;
			fkCustomizationState = EnumCustomizationState.Analysis;
			stProtocol = GetProtocol();			

			id = Convert.ToInt64(db.InsertWithIdentity(this));

			db.Insert(new UserCustomizationStateChange
			{
				dtLog = DateTime.Now,
				fkCustomization = this.id,
				fkState = fkCustomizationState,
				fkUser = user.id
			});

			return true;
		}
	}
}
