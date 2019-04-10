using System.Collections.Generic;
using System;

namespace cheli4.Models.Comercial
{
    public class Passo : IPasso
    {
        
        /// <summary>
        /// Variáveis de instância.
        /// </summary>
        public string id;
        public string descricao;
        public Dictionary<string,string> expressoes;
        public int duracao; // em millisegundos, para facilitar a
        
        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public Passo()
        {
            id = Convert.ToString(-1);
            descricao = "";
            expressoes = new Dictionary<string, string>();
            duracao = -1;
        }

        /// <summary>
        /// Construtor parametrizado.
        /// </summary>
        /// <param name="id"> id do passo</param>
        /// <param name="descricao"> descrição do passo</param>
        /// <param name="expressoes"> expressões agregadas a este passo </param>
        /// <param name="duracao"> duração deste passo</param>
        public Passo(string id, string descricao, Dictionary<string, string> expressoes, int duracao)
        {
            this.id = id;
            this.descricao = descricao;
            this.expressoes = expressoes;
            this.duracao = duracao;
        }

        /// <summary>
        /// Compara este objeto da classe Passo com outro objeto, verificando a sua igualdade.
        /// </summary>
        /// <param name="obj">objeto a comparar com a instância</param>
        /// <returns>retorna true, quando os objetos são iguais, e false, caso contrário</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)return true;

            if (obj == null || this.GetType() != obj.GetType())return false;

            Passo passo = (Passo) obj;

            return this.id.Equals(passo.id) && this.descricao.Equals(passo.descricao)
                && this.expressoes.Equals(passo.expressoes) && this.duracao == passo.duracao;
        }

        /// <summary>
        /// Devolve a expressão identifica
        /// </summary>
        /// <param name="numeroExpressao"></param>
        /// <returns></returns>
        public string GetExpressao(int numeroExpressao)
        {
            if (numeroExpressao < 1 || numeroExpressao > this.expressoes.Count)   //  verifica se o número está entre o intrevalo existente
                throw new NumeroDeExpressaoDoPassoInvalidoException(Convert.ToString(numeroExpressao));
            return this.expressoes.GetValueOrDefault(Convert.ToString(numeroExpressao));
        }
    }
}
