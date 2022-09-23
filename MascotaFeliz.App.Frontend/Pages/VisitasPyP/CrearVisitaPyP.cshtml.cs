using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;


namespace MascotaFeliz.App.Frontend.Pages
{
    public class CrearVisitaPyPModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria;

        [BindProperty]
        public VisitaPyP visitaPyP {set;get;}
        [BindProperty]
        public int idMascota {set;get;}

        public IEnumerable<Mascota> ListaMascotas {set;get;}
        public IEnumerable<Veterinario> ListaVeterinario {set;get;}

        public CrearVisitaPyPModel()
        {
            this._repoVisitaPyP=new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoVeterinario=new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoMascota=new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria=new RepositorioHistoria(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? idMascota )
        {
            ListaMascotas=_repoMascota.GetAllMascotas();
            ListaVeterinario=_repoVeterinario.GetAllVeterinarios();
            if(idMascota.HasValue)
            {
                visitaPyP=_repoVisitaPyP.GetVisitaPyP(idMascota.Value);
            }
            else
            {
                visitaPyP=new VisitaPyP();
            }
            if(visitaPyP==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                VisitaPyP visitaCreada=_repoVisitaPyP.AddVisitaPyP(visitaPyP);
                Mascota mascotaEncontrada=_repoMascota.GetMascota(idMascota);
                Historia historiaEncontrada= _repoHistoria.GetHistoria(mascotaEncontrada.Historia.Id);
                _repoHistoria.AsignarVisitaPyP(historiaEncontrada, visitaCreada);

                return RedirectToPage("/ListaMascotas");

            }
        }
    }
}

