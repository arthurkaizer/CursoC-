using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ExercicioFixacao1.Entities
{
    class UsedProduct : Product
    {
        public DateTime ManufacturedDate { get; set; }

        public UsedProduct(string name, double price, DateTime manufacturedDate) : base(name, price)
        {
            ManufacturedDate = manufacturedDate;
        }

        public override string PriceTag()
        {
            return $"{Name} (used) $ {Price.ToString("F2", CultureInfo.InvariantCulture)} (Manufactured Date: {ManufacturedDate.ToString("dd/MM/yyyy")})";
        }
    }
}
