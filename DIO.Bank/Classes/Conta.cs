using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        //Método construtor, ele é chamado quando é criado o objeto. Sempre possuí o mesmo nome da classe.
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta; //this. serve pra definir que é apenas sobre o objeto instanciado não sobre todos...
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            //this.Saldo = this.Saldo - valorSaque; funciona igual a operação acima

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting --documentação de formatação de string

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            //this.Saldo = this.Saldo + valorDeposito; funciona igual a operação acima

            Console.WriteLine("Saldo atial da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito + " | ";
            return retorno;
        }
    }
}