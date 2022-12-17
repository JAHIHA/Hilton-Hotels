using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class IndexRoomModel : PageModel
    {
        private IRoomService _roomServices;

        public IndexRoomModel(IRoomService service)
        {
            _roomServices = service;
        }
        public List<RoomModel> RoomModels { get; set; }
        public void OnGet()
        {
            RoomModels = _roomServices.Get();
        }
    }
}
