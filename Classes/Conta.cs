using System;

namespace DIO.Bank
{
    public class Conta
    {
        //propriedades 
        private TipoConta TipoConta { get; set; } //para o tipo de conta será usado enum
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //metodo construtor:
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
            {
                this.TipoConta = tipoConta;
                this.Saldo = saldo;
                this.Credito = credito;
                this.Nome = nome;
            }

        //metodo sacar
        public bool Sacar(double valorSaque)
        {
            //validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *- 1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false; //retorna q não conseguiu fazer o saque
            }

            this.Saldo -= valorSaque; //se passar pelo if, ele consegue fazer o saque q é debitado do saldo

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true; //terá retorno true por ter conseguido fazer o saque
        }

        //método depositar
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
        }
        
        //método transferir
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }

}