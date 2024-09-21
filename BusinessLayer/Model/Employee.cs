using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public  class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        public String? name { get; set; }
        [Required]
        public String? email { get; set; }
        [Required]
        public String? phone { get; set; }
        [Required]
        public String? createAt { get; set; }
    }
}
