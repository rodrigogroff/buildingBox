using LinqToDB;
using Newtonsoft.Json;

namespace DataModel
{
	public partial class User
	{
		public bool Update(BuildingBoxDB db, ref string resp)
		{
			var user = db.GetCurrentUser();

			if (CheckDuplicate(this, db))
			{
				resp = "Email already taken ny another account";
				return false;
			}

			switch (updateCommand)
			{
				case "changePassword":
					{
						var ent = JsonConvert.DeserializeObject<UserPasswordChange>(anexedEntity.ToString());

						if (ent.stCurrentPassword.ToUpper() != this.stPassword.ToUpper() )
						{
							resp = "Current password does not match!";
							return false;
						}

						this.stPassword = ent.stNewPassword;

						db.Update(this);
						break;
					}

				case "resetPassword":
					{
						this.stPassword = GetRandomString(8);
						
						db.Update(this);

						resetPassword = this.stPassword;
						break;
					}
			}

			return true;
		}
	}
}
