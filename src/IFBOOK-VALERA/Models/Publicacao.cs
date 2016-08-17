using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK_VALERA.Models
{
    public class Publicacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Escreva Algo para ser publicado.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Conteudo")]
        [MaxLength(1000)]
        public string Descricao { get; set; }
        [Column(TypeName = "smalldatetime")]
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime DataPublicacao { get; set; }
        public ApplicationUser Usuario { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
}