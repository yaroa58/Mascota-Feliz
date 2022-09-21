// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using MascotaFeliz.App.Dominio;
// using MascotaFeliz.App.Persistencia;
// using Microsoft.AspNetCore.Mvc.RazorPages;

// namespace MascotaFeliz.App.Frontend.Pages
// {
//     // [Authorize]
//     public class AsignarModel : PageModel
//     {
//         private readonly IRepositorioMascota RepositorioMascota;
//         private static IRepositorioDueno RepositorioDueno = new RepositorioDueno(new Persistencia.AppContext());

//         [BindProperty]
//         public Mascota mascota {get;set;}
//         public Dueno dueno  {get;set;}

//         public IEnumerable<Dueno> duenos {get;set;}

//         public AsignarModel(){
//             this.RepositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());

//         }
    
//         public void OnGet(int? mascotaId){
//             duenos = RepositorioDueno.GetAllDuenos();
//             if(mascotaId.HasValue){
//                 mascota = RepositorioMascota.GetAllMascotas(mascotaId.Value);
//             }
//             if (mascota == null){
//                 RedirectToPage("./NotFound");
//             }
//             else{
//                 Page();
//             }
      
//         }
//         public IActionResult OnPost(Mascota mascota, int duenoId){
//             if(ModelState.IsValid){
//                 duenos =  RepositorioDueno.GetAllDuenos(duenoId);
//                 if(mascota.Id > 0){
//                     mascota.Dueno =  dueno;
//                     RepositorioMascota.UpdateMascota(mascota);
//                 }
//                 return RedirectToPage("../ListaDuenos");
//             }
//             else{
//                 return Page();
//             }
//         }
//     }
// }
