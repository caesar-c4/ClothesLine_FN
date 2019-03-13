using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ClothesLine_FN.Bll
{
    public class Common
    {
        bool status;
        internal byte[] ConvertImage(HttpPostedFileBase imageFile)
        {
            byte[] Image = new byte[imageFile.ContentLength];
            imageFile.InputStream.Read(Image, 0, imageFile.ContentLength);
            return Image;
        }

        public bool ImageValidation(HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();
                var fileName = Path.GetFileName(ImageFile.FileName);

                var allowExtension = new[]
                {
                    ".jpg",
                    ".png",
                    ".jpeg"
                };
                if (allowExtension.Contains(extension))
                {
                    status = true;
                }
            }
            return status;
        }

    }
}