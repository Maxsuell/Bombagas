using Api.DTOs;
using Api.Entities;

namespace api.Dtos
{
    public class VendaPecaDto
    {
        public int Id { get; set; }
        public float ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public int IdCliente { get; set; }
        public string NameClient { get; set; }
        public ICollection<ItemPecaDto> ItemPecaDto { get; set; }
        public int IdItemPeca { get; set; }
        
    }
}