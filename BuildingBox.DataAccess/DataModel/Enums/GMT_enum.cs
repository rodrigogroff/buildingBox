using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class GMT
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumGMT
	{
		public List<GMT> lst = new List<GMT>();

		public EnumGMT()
		{
			int t = 1;
			lst.Add(new GMT() { id = t++, stName = "UTC−-12:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-11:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-10:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-9:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-8:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-7:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-6:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-5:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-4:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-3:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-2:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−-1:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−0:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−1:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−2:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−3:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−4:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−5:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−6:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−7:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−8:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−9:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−10:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−11:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−12:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−12:45" });
			lst.Add(new GMT() { id = t++, stName = "UTC−13:00" });
			lst.Add(new GMT() { id = t++, stName = "UTC−14:00" });
		}

		public GMT Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
