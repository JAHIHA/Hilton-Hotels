using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Booking
{
    public class DeleteBookingModel : PageModel
    {
        public DeleteBookingModel(IBookingServices service)
        {
            _service = service; 
        }
        private IBookingServices _service;
        [BindProperty]
        public BookingModel RemoveBooking { get; set; } 

        public void OnGet(int Id)
        {
            RemoveBooking = _service.Find(Id); 
        }
        public IActionResult OnPost(int Id)
        {
            _service.RemoveBooking(Id);
            return RedirectToPage("IndexBooking");
        }
    }
}
