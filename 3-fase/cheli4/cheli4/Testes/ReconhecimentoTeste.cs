using cheli4.Models.Comercial;

namespace cheli4.Testes
{
    class ReconhecimentoTeste
    {
        public static void MainReconhecimento()
        {
            Reconhecimento rec = new Reconhecimento();
            while (true) rec.Speak("Hello, how are you today?");
        }
    }
}