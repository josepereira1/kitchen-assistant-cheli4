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
            //rec.LearnExpressions("hey_chely.txt", N);

            bool state = true;

            while(state)
            {
                string mensagem = rec.Listen();
                int escolha = 0;

                if (mensagem == "Hey Shelly," || mensagem == "hey shelly,") escolha = 1;
                else if (mensagem == "Start," || mensagem == "start.") escolha = 2;
                else if (mensagem == "Exit," || mensagem == "exit.") escolha = 3;
                else escolha = 0;

                switch(escolha){
                    case 1:
                        rec.Speak("Hey, what do you want?").Wait();
                        break;
                    case 2:
                        rec.Speak("Let's go!").Wait();
                        break;
                    case 3:
                        rec.Speak("Bye Bye, see you later!").Wait();
                        state = false;
                        break;
                    case 0:
                        rec.Speak("i don't understood what you said, repeate please!").Wait();
                        break;
                }
                escolha = 0;
            }
        }
    }
}