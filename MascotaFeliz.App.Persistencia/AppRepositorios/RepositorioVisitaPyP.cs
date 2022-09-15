using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitaPyP : IRepositorioVisitaPyP
    {
        /// <summary>
        /// Referencia al contexto de VisitaPyP
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVisitaPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        public VisitaPyP AddVisitaPyP(VisitapYp visitaPyP)
        {
            var visitaPyPAdicionada = _appContext.VisitasPyP.Add(visitaPyP);
            _appContext.SaveChanges();
            return  visitaPyPAdicionada.Entity;
        }

        public void DeleteVisitaPyP(int idVisitaPyP)
        {
            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitaPyP);
            if (visitaPyPEncontrada == null)
                return;
            _appContext.VisitasPyP.Remove(visitaPyPEncontrada);
            _appContext.SaveChanges();
        }

       public IEnumerable<VisitaPyP> GetAllVisitasPyP()
        {
            return GetAllVisitasPyP_();
        }

////////////////////// filtrar por filtro

        public IEnumerable<VisitaPyP> GetAllVisitasPyP_()
        {
            return _appContext.VisitasPyP;
        }

        public VisitaPyP GetVisitaPyP(int idVisitaPyP)
        {
            return _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitaPyP);
        }

        public VisitaPyP UpdateVisitaPyP(VisitaPyP visitaPyP)
        {
            var VisitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == visitaPyP.Id);
            if (VisitaPyPEncontrada != null)
            {
                visitaPyPEncontrada.FechaVisita = visitaPyP.FechaVisita
                visitaPyPEncontrada.Temperatura = visitaPyP.Temperatura
                visitaPyPEncontrada.Peso = visitaPyP.Peso
                visitaPyPEncontrada.FrecuenciaRespiratoria = visitaPyP.FrecuenciaRespiratoria
                visitaPyPEncontrada.FrecuenciaCardiaca = visitaPyP.FrecuenciaCardiaca
                visitaPyPEncontrada.EstadoAnimo = visitaPyP.EstadoAnimo
                visitaPyPEncontrada.IdVeterinario = visitaPyP.IdVeterinario
                visitaPyPEncontrada.Recomendaciones = visitaPyP.Recomendaciones

                _appContext.SaveChanges();
            }
            return VisitaPyP Encontrada;
        }     
    }
}
