using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*	Nossas classes	*/
using models.comercial.Ingrediente;
using models.comercial.Passo;

namespace models.comercial{
	
	interface InterfaceReceita{
		public List<Ingrediente> GetIngredientes(); 
		public Passo GetStep(int numero); 
	}
}