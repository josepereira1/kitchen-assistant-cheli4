namespace speech_hello_world
{
    class MainClass
    {
        public static void Main()
        {
            Reconhecimento rec = new Reconhecimento();

            /* escuta o programador N vezes ao dizer a expressão "hey chely" 
               e escreve no ficheiro o texto reconhecido */
            int N = 5;
            rec.LearnExpressions("hey_chely.txt", N);
        }
    }
}