﻿using System.ComponentModel.DataAnnotations;
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

        #endregion
    }
    
}
