namespace Dokaanah10.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }



        public virtual ICollection<Product> GetProducts { get; set; } = new List<Product>();
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();


    }
}
