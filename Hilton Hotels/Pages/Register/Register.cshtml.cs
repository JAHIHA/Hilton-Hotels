using Hilton_Hotels.Pages.Account;
using Hilton_Hotels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hilton_Hotels.Pages.Customer
{
    public class RegisterModel : PageModel
    {
        private readonly ICustomerService _customer;


        public RegisterModel(ICustomerService customer)
        {
            _customer = customer;
        }
        [BindProperty]
        public RegisterCostumer registerCostumer { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Response.Redirect("/Login in");
        }

    }
    public class RegisterCostumer
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
