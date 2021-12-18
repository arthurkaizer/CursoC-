using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioFixacao2.Entities
{
    class Company : TaxPayer
    {
       private int NumOfEmployees { get; set; }

        public Company(string name, double anualIncome,int numOfEmployees) : base(name, anualIncome)
        {
            NumOfEmployees = numOfEmployees;
        }

        public override double Tax()
        {
            if(NumOfEmployees > 10)
            {
                return AnualIncome * 0.14;
            }
            else
            {
                return AnualIncome * 0.16;
            }
        }
    }
}
