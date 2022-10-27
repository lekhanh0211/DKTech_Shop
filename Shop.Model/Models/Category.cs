﻿using Shop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("Category")]
    public class Category : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        [MaxLength(256)]
        public string Image { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
