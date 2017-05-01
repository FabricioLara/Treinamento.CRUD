using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.CRUD.Dominio.Entidade
{
    public class Dependente
    {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Info { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
