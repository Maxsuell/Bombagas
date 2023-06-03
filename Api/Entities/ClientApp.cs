namespace Api.Entities
{
    public class ClientApp
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string NameClient { get; set; }
        public string Endereco { get; set; }
        public int QNTBicos { get; set; }
        public int QNTTanques { get; set; }
        public float Dividas { get; set; }
        public ICollection<Contatos> Contatos { get; set; }

    }
}