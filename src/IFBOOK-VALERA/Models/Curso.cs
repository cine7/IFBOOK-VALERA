using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK_VALERA.Models
{
    public class Curso
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição")]
        [MaxLength(30)]
        public string Descricao { get; set; }
        public ICollection<ApplicationUser> Usuarios { get; set; }
    }
}