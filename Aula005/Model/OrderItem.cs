namespace Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validade()
        {
            bool isValid = true;
            int Quantity = 10;
            isValid = (Product != null) && (this.Id > 0)              //this. é utilizado para prevenir ambiguidade
                      && (this.Quantity > 0) && (PurchasePrice > 0);  //Pega a variavel da classe maior. Ex: Quantity classe OrderItem
            return isValid;
        }
        public OrderItem Retrieve()
        {
            return new OrderItem();
        }
        public void Save(OrderItem orderItem)
        {
        }
    }
}
