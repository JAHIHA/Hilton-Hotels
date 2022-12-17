using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;

namespace Hilton_Hotels.Pages.Customer
{
    public class IndexCustomerModel : PageModel
    {
        private ICustomerService _customerServices;

        public IndexCustomerModel(ICustomerService service)
        {
            _customerServices = service;
        }
        public List<CustomerModel> CustomerModels { get; set; }
        public void OnGet()
        {
            CustomerModels = _customerServices.Get();
        }
       
    }
}
