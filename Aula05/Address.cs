namespace Address
{
	class Address
	{
		public int Id { get; set; }
        public string? rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Complemento { get; set; }
        public int cep { get; set; }

        public bool Validade()
        {
        return true;
        }
        public Address Retrieve()
        {
        return new Address();
        }
        public void Save(Address address)
        {
        }
    }
}
