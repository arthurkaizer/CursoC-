using System;
using System.Collections.Generic;
using System.Text;

namespace exercicioFixacao.Entities
{
    class Product
    {
        public string description { get; private set; }
        public double price { get; private set; }
        public int quantity { get; private set; }

        public Product(string description, double price, int quantity)
        {
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public double Total()
        {
            return price * quantity;
        }

    }
}
