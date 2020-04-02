using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHS.MoviesApp.Web.Client.Models
{
    public class MovieModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }

        public string ImageName { get; set; }

        public string ImageType { get; set; }

        public string Image { get; set; }


    }
}
