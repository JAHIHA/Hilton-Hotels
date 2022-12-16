using Hilton_Hotels.Models;
using Hilton_Hotels.Pages.Account;
using Hilton_Hotels.Pages.Customer;
using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hilton_Hotels.Pages.Booking
{
    public class BookingPageModel : PageModel
    {
        private readonly IBookingServices _booking;

        public BookingPageModel(IBookingServices booking)
        {
            _booking = booking;
        }
        [BindProperty]
        public BookingCustomer Booking { get; set; }   

        public void OnGet()
        {
        }

        public void OnPost()
        {
            BookingModel newBooking = new BookingModel
                (Booking.ID,
               Booking.CheackIn,
                Booking.CheackOut,
                Booking.CustomerUser,
                 Booking.RoomeId, 
                 _booking);

            _booking.AddBooking(newBooking);

        }

        
    }
    public class BookingCustomer
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int RoomeId { get; set; }

        [Required]
        public string CustomerUser { get; set; }

        [Required]
        public DateTime CheackIn { get; set; }

        [Required]
        public DateTime CheackOut  { get; set; }

    }
}
