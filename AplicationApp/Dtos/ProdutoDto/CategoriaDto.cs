using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity;

namespace AplicationApp.Dtos
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]   
        [StringLength(20, MinimumLength = 3,
        ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

    }
}