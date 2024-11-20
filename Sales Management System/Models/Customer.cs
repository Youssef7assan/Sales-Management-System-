using System.ComponentModel.DataAnnotations;

namespace Sales_Management_System.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "الاسم الأول مطلوب.")]
		[StringLength(50, ErrorMessage = "الاسم الأول يجب أن يكون أقل من 50 حرفًا.")]
		[Display(Name = "First Name")]
		public string Fname { get; set; }

		[Required(ErrorMessage = "الاسم الأخير مطلوب.")]
		[StringLength(50, ErrorMessage = "الاسم الأخير يجب أن يكون أقل من 50 حرفًا.")]
		[Display(Name = "Last Name")]

		public string Lname { get; set; }

		[StringLength(100, ErrorMessage = "العنوان يجب أن يكون أقل من 100 حرف.")]
		public string? Address { get; set; }

		[Phone(ErrorMessage = "يرجى إدخال رقم هاتف صالح.")]
		[StringLength(15, ErrorMessage = "رقم الهاتف يجب أن يكون أقل من 15 حرفًا.")]
		public string? Phone { get; set; }

		public List<Credit>? Credits { get; set; }
		public List<Order>? Orders { get; set; }
	}
}
