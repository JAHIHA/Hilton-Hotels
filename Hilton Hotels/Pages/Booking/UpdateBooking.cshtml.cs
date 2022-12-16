using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;

namespace Hilton_Hotels.Pages.Booking
{
    public class UpdateBookingModel : PageModel
    {
        public UpdateBookingModel(IBookingServices services)
        {
            _service = services;
        }
        private IBookingServices _service;

        [BindProperty]
        public BookingModel UpdateBooking { get; set; }


        public void OnGet(int Id)
        {
            UpdateBooking = _service.Find(Id);
        }
        public IActionResult OnPost()
        {
            _service.Update(UpdateBooking);
            return RedirectToPage("IndexBooking");
        }
    }

}