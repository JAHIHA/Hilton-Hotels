using Hilton_Hotels.Models;
using Hilton_Hotels.Pages.Customer;
using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Hilton_Hotels.Pages.Account
{
    public class Login_inModel : PageModel
    {
        
        [BindProperty]
        public LoginModel Login { get; set; }

        private readonly ICustomerService _serviceCustomer;
        public CustomerModel customerModel { get; set; }
        public Login_inModel(ICustomerService service)
        {
            _serviceCustomer = service; 

        }
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            if(Login.UserName == "Admin" && Login.Password == "Hotel")
            {
                Response.Redirect("/Administration/Administration");
            }
            customerModel = new CustomerModel()
            {
                Username=Login.UserName,
                Password=Login.Password
            };
            var result = _serviceCustomer.Find(customerModel.Username);
            if (result == null)
            {
                Response.Redirect("/Register/Register");
            }
            else
            {
                Response.Redirect("/Index" );  
            }
           
      
    }
    

}

        public class LoginModel
        {
            [Required]
            [Display(Name ="User Name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


       

        }
    
}
