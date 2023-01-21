using CoreAndFood.Models.Common;

namespace CoreAndFood.Models
{
	public class Category : BaseEntity
	{
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public bool Status { get; set; }
		public ICollection<Food>? Foods { get; set; }
	}
}
