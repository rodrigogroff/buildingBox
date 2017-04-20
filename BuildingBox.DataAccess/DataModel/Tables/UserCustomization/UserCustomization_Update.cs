using LinqToDB;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataModel
{
	public partial class UserCustomization
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();
			
			switch (updateCommand)
			{
				case "entity":
					{
						var oldCustomization = db.UserCustomization(this.id);

						var oldEstimate = (from e in db.UserCustomizationEstimateLogs
										   where e.fkCustomization == this.id
										   select e).
										   OrderBy(y => y.id).
										   FirstOrDefault();

						var insertEstimate = true;

						if (oldEstimate != null)
							if (oldEstimate.nuHours == this.nuEstimateHours || oldEstimate.nuMinutes == this.nuEstimateMinutes)
								insertEstimate = false;
						
						if (insertEstimate)
						{
							db.Insert(new UserCustomizationEstimateLog
							{
								dtLog = DateTime.Now,
								fkUser = user.id,
								fkCustomization = this.id,
								nuHours = this.nuEstimateHours,
								nuMinutes = this.nuEstimateMinutes,
							});
						}

						if (fkNewCustomizationState != oldCustomization.fkCustomizationState)
						{
							db.Insert(new UserCustomizationStateChange
							{
								dtLog = DateTime.Now,
								fkCustomization = this.id,
								fkState = fkNewCustomizationState,
								fkUser = user.id
							});
						}

						this.fkCustomizationState = fkNewCustomizationState;
						this.dtUpdate = DateTime.Now;

						db.Update(this);

						LoadAssociations(db);

						break;
					}
			}

			return true;
		}
	}
}
