using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
