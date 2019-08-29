using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IImagenHelper
    {
        byte[] ImagenFileToArray(IFormFile imagen);
    }
}
