using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class RoomServiceJson : IRoomService
    {
        private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "RoomJson.json";

        List<RoomModel> _rooms = new List<RoomModel>();
        public RoomServiceJson()
        {
            _rooms = ReadFromJson();
        }
        public void Add(RoomModel room)
        {
            _rooms.Add(room);
            SaveToJson();
        }

        public void Delete(int ID)
        {
            RoomModel room = Find(ID);
            _rooms.Remove(room);
            SaveToJson();

        }

        public List<RoomModel> ReadFromJson()
        {
            using (var file = File.OpenText(fileName))
            {
                String json = file.ReadToEnd();
                return JsonSerializer.Deserialize<List<RoomModel>>(json);
            }
            return new List<RoomModel>();
        }

        public RoomModel Find(int ID)
        {
            RoomModel r = _rooms.Find(r => r.ID == ID);
            if (r is not null)
            {
                return r;
            }
            throw new KeyNotFoundException();
        }
        public void Update(RoomModel newRoom)
        {
            RoomModel room = Find(newRoom.ID);

            room.ID = newRoom.ID;
            room.Type = newRoom.Type;
            room.Price = newRoom.Price;

            SaveToJson();
        }

        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_rooms);
            File.WriteAllText(fileName, json);
        }
        public List<RoomModel> Get()
        {
            return new List<RoomModel>(_rooms);
        }
    }
}
