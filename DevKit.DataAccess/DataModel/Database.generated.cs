//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModel
{
	/// <summary>
	/// Database       : BuildingBox
	/// Data Source    : localhost
	/// Server Version : 9.6.1
	/// </summary>
	public partial class BuildingBoxDB : LinqToDB.Data.DataConnection
	{
		public ITable<User> Users { get { return this.GetTable<User>(); } }

		public BuildingBoxDB()
		{
			InitDataContext();
		}

		public BuildingBoxDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}

	[Table(Schema="public", Name="User")]
	public partial class User
	{
		[PrimaryKey, Identity] public long   id             { get; set; } // bigint
		[Column,     Nullable] public string stClientName   { get; set; } // character varying(99)
		[Column,     Nullable] public long?  fkClientType   { get; set; } // bigint
		[Column,     Nullable] public long?  fkCountry      { get; set; } // bigint
		[Column,     Nullable] public long?  stCityName     { get; set; } // bigint
		[Column,     Nullable] public long?  fkDesiredGMT   { get; set; } // bigint
		[Column,     Nullable] public string stPassword     { get; set; } // character varying(99)
		[Column,     Nullable] public string stContactEmail { get; set; } // character varying(200)
	}

	public static partial class TableExtensions
	{
		public static User Find(this ITable<User> table, long id)
		{
			return table.FirstOrDefault(t =>
				t.id == id);
		}
	}
}
