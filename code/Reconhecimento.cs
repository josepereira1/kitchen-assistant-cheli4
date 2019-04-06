using System;
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

        /// <summary>Construtor vazio. Cria o objeto Recognition útil para reconhecimento de voz.</summary>
        public Reconhecimento()
        {
            this.result = "";
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
        /// Exemplo de uso: learnExpressions("hey_chely.txt", 10) 
        /// Pede ao programador para repetir 10 vezes a expressão "hey chelly" e guarda o texto
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
                sb.Append(str).Append('\n');
            }
            this.writeOnFile(fileName, sb.ToString());
        }

        /// <summary>
        /// Escreve a String no ficheiro.
        /// </summary>
        /// <param name="fileName">nome do ficheiro.</param>
        /// <param name="str">String a ser escrita.</param>
        private void writeOnFile(String fileName, String str) {
            System.IO.File.WriteAllText(fileName, str);
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
    }
}
