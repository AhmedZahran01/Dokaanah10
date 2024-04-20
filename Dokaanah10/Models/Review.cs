using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah10.Models
{
    public class Review
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Customer")]
        public int Customerid { get; set; }



        public virtual Customer Customer { get; set; } = null!;


    }
}
