using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    /// <summary>
    /// Aluno que frequenta a faculdade.
    /// </summary>
    sealed public class Student
    {
        #region Proprieties

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
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Média global do aluno.
        /// Precisão de duas casas decimais no máximo.
        /// </summary>
        [Required]
        [Column("GlobalRating", TypeName = "decimal(5, 2)")]
        public decimal GlobalRating { get; set; }

        /// <summary>
        /// ID do curso em que o aluno está inscrito
        /// </summary>
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        /// <summary>
        /// Propriedade de navegação para a entidade mãe Course em que o aluno está inscrito
        /// </summary>
        public Course Course { get; set; }

        #endregion
    }
    
}
