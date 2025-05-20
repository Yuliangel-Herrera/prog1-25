namespace Modelo
{
    class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? HomeAddress { get; set; }
        public Address? WorkAddress { get; set; }

        public bool Validade()
        {
            bool isValid = true;
            isValid = !string.IsNullOrEmpty(this.Name) &&
                      (this.Id > 0) && !string.IsNullOrEmpty(this.HomeAddress);
            return isValid;
        }
        public Customer Retrieve()
        {
            return new Customer();
        }
        public void Save(Customer customer)
        {
        }
    }
}
