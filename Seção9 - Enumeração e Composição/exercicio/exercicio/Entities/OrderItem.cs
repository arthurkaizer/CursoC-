using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace exercicio.Entities
{
    class OrderItem
    {
        public int quantity { get; set; }
        public double price { get; set; }
        public Product produto { get; set; }

        public OrderItem(int quantity, double price, Product produto)
        {
            this.quantity = quantity;
            this.price = price;
            this.produto = produto;
        }

        public OrderItem()
        {
        }

        public double subtotal()
        {
            return quantity * price;
        }

        public override string ToString()
        {
            return produto.name
                + ", $"
                + price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + quantity
                + ", Subtotal: $"
                + subtotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
