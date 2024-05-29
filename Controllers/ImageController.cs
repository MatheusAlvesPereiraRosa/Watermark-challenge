using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;

namespace ImageWatermarkAPI.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost("watermark")]
        [SupportedOSPlatform("windows6.1")]
        public IActionResult ApplyWatermark([FromBody] ImageRequest request)
        {
            if (string.IsNullOrEmpty(request.Base64Image) || string.IsNullOrEmpty(request.WatermarkText))
            {
                return BadRequest(new { message = "Base64Image and WatermarkText cannot be null or empty." });
            }

            try
            {
                // Decodificando a imagem de string em Base64 para uma imagem normal
                byte[] imageBytes = Convert.FromBase64String(request.Base64Image);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (Image image = Image.FromStream(ms))
                    {
                        // Aplicando marca d'água
                        using (Graphics g = Graphics.FromImage(image))
                        {
                            Font font = new Font("Roboto", request.FontSize);
                            Brush brush = new SolidBrush(Color.FromArgb(request.Opacity, request.R, request.G, request.B));
                            Point position = new Point(request.X, request.Y);
                            g.DrawString(request.WatermarkText, font, brush, position);
                        }

                        // Convertendo a imagem de volta para base64
                        using (MemoryStream resultStream = new MemoryStream())
                        {
                            image.Save(resultStream, ImageFormat.Png);
                            string base64Result = Convert.ToBase64String(resultStream.ToArray());
                            return Ok(new { base64Image = base64Result });
                        }
                    }
                }
            }
            catch (FormatException)
            {
                return BadRequest(new { message = "Invalid Base64 string." });
            }
        }
    }

    // Classe da requisição da imagem 
    public class ImageRequest
    {
        public string? Base64Image { get; set; }
        public string? WatermarkText { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int FontSize { get; set; }
        public int Opacity { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
}
