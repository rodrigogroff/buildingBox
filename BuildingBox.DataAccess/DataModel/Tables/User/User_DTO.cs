using System.Collections.Generic;

namespace DataModel
{
	public partial class User
	{
		public object anexedEntity;

		public string updateCommand,
			resetPassword;
	}

	public class UserPasswordChange
	{
		public string stCurrentPassword,
						stNewPassword;
	}
}
