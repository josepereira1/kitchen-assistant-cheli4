using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.comercial{

	interface InterfaceReconhecimento{
		public void Listen();
		public bool IsInitExpression(); 
		public bool IsVoiceCmd();
		public void Dictate(string mensagem);
		public string GetVoiceCmds();   
	}
}