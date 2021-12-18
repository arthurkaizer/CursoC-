using System;
using System.Collections.Generic;
using System.Text;
using exercicio.Entities.Exceptions;

namespace exercicio.Entities
{
    class Account
    {
        private int Number { get; set; }
        private string Holder { get; set; }
        public double Balance { get; set; }
        private double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if(amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if(amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }
            Balance -= amount;
        }
    }
}
