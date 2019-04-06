using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace speech_hello_world
{
    class Reconhecimento
    {
        private String result; // variável privada para armazenamento do reconhecimento de voz
        private static String key = "84499d48ad0646038b39623e46e12228";
        private static String region = "westus";

        private ArrayList heyChelyList;

        /// <summary>Construtor vazio. Cria o objeto Recognition útil para reconhecimento de voz.</summary>
        public Reconhecimento()
        {
            this.result = "";
            try
            {
                this.initHeyChelyList(); // inicializa a lista das possíveis expressões para "hey chely"
            }catch(FileNotFoundException e)
            {
                e.ToString();
            }
        }

        /// <summary>
        /// Escuta uma ou mais expressões e devovle o resultado reconhecido em formato String.
        /// </summary>
        /// <returns>Devolve o reconhecimento de voz em formato String.</returns>
        public String Listen()
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
            Console.WriteLine("Converting => {0} <= to voice...", text);
            Reconhecimento.SynthesisToSpeakerAsync(text).Wait();
        }

        /// <summary>
        /// Método utilizado para aprender novas expressões.
        /// Exemplo de uso: learnExpressions("hey-chely-list.txt", 10) 
        /// Pede ao programador para repetir 10 vezes a expressão "hey chely" e guarda o texto
        /// reconhecido no ficheiro. 
        /// Desta forma o programador obtém as várias expressões, que podem
        /// ser diferentes, mas que no entanto correspondem a "hey chely". 
        /// Exmplo de output no ficheiro:
        /// {"hey shelly", "hey shelly,", "hey shelly.", "hey kelly", "hello chelly", ...}
        /// </summary>
        /// <param name="fileName">nome do ficheiro.</param>
        /// <param name="N">número de vezes pedido ao programador para ditar a expressão.</param>
        public void LearnExpressions(String fileName, int N) 
        {
            StringBuilder sb = new StringBuilder(); 
            for (int i=0; i<N; i++)
            {
                String str = this.Listen();
                Console.WriteLine("Can I append {0} to {1}? type y/n", str, fileName);
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
        /// Indica se a expressão "hey chely" foi detetada no texto.
        /// </summary>
        /// <param name="text">texto reconhecido.</param>
        /// <returns>Retorna true caso tenha sido detatada, false caso contrário.</returns>
        public bool IsHeyChelyExpression(String text)
        {
            bool res = false;
            foreach (string expr in this.heyChelyList) // verifica se consta na lista
            {
                if (text.Contains(expr)) // sucesso - a expressão hey chely foi dita
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Ativa o reconhecimento de voz, ficando à escuta de uma ou mais expressões.
        /// </summary>
        /// <returns>Retorna a tarefa de reconhecimento de voz.</returns>
        private async Task RecognizeSpeechAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription(Reconhecimento.key, Reconhecimento.region);

            // Creates a speech recognizer.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result. 
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query. 
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync();

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    String text = result.Text;
                    this.result = text.ToLower();
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }

        /// <summary>
        /// Tranforma a String em voz, ditando em voz alta a mesma.
        /// </summary>
        /// <param name="text">texto a ser convertido em voz.</param>
        /// <returns>Retorna a tarefa de conversão de voz.</returns>
        private static async Task SynthesisToSpeakerAsync(String text)
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            // The default language is "en-us".
            var config = SpeechConfig.FromSubscription(Reconhecimento.key, Reconhecimento.region);

            // Creates a speech synthesizer using speaker as audio output.
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                using (var result = await synthesizer.SpeakTextAsync(text))
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        //Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inicializa e faz o povoamento da lista de possíveis expressão 
        /// correspondentes a "hey chely" contidas no ficheiro "hey-chely-list.txt".
        /// </summary>
        private void initHeyChelyList()
        {
            if (!File.Exists("hey-chely-list.txt")) return;  //  para garantir que o ficheiro existe, porque qualquer programador pode se esquecer de verificar
                this.heyChelyList = new ArrayList();
                System.IO.StreamReader file = new System.IO.StreamReader("hey-chely-list.txt");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    this.heyChelyList.Add(line);
                    // Console.WriteLine(line);
                }
                file.Close();
        }
    }
}
