using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Discription { get; set; }

        public string ImageName { get; set; }

        public string ImageType { get; set; }

        public string Image { get; set; }

    }
}
