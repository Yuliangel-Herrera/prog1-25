namespace Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Addres? HomeAddres { get; set; }
        public Addres? WorkAddres { get; set; }

        public bool Validade()
        {
            bool isValid = true;
            isValid = !string.IsNullOrEmpty(this.Name) &&
                      (this.Id > 0) && (this.HomeAddres != null);
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
