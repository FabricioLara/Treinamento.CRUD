using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.CRUD.Dominio.DataContext;
using Treinamento.CRUD.Dominio.Entidade;

namespace Treinamento.CRUD.Repository.Biz
{
    public class UFrepository
    {
        public UF ObterUF(int codigo)
        {
            using (var db = new DBContexto())
            {
                try
                {
                    if (codigo == 0)
                        throw new Exception("Codigo não pode ser menor ou igual a zero");

                    UF ufSigla = db.UF.Find(codigo);
                    return ufSigla;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<UF> ListaByUF()
        {
            using (var db = new DBContexto())
            {
                try
                {
                    List<UF> listaUF = db.UF.ToList();
                    return listaUF;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
