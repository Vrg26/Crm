using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Product
    {
        public int ProductId { get; set; }// Чтобы EntityFraimwork понял что это ID
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
