using System.ComponentModel.DataAnnotations;

namespace Sales_Management_System.Models
{
	public class ContactUs
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Full Name is required")]
		[StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[Phone(ErrorMessage = "Invalid Phone Number")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Message is required")]
		[StringLength(500, ErrorMessage = "Message cannot be longer than 500 characters")]
		public string Message { get; set; }
	}
}
