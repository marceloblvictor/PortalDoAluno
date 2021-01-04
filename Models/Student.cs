using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    /// <summary>
    /// Modelo de Aluno.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// ID do aluno.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Nome completo do aluno.
        /// Máximo de 100 caracteres.
        /// </summary>
        [Required]
        [Column("Name", TypeName = "varchar(200)")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Média global do aluno.
        /// </summary>
        [Required]
        [Column("GlobalRating", TypeName = "decimal(5, 2)")]
        public decimal GlobalRating { get; set; }

        

    }
}
