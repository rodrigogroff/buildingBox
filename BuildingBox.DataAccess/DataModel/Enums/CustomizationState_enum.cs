using System.Linq;
using System.Collections.Generic;

namespace DataModel
{
	public class CustomizationState
	{
		public long id { get; set; }
		public string stName { get; set; }
	}

	public class EnumCustomizationState
	{
		public List<CustomizationState> lst = new List<CustomizationState>();

		public const long Solicited = 1,
							Analysis = 10,
							Estimative = 20,
							EstimativeApproval = 30,
							PendingPayment = 40,
							Execution = 50,
							FinalApproval = 60,
							Delivered = 70;

		public EnumCustomizationState()
		{
			lst.Add(new CustomizationState() { id = Solicited, stName = "Solicited" });
			lst.Add(new CustomizationState() { id = Analysis, stName = "Analysis" });
			lst.Add(new CustomizationState() { id = Estimative, stName = "Estimative" });
			lst.Add(new CustomizationState() { id = EstimativeApproval, stName = "Estimate Approval" });
			lst.Add(new CustomizationState() { id = PendingPayment, stName = "Pending Payment" });
			lst.Add(new CustomizationState() { id = Execution, stName = "Execution" });
			lst.Add(new CustomizationState() { id = FinalApproval, stName = "Final Approval" });
			lst.Add(new CustomizationState() { id = Delivered, stName = "Delivered" });
		}

		public CustomizationState Get(long _id)
		{
			return lst.Where(y => y.id == _id).FirstOrDefault();
		}
	}
}
