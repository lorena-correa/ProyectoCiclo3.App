using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class EditAvionModel : PageModel
    {
        private readonly RepositorioAviones repositorioAvion;
        [BindProperty]
        public Aviones Avion {get;set;}
 
        public EditAvionModel(RepositorioAviones repositorioAvion)
       {
            this.repositorioAvion=repositorioAvion;
       }
 
        public IActionResult OnGet(int avionId)
        {
            Avion=repositorioAvion.GetWithId(avionId);
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Avion.id>0)
            {
            Avion = repositorioAvion.Update(Avion);
            }
            return RedirectToPage("./List");
        }

    }
}