using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Hilton_Hotels.Pages.Account
{
    public class Login_inModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            if(Credential.UserName == "Admin" && Credential.Password == "Hotel")
            {
                Response.Redirect("/Administration/Administration");
                
            }
            else
            {
                Response.Redirect("/Index" );  
            }
        }
    }

        public class Credential
        {
            [Required]
            [Display(Name ="User Name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


       

    }
    
}
