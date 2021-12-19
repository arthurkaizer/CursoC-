using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace exercicioFixacao.Entities
{
    class Installment
    {
        public DateTime dueDate { get; private set; }
        public double amount { get; private set; }

        public Installment(DateTime dueDate, double amount)
        {
            this.dueDate = dueDate;
            this.amount = amount;
        }

        public override string ToString()
        {
            return dueDate.ToString("dd/MM/yyyy")
                + " - "
                + amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
