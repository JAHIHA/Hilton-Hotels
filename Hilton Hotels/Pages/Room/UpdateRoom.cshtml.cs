using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class UpdateRoomModel : PageModel
    {
        public UpdateRoomModel(IRoomService services)
        {
            _service = services;
        }
        private IRoomService _service;

        [BindProperty]
        public RoomModel UpdateRoom { get; set; }


        public void OnGet(int id)
        {
            UpdateRoom = _service.Find(id);
        }
        public IActionResult OnPost()
        {
            _service.Update(UpdateRoom);
            return RedirectToPage("IndexRoom");
        }
    }
}

