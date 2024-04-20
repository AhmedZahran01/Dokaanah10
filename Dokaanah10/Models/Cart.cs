namespace Dokaanah10.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual ICollection<Cart_Product> Cart_Products { get; set; } = new List<Cart_Product>();


    }
}
