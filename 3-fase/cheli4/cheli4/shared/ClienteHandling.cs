using cheli4.Models;
using cheli4.Models.RecursosHumanos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace cheli4.shared
{
    public class ClienteHandling
    {
        private readonly ClienteContext _context; // para ter acesso à BD

        public ClienteHandling(ClienteContext context)
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
            this._context.clientes.Add(cliente);
            this._context.SaveChanges();
            return true;
        }

        // LOGIN --------------------------------------------------------------------

        public bool validateCliente(Cliente cliente)
        {
            return this._context.clientes.Any(c => c.username.Equals(cliente.username) && c.password.Equals(cliente.password));
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
