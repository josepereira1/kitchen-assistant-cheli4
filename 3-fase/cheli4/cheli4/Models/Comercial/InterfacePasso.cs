namespace cheli4.Models.Comercial{

	interface InterfacePasso{
		bool IsValidNumber(int numeroExpressao);
		string GetExpression(int numeroExpressao ); 
	}
}