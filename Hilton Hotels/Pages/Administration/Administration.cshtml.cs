using Hilton_Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Administration
{
    public class AdministrationModel : PageModel
    {
        List<RoomModel> rooms = new List<RoomModel>();
        

        public void Add(RoomModel addroom)
        {
            rooms.Add(addroom);
        }

        public void Delete(string id)
        {
            RoomModel room = new();
            foreach (var item in rooms)
            {
                if (item.ID == id)
                {
                     room = item; 
                }
            }
            rooms.Remove(room);
        }


        
        public void OnGet()
        {
        }
    }
}
