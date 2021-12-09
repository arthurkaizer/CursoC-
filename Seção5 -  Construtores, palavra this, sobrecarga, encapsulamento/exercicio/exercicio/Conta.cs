using System.Globalization;

namespace exercicio
{
    class Conta
    {
        private int id { get; set; }
        private string nomeTitular { get;  set; }
        private double saldo { get; set; }

        public Conta() { }
        public Conta(int id, string nomeTitular)
        {
            this.id = id;
            this.nomeTitular = nomeTitular;
            this.saldo = 0;
        }
        public Conta(int id, string nomeTitular, double saldo)
        {
            this.id = id;
            this.nomeTitular = nomeTitular;
            this.saldo = saldo;
        }

        public void depositar(double deposito)
        {
            saldo += deposito;
        }

        public void sacar(double saque)
        {
            saldo -= saque;
        }
        public override string ToString()
        {
            return "Conta "
                + id
                + ", Titular: "
                + nomeTitular
                + ", Saldo: $ "
                + saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
