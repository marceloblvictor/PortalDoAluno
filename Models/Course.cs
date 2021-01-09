using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    /// <summary>
    /// Curso ofertado pela faculdade e cursado pelos alunos.
    /// </summary>
    internal sealed class Course
    {
        #region Proprieties

        /// <summary>
        /// ID do Curso.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Nome do Curso.
        /// Máximo de 100 caracteres.
        /// </summary>
        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Área do conhecimento a que o Curso pertence.
        /// </summary>
        [Required]
        [Column("KnowLedgeField", TypeName = "varchar(100)")]
        public KnowledgeField KnowledgeField { get; set; }

        #endregion
    }
}
