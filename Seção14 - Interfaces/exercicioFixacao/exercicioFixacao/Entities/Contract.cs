using System;
using System.Collections.Generic;
using System.Text;

namespace exercicioFixacao.Entities
{
    class Contract
    {
        public int number { get; private set; }
        public DateTime date { get; private set; }
        public double totalValue { get; private set; }
        public List<Installment> Installments { get; set; }

        public Contract(int number, DateTime date, double totalValue)
        {
            this.number = number;
            this.date = date;
            this.totalValue = totalValue;
            Installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }
    }
}
