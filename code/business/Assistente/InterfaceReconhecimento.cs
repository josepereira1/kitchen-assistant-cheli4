interface InterfaceReconhecimento{
	public void Listen();
	public bool IsInitExpression(); 
	public bool IsVoiceCmd();
	public void Dictate(string mensagem);
	public string GetVoiceCmds();   
}