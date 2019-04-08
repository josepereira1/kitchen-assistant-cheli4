using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*	Nossas classes	*/
using business.comercial.Ingrediente;
using business.comercial.Passo;

namespace business.comercial{
	
	interface InterfaceReceita{
		public List<Ingrediente> GetIngredientes(); 
		public Passo GetStep(int numero); 
	}
}