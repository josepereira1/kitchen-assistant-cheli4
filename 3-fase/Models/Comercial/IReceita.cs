using System.Collections.Generic;

namespace cheli4.Models.Comercial{
	
	interface IReceita{
		List<Ingrediente> GetIngredientes(); 
		Passo GetStep(int numero); 
	}
}