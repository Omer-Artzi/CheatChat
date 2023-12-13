using System;
using System.ComponentModel.DataAnnotations;
namespace CheatChat.Models
{
	public class RegisterModel
	{
		[Required (ErrorMessage = "Please enter your id")]
		public Guid id { get; set; }
		[Required (ErrorMessage = "Please enter your username")]
    	public string username { get; set; }
		[Required (ErrorMessage = "Please enter your phone number")]
		public string phone_number { get; set; }
		[Required (ErrorMessage = "Please enter your first name")]
		public string first_name   { get; set; }
		[Required (ErrorMessage = "Please enter your last name")]
		public string last_name    { get; set; }
		[Required (ErrorMessage = "Please enter your email")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		[DataType(DataType.EmailAddress)]
		public string email        { get; set; }
		[Required (ErrorMessage = "Please enter your password")]
		// [DataType(DataType.Password)]
		public string password     { get; set; }

		public RegisterModel(Guid id, string username, string phone_number, string first_name, string last_name, string email, string password)
		{
			this.id = id;
			this.username = username;
			this.phone_number = phone_number;
			this.first_name = first_name;
			this.last_name = last_name;
			this.email = email;
			this.password = password;
		}
	}
}

