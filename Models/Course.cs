using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{

    sealed public class Course : IValidatableObject
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome do Curso", Description = "Nome e sobrenomes com primeira letra maiúscula")]
        [Column("FirstName", TypeName = "varchar(100)")]    
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[A-Z][a-z]+(\s[A-Za-z]+)*$", ErrorMessage = "Nome e sobrenomes com primeira letra maiúscula")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "A Carga Horária deve ter entre 1 e 500 horas")]
        public int TotalHours { get; set; }
        
        public ContentType ContentType { get; set; }

        #region Navigation Properties

        public List<Student> Students { get; set; }


        #endregion


        #endregion

        #region Implemented Methods

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var validationOutput = new List<ValidationResult>();
            

            if (!Name.EndsWith("Gratuito") && TotalHours < 10)
            {
                validationOutput.Add(new ValidationResult("Se o curso possui menos de 10 horas de carga horária," +
                    "seu nome deve terminar com a palavra \"Gratuito\""));
            }

            return validationOutput;
        }

        #endregion
    }
}
