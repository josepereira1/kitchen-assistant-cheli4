using System.Collections.Generic;

namespace cheli4.Models
{
	interface InterfaceCheli4 {
		bool GetLocalizacao();
		List<string> getSuperMercados(string localizacao);
	}
}