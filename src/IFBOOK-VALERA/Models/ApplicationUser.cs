using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IFBOOK_VALERA.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Escreva seu nome.")]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        [DataType(DataType.Text)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
        
        public ICollection<Publicacao> Publicacoes { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
}