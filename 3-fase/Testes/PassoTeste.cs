using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cheli4.Models.Comercial;

namespace cheli4.Testes
{
    public class PassoTeste
    {
        public void MainPassoTeste() {
            Passo passo = new Passo();

            passo.expressoes.Add("1", "Claras em castelo são uma forma eficiente!");

            //if (passo.expressoes.ContainsKey("1")) Console.WriteLine("Contém a chave!\n");

            try
            {
                string res = passo.GetExpressao(1);

                Console.WriteLine("Resultado=" + res);

                Console.WriteLine("Press any key to continue ...\n");
                Console.ReadLine();
            }
            catch (NumeroDeExpressaoDoPassoInvalidoException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            //string res = passo.expressoes.GetValueOrDefault("claras em castelo");
        }
    }
}
