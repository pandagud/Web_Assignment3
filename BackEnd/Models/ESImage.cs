using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackEnd.Models
{
    public partial class ESImage
    {
        //Taget direkte fra opgavebeskrivelsen

        //public long ESImageId { get; set; }
        //[MaxLength(128)]
        //public string ImageMimeType { get; set; }
        //public byte[] Thumbnail { get; set; }
        //public byte[] ImageData { get; set; }

        public long ESImageId { get; set; }
        [MaxLength(128)]
        public string ImageMimeType { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] ImageData { get; set; }
    }
}
