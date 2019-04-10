namespace cheli4.Models.Comercial{

	interface IReconhecimento{
		string Listen();
        bool IsHeyChelyExpression(string text);
        bool IsVoiceCmd();
		void Dictate(string mensagem);
		string GetVoiceCmds();   
	}
}