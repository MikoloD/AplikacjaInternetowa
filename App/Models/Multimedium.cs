using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace App.Models
{
    public class Multimedium
    {
        [Key]
        public int MultimediumId { get; set; }
        public byte[] Image { get; set; }
        public virtual IssueModel Issue { get; set; }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Gif);

                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = System.Drawing.Image.FromStream(ms);

                return returnImage;
            }
        }
    }
}
