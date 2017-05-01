using System;
using Treinamento.CRUD.Dominio.Entidade;
using Treinamento.CRUD.Dominio.DataContext;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Treinamento.CRUD.Repository.Biz
{
    public class ClienteRepository
    {
        private readonly DBContexto db = new DBContexto();

        public List<Cliente> ObterListaCliente()
        {
            try
            {
                List<Cliente> listaClientes = db.Cliente.ToList();

                if (listaClientes != null)
                    return listaClientes;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Motivo: " + ex.Message);
            }

        }

        public Cliente ObterClienteByCodigo(int codigo)
        {
            try
            {
                if (codigo == 0)
                    return null;

                Cliente obtemCliente = db.Cliente.Where(c => c.ID == codigo).SingleOrDefault();

                if (obtemCliente != null)
                    return obtemCliente;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Motivo: " + ex.Message);
            }
        }

        public List<Cliente> ObterClienteByNome(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    return null;

                List<Cliente> listaNomes = db.Cliente.Where(p => p.Nome.Contains(nome)).ToList();

                if (listaNomes != null)
                    return listaNomes;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Motivo: " + ex.Message);
            }

        }

        public bool Inserir(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
                throw new Exception("Motivo: " + ex.Message);
            }
        }

        public bool Atualizar(Cliente cliente)
        {           
            try
            {
                if (cliente.ID == 0)
                    return false;

                db.Cliente.Attach(cliente);
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Motivo: " + ex.Message);
            }
        }

        public bool Deletar(int codigo)
        {
            try
            {
                if (codigo == 0)
                    return false;

                Cliente obtemCliente = db.Cliente.Where(c => c.ID == codigo).SingleOrDefault();

                if (obtemCliente != null)
                {
                    db.Cliente.Attach(obtemCliente);
                    db.Cliente.Remove(obtemCliente);
                    db.SaveChanges();
                }

                return true;                    

            }
            catch (Exception ex)
            {
                throw new Exception("Motivo: " + ex.Message);
            }
        }
    }
}
