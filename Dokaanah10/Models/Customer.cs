using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah10.Models
{
    public class Customer
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }


        [ForeignKey("Order")]
        public int Orderid { get; set; }


        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual Order Order { get; set; } = null!;


    }
}
