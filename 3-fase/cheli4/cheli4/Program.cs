using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using cheli4.Testes;

namespace cheli4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            // CHAMAR AQUI AS FUNÇÕES DE TESTE
            ReconhecimentoTeste.MainReconhecimento();
            //new PassoTeste().MainPassoTeste();    //  ainda não acabei de testar

            Console.WriteLine("Press any key to continue ...\n");
            Console.ReadLine();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
