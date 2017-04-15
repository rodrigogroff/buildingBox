using LinqToDB;
using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public partial class User
	{
		public User LoadAssociations(BuildingBoxDB db)
		{
			
			return this;
		}
	}
}
