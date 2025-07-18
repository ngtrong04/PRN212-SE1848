using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class CategoryDisplay
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }

        public BitmapImage? PictureImage
        {
            get
            {
                // Bỏ 78 byte đầu nếu dữ liệu Picture > 78 bytes
                if (Picture == null || Picture.Length <= 78) return null;

                var imageBytes = Picture.Skip(78).ToArray();
                try
                {
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        var img = new BitmapImage();
                        img.BeginInit();
                        img.CacheOption = BitmapCacheOption.OnLoad;
                        img.StreamSource = ms;
                        img.EndInit();
                        img.Freeze();
                        return img;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}