using System.Collections.Generic;

namespace cheli4.Models.Comercial{
	
	interface InterfaceReceita{
		List<Ingrediente> GetIngredientes(); 
		Passo GetStep(int numero); 
	}
}