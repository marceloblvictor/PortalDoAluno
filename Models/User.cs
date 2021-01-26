using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Registro")]        
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Nome da Pessoa")]
        [Column("Name", TypeName = "varchar(100)")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*\s([A-Z][a-zA-Z]\s*)*$", ErrorMessage = "Nome e sobrenomes com primeira letra maiúscula")]
        public string Name { get; set; }
    }
}
