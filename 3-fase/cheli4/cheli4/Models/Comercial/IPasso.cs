namespace cheli4.Models.Comercial{

	interface IPasso{
		//bool IsValidNumber(int numeroExpressao);
        /* tirei este m�todo, pq esta verifica��o pode ser feita no m�todo GetExpression() */
		string GetExpressao(int numeroExpressao ); 
	}
}