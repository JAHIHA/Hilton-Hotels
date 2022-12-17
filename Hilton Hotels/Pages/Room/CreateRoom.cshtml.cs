using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Hilton_Hotels.Pages.Room
{
    public class CreateRoomModel : PageModel
    {
        private readonly IRoomService _create;

        public CreateRoomModel(IRoomService create)
        {
            _create = create;
        }
        [BindProperty]
        public CreateRoom Create { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            RoomModel newRoom = new RoomModel
                (Create.ID,
               Create.Type,
                Create.Price);

            _create.Add(newRoom);
        }


    }
    public class CreateRoom
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Price { get; set; }

      

    }
}

