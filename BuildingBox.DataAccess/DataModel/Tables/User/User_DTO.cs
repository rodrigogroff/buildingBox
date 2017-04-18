using System.Collections.Generic;

namespace DataModel
{
	public partial class User
	{
		public object anexedEntity;

		public string updateCommand,
						resetPassword;

		public List<UserContract> contracts = new List<UserContract>();
	}

	public class UserPasswordChange
	{
		public string stCurrentPassword,
						stNewPassword;
	}
}
