using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.CRUD.Dominio.Entidade;

namespace Treinamento.CRUD.Dominio.DataContext
{
    public class DBContexto : DbContext, IDisposable
    {
        public DBContexto()
            :base(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }
}
