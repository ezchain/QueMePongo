using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
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

        public void AceptarSugerencia(Sugerencia sugerencia,int IDUsuario)
        {
            sugerencia.Aceptada = true;
            sugerencia.IDUsuario = IDUsuario;
            //GUARDAR EN DB
        }

        public void ObtenerSugerencias()
        {
            //LEVANTAR SUGERENCIAS DB
        }

        public bool SugerenciaAceptada(Sugerencia solicitud)
        {
            //Verificar que  exista en la DB
            return false;
        }
    }
}
