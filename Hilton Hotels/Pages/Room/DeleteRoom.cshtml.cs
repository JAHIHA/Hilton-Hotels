using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class DeleteRoomModel : PageModel
    {
        public DeleteRoomModel(IRoomService service)
        {
            _service = service;
        }
        private IRoomService _service;
        [BindProperty]
        public RoomModel RemoveRoom { get; set; }

        public void OnGet(int id)
        {
            RemoveRoom = _service.Find(id);
        }
        public IActionResult OnPost(int id)
        {
            _service.Delete(id);
            return RedirectToPage("IndexRoom");
        }
    }
}
