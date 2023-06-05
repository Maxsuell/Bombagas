using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class VendaPeca
    {
        [Key]
        public int Id { get; set; }
        public float ValorTotal { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int IdCliente { get; set; }
        public ClientApp Cliente { get; set; }
        public ICollection<ItemPeca> ItemPeca { get; set; }
                                
    }
}