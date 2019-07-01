﻿using QueMePongo.Dominio.Interfaces.Validacion;

namespace QueMePongo.Negocio.Validaciones
{
    public class EstrategiaValidacion : IContextoValidacion
    {
        private IValidador _validador;

        public void SetEstrategia(IValidador validador)
        {
            _validador = validador;
        }

        public bool RealizarValidacion()
        {
            return _validador.Validar();
        }
    }
}
