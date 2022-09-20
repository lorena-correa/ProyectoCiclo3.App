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
    public class DetailsAvionesModel : PageModel
    {
        private readonly RepositorioAviones repositorioAviones;
        public Aviones Avion {get;set;}
 
        public DetailsAvionesModel(RepositorioAviones repositorioAviones)
       {
            this.repositorioAviones=repositorioAviones;
       }
 
        public IActionResult OnGet(int avionId)
        {
            Avion=repositorioAviones.GetWithId(avionId);
            return Page();
        }
    }
}