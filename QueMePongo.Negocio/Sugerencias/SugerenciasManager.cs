using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Sugerencias
{
    public class SugerenciasManager : ISugerenciasManager
    {
        private Queue<ISolicitud> _colaDeSolicitudes;

        public SugerenciasManager()
        {
            _colaDeSolicitudes = new Queue<ISolicitud>();
        }

        public void AgregarSolicitud(ISolicitud solicitud)
        {
            _colaDeSolicitudes.Enqueue(solicitud);
        }

        public async Task<IEnumerable<Atuendo>> Procesar()
        {
            try
            {
                var evento = _colaDeSolicitudes.Dequeue();
                return await evento.Ejecutar();
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
