using System;
using System.Collections.Generic;
using System.Text;
using Negocio.Enums;

namespace Negocio
{
    public interface IPrenda
    {
        bool coloresValidos(EnumColor colorPrimario, EnumColor colorSecundario);
    }
}
