using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("Footer")]
   public class Footer
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
