using Hilton_Hotels.Models;
using Hilton_Hotels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace Hilton_Hotels.Pages.Administration
{
    public class AdministrationModel : PageModel
    {
        private readonly IRoomService _roomService;
        public AdministrationModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [FromRoute] public int Id { get; set; } 
        [BindProperty] public List<RoomModel> Rooms { get; set; } = new List<RoomModel>();
        
        public void OnGet()
        {
            Rooms = _roomService.Get();
            if (Rooms == null)
            {
                
            }
                  
                    
        }

        public void OnPost(int Id)
        {
            if (Id == null)
            {
                //exception
            }
            _roomService.Delete(Id);
            Redirect("Administration/Administration");


        }

    }
}
