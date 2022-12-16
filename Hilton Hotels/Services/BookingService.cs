using Hilton_Hotels.Models;
using Hilton_Hotels.Pages.Customer;
using Hilton_Hotels.Services.Interface;
using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class BookingService : IBookingServices
    {


        private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "BookingJson.json";

        List<BookingModel> _bookingModel = new List<BookingModel>();

        public BookingService()
        {
            _bookingModel = ReadFromJson();
        }
        public void AddBooking(BookingModel book)
        {
            var result=IsOverlapping(book);
            if (result == false)
            {
                _bookingModel.Add(book);
                SaveToJson();
            }
            else 
            {
                throw new Exception("is overlapping");
            }
        }
        public List<BookingModel> ReadFromJson()
        {
            using (var file = File.OpenText(fileName))
            {

                String json = file.ReadToEnd();
             return JsonSerializer.Deserialize<List<BookingModel>>(json);
            }
            return new List<BookingModel>();
        }
        public BookingModel Find(int id)
        {
            BookingModel b = _bookingModel.Find(b => b.ID == id);
            if (b is not null)
            {
                return b;
            }
            throw new KeyNotFoundException();
        }

       

        public void RemoveBooking(int id)
        {
            BookingModel booking = Find(id);
            _bookingModel.Remove(booking);
            SaveToJson();
        }

        public void Update(BookingModel book)
        {
            BookingModel booking = Find(book.ID);
            var result = IsOverlapping(book);
            if (result == false)
            {
                booking.CheckIn = book.CheckIn;
                booking.CheckOut = book.CheckOut;
                booking.RooomeId = book.RooomeId;
                booking.CustomerUser = book.CustomerUser;

                SaveToJson();
            }
            else
            {
                throw new Exception("Overlap");
            }
        }
        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_bookingModel);
            File.WriteAllText(fileName, json);
        }
        public List<BookingModel> Get()
        {
            return new List<BookingModel>(_bookingModel);
        }
        public bool IsOverlapping(BookingModel booking)
        {
            return Get()
                .Any(a => a.ID != booking.ID && a.CheckIn <= booking.CheckOut && booking.CheckIn <= a.CheckOut && a.RooomeId == booking.RooomeId);
        }

    }
}
