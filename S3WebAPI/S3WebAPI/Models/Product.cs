using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3WebAPI.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string title { get; set; }
        public string imageURL { get; set; }
        public string comments { get; set; }
    }
}