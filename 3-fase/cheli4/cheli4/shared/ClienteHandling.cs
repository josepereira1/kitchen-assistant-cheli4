using cheli4.Models;
using cheli4.Models.RecursosHumanos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace cheli4.shared
{
    public class ClienteHandling
    {
        private readonly DataBaseContext _context; // para ter acesso à BD

        public ClienteHandling(DataBaseContext context)
        {
            this._context = context;
        }

        // DEBUG ----------------------------------------------------------------------------------------

        public Cliente[] getClientes()
        {
            return this._context.clientes.ToArray();
        }


        public Cliente getCliente(string username)
        {
            return this._context.clientes.Find(username);
        }


        public bool setApagado(string username, bool apagado)
        {
            var cliente = new Cliente() { username = username };
            cliente.apagado = apagado;
            this._context.Entry(cliente).Property("apagado").IsModified = true;
            this._context.SaveChanges();
            return true;
        }

        // REGISTAR ------------------------------------------------------------------

        public bool addCliente(Cliente cliente)
        {
            if (this._context.clientes.Any(c => c.username == cliente.username)) return false;

            /** antes de enviar para a BD encripatamos a password */
            cliente.password = Encriptacao.HashString(cliente.password);

            this._context.clientes.Add(cliente);
            this._context.SaveChanges();
            return true;
        }

        // LOGIN --------------------------------------------------------------------

        public bool validateCliente(Cliente cliente)
        {
            Cliente c = this._context.clientes.Find(cliente.username);
            if (c == null) return false; /** não existe cliente com esse username */
            string hash = c.password; /** hash já na base de dados */
            return Encriptacao.VerifyMd5Hash(cliente.password, hash);
        }


        // API para o modelo ClienteReceita ----------------------------------------------------------------------------------------
        /*
        public ClienteReceita getReceitas(string username)
        {
            return (ClienteReceita) this._context.clienteReceitas.Where(cr => cr.FK_username_cliente.Equals(username));
        }
        */

        // API para o modelo Agenda ----------------------------------------------------------------------------------------

    }
}
