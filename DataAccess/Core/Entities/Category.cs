﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Builds = new Collection<Build>();
        }
        public int ID { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

        public ICollection<Build> Builds { get; set; }
    }
}
