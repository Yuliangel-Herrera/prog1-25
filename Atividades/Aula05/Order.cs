namespace Modelo
{
    class Order
    {
        #region Atributos
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; } // ???
        #endregion

        public Order() // Não precisa colocar o tipo. Sendo um tipo construtor só pode retornar ele mesmo.
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int OrderId) : this() // Chama o construtor padrão. Ou seja Order()
        {
            this.Id = OrderId;
            this.ShippingAddress = $"Endereço {OrderId}";
        }

        public bool Validade()
        {
            bool isValid = true;
            isValid = (this.OrderItems != null && this.OrderItems.Count > 0) &&
                      (this.Id > 0) && (this.Customer != null);
            return isValid;
        }

        public Order Retrieve(int OrderId)
        {
            return new Order();
        }
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        public void Save(Order order)
        {
        }
    }
}
