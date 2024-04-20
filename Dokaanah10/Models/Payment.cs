using System.ComponentModel.DataAnnotations.Schema;

namespace Dokaanah10.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public List<string> Method { get; set; }



        [ForeignKey("Customer")]
        public int Customerid { get; set; }

        public virtual Customer Customer { get; set; } = null!;

    }
}
