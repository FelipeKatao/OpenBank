using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank
{
    class Conta
    {
        private TipoConta _tipoConta { get; set; }
        private double _saldo { get; set; }
        private double _credito { get; set; }
        private string _nome { get; set; }

        public Conta(TipoConta Conta,double saldo,double credito,string nome)
        {
            _tipoConta = Conta; _saldo = saldo; _credito = credito;_nome = nome;
        }
        public bool Sacar(double ValorSaque)
        {
            if(this._saldo - ValorSaque < (this._credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this._saldo -= ValorSaque;
            Console.WriteLine("Saldo atual da conta é {0}",this._saldo);
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            _saldo += valorDeposito;
            Console.WriteLine("Sue saldo atual é: {0}",_saldo);
        }
        public void Transferir(double valorTransferencia, Conta destino)
        {
            if (this.Sacar(valorTransferencia+_credito))
            {
                destino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            return "Usuario da Conta:"+_nome+"| Tipo da Conta:"+_tipoConta+"| Saldo na conta:"+_saldo+"| Credito:"+_credito+" ";
        }
    }
}
