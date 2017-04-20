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

						if (this.nuEstimateHours == null)
							this.nuEstimateHours = 0;

						if (this.nuEstimateMinutes == null)
							this.nuEstimateMinutes = 0;

						var insertEstimate = true;

						if (oldEstimate != null)
							if (oldEstimate.nuHours == this.nuEstimateHours || oldEstimate.nuMinutes == this.nuEstimateMinutes)
								insertEstimate = false;
						
						if (insertEstimate)
						{
							if (this.nuEstimateHours > 0 || this.nuEstimateMinutes > 0)
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
						}
						
						if (fkNewCustomizationState > 0)
						{
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
						}

						if (bEstimativeApproval == true)
							if (dtEstimativeApproval == null)
								if (user.fkClientType == UserType.Client)
									dtEstimativeApproval = DateTime.Now;

						if (bFinalApproval == true)
							if (dtFinalApproval == null)
								if (user.fkClientType == UserType.Client)
									dtFinalApproval = DateTime.Now;

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
