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
            _bookingModel.Add(book);
            SaveToJson();
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

            booking.CheckIn = book.CheckIn;
            booking.CheckOut = booking.CheckOut;
            

            SaveToJson();
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

    }
}
