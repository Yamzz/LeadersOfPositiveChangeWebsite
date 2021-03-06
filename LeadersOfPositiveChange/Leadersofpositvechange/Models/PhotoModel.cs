using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Leadersofpositvechange.Models
{
    public class PhotoModel : List<Photos>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoModel"/> class.
        /// </summary>
        public PhotoModel(string folder)
        {
            var path = HttpContext.Current.Server.MapPath(folder);
            var di = new DirectoryInfo(path);
            //folder = folder + "/";
            foreach (var file in di.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly))
            {
                var p = new Photos(string.Concat(folder, file.Name), Path.GetFileNameWithoutExtension(file.Name));
                Add(p);
            }
        }
    }
}