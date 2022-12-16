using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Booking
{
    public class IndexBookingModel : PageModel
    {
        private IBookingServices _bookingServices;

        public IndexBookingModel(IBookingServices service)
        {
            _bookingServices = service;
        }
        public List<BookingModel> BookingModels { get; set; }
        public void OnGet()
        {
            BookingModels = _bookingServices.Get();
        }
    }
}
