using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Domain.Entity.Notifications;
using Domain.Interfaces;

namespace Domain.Entity
{
    [Table("Product")]
    public class Produto : Notifies
    {
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRD_NOME")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("PRD_VALO")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("PRD_QUANT")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        
        [Column("PRD_CREATED")]
        [Display(Name = "Created")]
        public virtual DateTime Created { get; set; }

        [Column("PRD_MODIFIED")]
        [Display(Name = "Modified")]
        public virtual DateTime Modified { get; set; }
    }    
}

