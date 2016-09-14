using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK_VALERA.Models
{
    public class Comentario
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Conteudo")]
        [MaxLength(500)]
        public string descricao { get; set; }
        public string UserId { get; set; }
        public ApplicationUser Usuario { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataComentario { get; set; }
        public int PublicacaoId { get; set; }
        public Publicacao publicacao { get; set; }
    }
}
