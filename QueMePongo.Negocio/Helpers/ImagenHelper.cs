using Microsoft.AspNetCore.Http;
using QueMePongo.Dominio.Interfaces;
using System.Drawing;

namespace QueMePongo.Negocio.Helpers
{
    public class ImagenHelper : IImagenHelper
    {
        public byte[] ImagenFileToArray(IFormFile imagenFile)
        {
            var imagen = Image.FromStream(imagenFile.OpenReadStream());
            var bitMap = new Bitmap(imagen, 500, 500);
            return (byte[])System.ComponentModel.TypeDescriptor.GetConverter(bitMap).ConvertTo(bitMap, typeof(byte[]));
        }
    }
}
