using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDoAluno.Models
{
    /// <summary>
    /// Curso ofertado pela faculdade e cursado pelos alunos.
    /// </summary>
    sealed public class Course
    {
        #region Proprieties

        /// <summary>
        /// ID do curso.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Nome do curso.
        /// Máximo de 100 caracteres.
        /// </summary>
        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Área do conhecimento a que o curso pertence.
        /// </summary>
        [Required]
        [Column("KnowLedgeField", TypeName = "varchar(100)")]
        public KnowledgeField KnowledgeField { get; set; }
        
        /// <summary>
        /// Propriedade de navegação para a coleção de entidades Students
        /// </summary>
        public List<Student> Students { get; set; }


        #endregion
    }
}
