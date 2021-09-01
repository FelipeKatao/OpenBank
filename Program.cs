using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo ao OpenBank");
            Console.WriteLine("1- Criar uma nova conta");
            while(CLI.CLI_RUNNER == true) CLI.CallOption();
            Console.WriteLine("Aplicação foi encerrada");
            Console.ReadLine();
        }
    }
    class DistBancs
    {
        //public Conta ContasAgregadas = new Conta();
        public Gerenciamento GerenciamentoContas = new Gerenciamento();
    }
    static class CLI
    {
        delegate void _opc_possi();
        public static bool CLI_RUNNER = true; 
        static readonly _opc_possi OPCNEW0 = new _opc_possi(CriarCliente);
        static readonly _opc_possi OPCNEW1 = new _opc_possi(CountClientes);
        static readonly _opc_possi OPCNEW2 = new _opc_possi(MostrarContas);
        static readonly _opc_possi OPCNEW3 = new _opc_possi(DepositarConta);
        static DistBancs DistBancs = new DistBancs();
        static List<Conta> ContasListadas = new List<Conta>();

        public static dynamic[] OPTIONS = new dynamic[] {OPCNEW0,OPCNEW1,OPCNEW2,OPCNEW3 }; 

        public static void CallOption()
        {
            try
            {
                int select = int.Parse(Console.ReadLine());
                if (select<=3)
                    OPTIONS[select]();
                else
                    CLI_RUNNER = false;
            }
            catch (Exception)
            {
                CLI_RUNNER = false;
            }
            

        }
        private static void Opcions() { }
        private static void CriarCliente()
        {
            dynamic filed = int.Parse(Console.ReadLine());
            TipoConta Tipoconta = (TipoConta)filed;
            double saldo = double.Parse(Console.ReadLine());
            double credito = double.Parse(Console.ReadLine());
            string nome = Console.ReadLine();
            Conta C1 = new Conta(Tipoconta, saldo, credito, nome);
            DistBancs.GerenciamentoContas.AddnovaConta(C1);
            Console.WriteLine("Conta Criada Com sucesso!!");
        }
        private static void CountClientes()
        {
            DistBancs.GerenciamentoContas.ContasGerenciadas();
        }
        private static void MostrarContas()
        {
            DistBancs.GerenciamentoContas.ShowContas();
        }
        private static void DepositarConta()
        {
            Console.WriteLine("Digite o valor, após a conta ID");
            double value = int.Parse(Console.ReadLine());
            int Id = int.Parse(Console.ReadLine());
            DistBancs.GerenciamentoContas.Deposito(value, Id);
        }

    }

}
