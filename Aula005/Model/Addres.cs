namespace Model
{
    public class Addres
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int cep { get; set; }

        public bool Validade()
        {
            return true;
        }
        public Addres Retrieve()
        {
            return new Addres();
        }
        public void Save(Addres address)
        {
        }
    }
}