using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace cheli4.Models.Comercial
{
    class Reconhecimento
    {
        private static string key = "94b604dceab14c2b87fd111b7cb78a38";
        private static string region = "westus";
        private static string NEXT_TXT = "next.txt";
        private static string BACK_TXT = "back.txt";
        private static string HELP_TXT = "help.txt";
        private static string REPEAT_TXT = "repeat.txt";
        private static string EXPRESSIONS_TXT = "expressions.txt";
        private static int SPEAKER_SLEEP_TIME_MILLIS = 100;

        // variáveis privadas para validação e inicialização da API Microsoft Speech
        private SpeechConfig config;
        private SpeechSynthesizer synthesizer;
        private SpeechRecognizer recognizer;

        private String result; // variável privada para armazenamento do reconhecimento de voz
        private ArrayList nextList;
        private ArrayList backList;
        private ArrayList helpList;
        private ArrayList repeatList;
        private ArrayList expressionsList;

        /// <summary>Construtor vazio. Cria o objeto útil para reconhecimento de voz.</summary>
        public Reconhecimento()
        {
            this.result = "";
            this.initCmdsList(); // inicializa a lista das possíveis expressões para cada comando
            this.initMicrosoftSpeechAPI(); 
        }

        /// <summary>
        /// Escuta uma ou mais expressões e devolve o resultado reconhecido em formato String.
        /// Com este método o programador é impedido de se esquecer 
        /// de meter a tarefa á espera - T.Wait().
        /// </summary>
        /// <returns>Devolve o reconhecimento de voz em formato String.</returns>
        public string Listen()
        {
            this.result = ""; // reset à variável de classe
            Console.WriteLine("listening..."); // apenas para no terminal saber que está à escuta
            this.RecognizeSpeechAsync().Wait(); // efetua o reconhecimento de voz
            Console.WriteLine("listened => {0}", this.result);
            return this.result; 
        }

        /// <summary>
        /// Tranforma a String em voz, ditando em voz alta a mesma.
        /// Com este método o programador é impedido de se esquecer 
        /// de meter a tarefa á espera - T.Wait().
        /// </summary>
        /// <param name="text">texto a ser convertido em voz.</param>
        public void Speak(String text) {
            Console.WriteLine("Converting - {0} - to voice...", text);
            this.SynthesisToSpeakerAsync(text).Wait();
        }

        /// <summary>
        /// Método utilizado para aprender novas expressões.
        /// Exemplo de uso: learnExpressions("hey-chely-list.txt", 10) 
        /// Pede ao programador para repetir 10 vezes a expressão "hey chely" e guarda o texto
        /// reconhecido no ficheiro. 
        /// Desta forma o programador obtém as várias expressões, que podem
        /// ser diferentes, mas que no entanto correspondem a "hey chely". 
        /// Exmplo de output no ficheiro:
        /// {"hey shelly", "a shelly", "say shelly", "hey shelly", "hey kelly", "hello chelly", ...}
        /// </summary>
        /// <param name="fileName">nome do ficheiro.</param>
        /// <param name="N">número de vezes pedido ao programador para ditar a expressão.</param>
        public void LearnExpressions(String fileName, int N) 
        {
            StringBuilder sb = new StringBuilder(); 
            for (int i=0; i<N; i++)
            {
                String str = this.Listen();

                if ( str.EndsWith(",") || str.EndsWith(".") || str.EndsWith("!") || str.EndsWith("?") || str.EndsWith(":") )
                    str = str.Substring(0, str.Length - 1);

                Console.WriteLine("Can I append - {0} - to {1}? type y/n", str, fileName);
                string line = Console.ReadLine();
                

                if (line.Equals("y"))
                {
                    sb.Append('\n').Append(str);
                    Console.WriteLine("appended...");
                }
            }
            File.AppendAllText(fileName, sb.ToString()); // adiciona a string ao ficheiro
        }

        /// <summary>
        /// Indica se a expressão foi detetada no texto, note-se que não se usa apenas o método contains(), pois a expressão pode estar lcoalizada a meio do texto.
        /// </summary>
        /// <param name="text">texto reconhecido.</param>
        /// <returns>Retorna true caso tenha sido detatada, false caso contrário.</returns>
        private bool checkCommand(string text, ArrayList list)
        {
            bool res = false;
            foreach (string expr in list) // verifica se consta na lista
            {
                if (text.Contains(expr)) // sucesso - foi detetada a expressão no meio da string text
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public int commandType(String text)
        {
            if (checkCommand(text, this.nextList)) return 0;
            else if (checkCommand(text, this.backList)) return 1;
            else if (checkCommand(text, this.helpList)) return 2;
            else if (checkCommand(text, this.repeatList)) return 3;
            else if (checkCommand(text, this.expressionsList)) return 4;
            else return -1;
        }


        /// <summary>
        /// Configura a API do Microsoft Speech, validando a chave e região dos serviços, e 
        /// iniciliza as variáveis de instância associadas aos mesmos.
        /// </summary>
        private void initMicrosoftSpeechAPI()
        {
            this.config = SpeechConfig.FromSubscription(Reconhecimento.key, Reconhecimento.region);
            this.synthesizer = new SpeechSynthesizer(this.config);
            this.recognizer = new SpeechRecognizer(this.config);
        }

        /// <summary>
        /// Ativa o reconhecimento de voz, ficando à escuta de uma ou mais expressões.
        /// </summary>
        /// <returns>Retorna a tarefa de reconhecimento de voz.</returns>
        private async Task RecognizeSpeechAsync()
        {    
            // Starts speech recognition, and returns after a single utterance is recognized. The end of a
            // single utterance is determined by listening for silence at the end or until a maximum of 15
            // seconds of audio is processed.  The task returns the recognition text as result. 
            // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
            // shot recognition like command or query. 
            // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
            var result = await this.recognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.RecognizedSpeech) // sucesso
            {
                String text = result.Text;
                this.result = text.ToLower();
            }      
        }

        /// <summary>
        /// Tranforma a String em voz, ditando em voz alta a mesma.
        /// </summary>
        /// <param name="text">texto a ser convertido em voz.</param>
        /// <returns>Retorna a tarefa de conversão de voz.</returns>
        private async Task SynthesisToSpeakerAsync(String text)
        {
            using (var result = await this.synthesizer.SpeakTextAsync(text))
            {
                if (result.Reason == ResultReason.SynthesizingAudioCompleted) // sucesso
                {
                    // certifica-se que tem tempo para ditar a expressão
                    System.Threading.Thread.Sleep(text.Length * SPEAKER_SLEEP_TIME_MILLIS);
                }
            }
        }

        private void initCommandList(String fileName, ArrayList list)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                    // Console.WriteLine(line); // para debug no terminal
                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                Console.Error.WriteLine("\nFicheiro com expressões \"" + fileName + "\" não encontrado, por favor crie-o usando o método LearnExpressions() da classe Reconhecimento");
                Console.WriteLine("type enter to continue...");
                Console.ReadLine();
                Environment.Exit(1); // insucesso
            }
        }

        /// <summary>
        /// Inicializa a lista de possíveis expressões correspondentes a "hey chely" 
        /// e faz o povoamento da mesma caso o ficheiro "hey-chely-list.txt" exista.
        /// </summary>
        /// <exception cref="Exception">lança uma exceção caso qualquer erro ocorra.</exception>
        private void initCmdsList()
        {
            this.nextList = new ArrayList();
            this.backList = new ArrayList();
            this.helpList = new ArrayList();
            this.repeatList = new ArrayList();
            this.expressionsList = new ArrayList();

            this.initCommandList(NEXT_TXT, this.nextList);
            this.initCommandList(BACK_TXT, this.backList);
            this.initCommandList(HELP_TXT, this.helpList);
            this.initCommandList(REPEAT_TXT, this.repeatList);
            this.initCommandList(EXPRESSIONS_TXT, this.expressionsList);
        }
    }
}
