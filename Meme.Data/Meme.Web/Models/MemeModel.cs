using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Meme.Web.Models
{
    public class MemeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}