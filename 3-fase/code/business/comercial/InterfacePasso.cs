using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.comercial{

	interface InterfacePasso{
		public boolean IsValidNumber(int numeroExpressao);
		public string GetExpression(int numeroExpressao ); 
	}
}