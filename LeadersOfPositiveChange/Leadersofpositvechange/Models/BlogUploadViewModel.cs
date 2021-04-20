﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadersofpositvechange.Models
{
    public class BlogUploadViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Post { get; set; }
        public DateTime DateTime { get; set; }
        public string PostedBy { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public List<HttpPostedFileBase> Files { get; set; }

    }
}