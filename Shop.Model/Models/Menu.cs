using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        [Required]
        public int GroupId { get; set; }
        [MaxLength(10)]
        public string Target { get; set; }
        public bool Status { get; set; }
        [ForeignKey("GroupId")]
        public virtual MenuGroup MenuGroup { get; set; }

    }
}
