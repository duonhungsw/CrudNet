using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="Khong vuot qua 50 ky tu")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public string? avatar {  get; set; }

        public Room? Room { get; set; }  

    }
}
