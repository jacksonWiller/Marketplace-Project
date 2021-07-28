using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity;
using Domain.Identity;

namespace AplicationApp.Dtos
{
    public class CompraDto
    {
        public int Id { get; set; }
        public UserDto user { get; set; }
        public ICollection<ItemPedidoDto> ItensDeCompra { get; set; }
    }
}