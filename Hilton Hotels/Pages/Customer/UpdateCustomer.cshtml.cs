using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Customer
{
    public class UpdateCustomerModel : PageModel
    {
        public UpdateCustomerModel(ICustomerService services)
        {
            _service = services;
        }
        private ICustomerService _service;

        [BindProperty]
        public CustomerModel UpdateCustomer { get; set; }


        public void OnGet(string name)
        {
            UpdateCustomer = _service.Find(name);
        }
        public IActionResult OnPost()
        {
            _service.Update(UpdateCustomer);
            return RedirectToPage("IndexCustomer");
        }
    }
}

