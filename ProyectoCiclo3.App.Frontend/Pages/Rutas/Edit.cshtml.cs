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
    public class EditRutaModel : PageModel
    {
        private readonly RepositorioRutas repositorioRutas;
        private readonly RepositorioAeropuertos repositorioAeropuertos;
        public IEnumerable<Aeropuertos> Aeropuertos {get;set;}

        [BindProperty]
        public Rutas Ruta {get;set;}
 
        public EditRutaModel(RepositorioRutas repositorioRutas, RepositorioAeropuertos repositorioAeropuertos)
       {
            this.repositorioRutas=repositorioRutas;
            this.repositorioAeropuertos=repositorioAeropuertos;
       }

        public IActionResult OnGet(int rutaId)
        {
            Aeropuertos = repositorioAeropuertos.GetAll();
            Ruta = repositorioRutas.GetWithId(rutaId);
            return Page();

        }

        public IActionResult OnPost(int id, int origen, int destino, int tiempo_estimado)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            
            repositorioRutas.Update(id, origen, destino, tiempo_estimado);
            return RedirectToPage("./List");
        }
    }
}