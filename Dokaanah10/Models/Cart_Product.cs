namespace Dokaanah10.Models
{
    public class Cart_Product
    {

        public int Caid { get; set; }
        public int Prid { get; set; }

        public virtual Product Pr { get; set; } = null!;   
        public virtual Cart Ca { get; set; } = null!;


    }
}
