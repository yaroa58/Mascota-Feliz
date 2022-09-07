using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia:
{
    public interface IRepositorioveterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario AddVeterinario (Veterinario veterinario);
        void DeleteVeterinario (int IdVeterinario)
        Veterinario UpdateVeterinario (Veterinario veterinario);
        Veterinario GetVeterinario (int IdVeterinario);
        IEnumerable<Veterinario> GetAllVeterinarios();

    }

}