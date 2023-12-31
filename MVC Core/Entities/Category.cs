﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Core.Entities
{
    public class Category
    {
        [Key]
        public Guid ID{ get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public ICollection<Products> Products { get; set; }
          = new List<Products>();
    }
}
