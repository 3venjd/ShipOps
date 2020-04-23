﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UpLoadImageAsync(IFormFile imageFile,string folder)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\images\\{folder}",
                file
                );
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"~/images/{folder}/{file}";
        }
    }
}
