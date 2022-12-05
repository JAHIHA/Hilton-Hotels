using Hilton_Hotels.Models;

namespace Hilton_Hotels.Services
{
    public interface IRoomService
    {
        public void Add(RoomModel room);
        public void Update(RoomModel room);
        public void Delete(int ID);
        public List<RoomModel> Get();
        public RoomModel Find(int ID);
    }
}
