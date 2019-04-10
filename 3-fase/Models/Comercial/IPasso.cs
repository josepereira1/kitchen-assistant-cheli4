namespace cheli4.Models.Comercial{

	interface IPasso{
		//bool IsValidNumber(int numeroExpressao);
        /* tirei este método, pq esta verificação pode ser feita no método GetExpression() */
		string GetExpressao(int numeroExpressao ); 
	}
}