using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treinamento.CRUD.Dominio.Entidade
{
   
    public class Cliente  : Endereco
    {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        //public string Endereco { get; set; }
        public List<Dependente> Dependentes { get; set; }
    }
}
