using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;

namespace Hilton_Hotels.Models
{
    public class BookingModel
    {
        public int ID { get; set; }
        public int RooomeId{ get; set; }
        public string CustomerUser { get; set; }

        private readonly IBookingServices BookingService; 
        public DateTime CheckIn { get; set; }   
        public DateTime CheckOut { get; set; }



        public BookingModel(int _bookingId, DateTime _checkIn, DateTime _checkOut, string _customerUsername, int _roomId, IBookingServices _services)
        {
            if (_bookingId == default) throw new ArgumentOutOfRangeException(nameof(_bookingId), "Booking Id is required");
            if (_checkIn == default) throw new ArgumentOutOfRangeException(nameof(_checkIn), "CheckIn date is required");
            if (_checkOut == default) throw new ArgumentOutOfRangeException(nameof(_checkOut), "CheckOut date is required");
            if (_roomId == default) throw new ArgumentOutOfRangeException(nameof(_roomId), "Room id is required");
            if (_customerUsername == default) throw new ArgumentOutOfRangeException(nameof(_customerUsername), "CustomerUserName  is required");
            if (_checkIn >= _checkOut) throw new Exception($"CheckOut has to come later than check in (CheckIn, CheckOut): {_checkIn}, {_checkOut}");
            ID = _bookingId; 
            CheckIn = _checkIn;
            CheckOut = _checkOut;
            CustomerUser = _customerUsername;
            RooomeId = _roomId;
            BookingService = _services;
            if (IsOverlapping()) throw new Exception("Booking overlapper med eksisterende booking");
        }


        public bool IsOverlapping()
        {
            return BookingService.Get()
                .Any(a => a.ID != ID && a.CheckIn <= CheckOut && CheckOut <= a.CheckOut && a.RooomeId == RooomeId);
        }








    }
}
