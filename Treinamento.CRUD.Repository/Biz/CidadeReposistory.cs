using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.CRUD.Dominio.DataContext;
using Treinamento.CRUD.Dominio.Entidade;

namespace Treinamento.CRUD.Repository.Biz
{
    public class CidadeReposistory
    {
        public Cidade ObterCidade(int codigo)
        {
            using (var db = new DBContexto())
            {
                try
                {
                   
                    Cidade cidade = db.Cidade.Find(codigo);
                    return cidade;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Cidade> ListaByCidade(int listCodigo)
        {
            using (var db = new DBContexto())
            {
                try
                {
                    if (listCodigo > 0)
                        return db.Cidade.Where(c => c.UF.ID == listCodigo).ToList();

                    List<Cidade> listaCidade = db.Cidade.ToList();

                    return listaCidade;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
