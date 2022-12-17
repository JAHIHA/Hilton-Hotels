using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        public DeleteCustomerModel(ICustomerService service)
        {
            _service = service;
        }
        private ICustomerService _service;
        [BindProperty]
        public CustomerModel RemoveCustomer { get; set; }

        public void OnGet(string name)
        {
            RemoveCustomer = _service.Find(name);
        }
        public IActionResult OnPost(string name)
        {
            _service.Delete(name);
            return RedirectToPage("IndexCustomer");
        }
    }
}
