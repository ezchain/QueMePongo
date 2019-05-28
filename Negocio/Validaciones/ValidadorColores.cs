﻿using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorColores : IValidador
    {
        private readonly (Color colorPrim, Color colorSec) _colores;

        public ValidadorColores((Color colorPrim, Color colorSec) colores)
        {
            _colores = colores;
        }

        public void Validar()
        {
            if (_colores.colorPrim == _colores.colorSec)
                throw new Exception("Los colores primarios y secundarios no pueden ser iguales.");
        }
    }
}
