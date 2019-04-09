using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models{
	interface InterfaceCheli4{
		public boolean GetLocalizacao();
		public List<string> getSuperMercados(string localizacao);
	}
}