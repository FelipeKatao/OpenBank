using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBank
{
    class Gerenciamento
    {
         List<Conta> ContasListadas = new List<Conta>();

        public void AddnovaConta(Conta NovaConta)
        {
            ContasListadas.Add(NovaConta);
        }
        public void ContasGerenciadas()
        {
            Console.WriteLine("O numero de contas existentes é de: " + ContasListadas.Count);
        }
        public void ShowContas()
        {
            foreach (var item in ContasListadas)
            {
                Console.WriteLine(item);
            }
        }
        public void Deposito(double value,int ID)
        {
            ContasListadas[ID].Depositar(value);
        }
    }
}
