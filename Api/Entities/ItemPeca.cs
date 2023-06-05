namespace Api.Entities
{
    public class ItemPeca
    {
        public int Id { get; set; }
        public int IdVendaPeca { get; set; }
        public int IdPeca { get; set; }
        public VendaPeca VendaPeca { get; set; }
        public Peca Peca { get; set; }
        public int Qnt { get; set; }
        public int PreUni { get; set; }
        
    }

}