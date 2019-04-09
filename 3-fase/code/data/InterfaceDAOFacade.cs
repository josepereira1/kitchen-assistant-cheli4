using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*	Nossas classes	*/
using models.utilizadores.Utilizador;
using models.comercial.Filtro;
using models.comercial.Receita;

namespace data{
	
	interface InterfaceDAOFacade{
		public void registaUtilizador(Utilizador utilizador);
		/*	pode ser List<int> em C#*/
		/*
		Depois pode-se fazer da seguinte maneira:
		
		List<T> CreateList<T>(params T[] values)
		{
	   		return new List<T>(values);
		}

		List<int> myValues = CreateList(1, 2, 3);

		*/
		public void registaTodasRespostas(List<int> respostas);
		
		/*	Métodos para ir buscar informação	*/
		public Utilizador GetUtilizador(string username, string password);
		public List<Filtro> GetFiltros();
		public Receita GetReceita(int chave);
		public List<String> getQuetions(int idQuiz);
		public List<Receita> Pesquisar(List<String> filtros);

	}
}