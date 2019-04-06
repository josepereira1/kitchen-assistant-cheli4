using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.comercial{
	
	interface InterfaceReceita{
		public List<Ingrediente> GetIngredientes(); 
		public Passo GetStep(int numero); 
	}
}