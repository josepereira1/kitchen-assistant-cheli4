namespace cheli4.Models.Comercial{

	interface InterfaceReconhecimento{
		string Listen();
        bool IsHeyChelyExpression(string text);
        bool IsVoiceCmd();
		void Dictate(string mensagem);
		string GetVoiceCmds();   
	}
}