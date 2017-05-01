using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Treinamento.CRUD.Dominio.Entidade;
using Treinamento.CRUD.Repository.Biz;

namespace Treinamento.CRUD.Web
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObterClientes();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            if (string.IsNullOrEmpty(nome))
            {
                ObterClientes();
                return;
            }
            else
            {
                ListaClienteByNome(nome);
            }
         
        }

        public void ObterClientes()
        {
            ClienteRepository repository = new ClienteRepository();

            var listaCliente = repository.ObterListaCliente();

            if (listaCliente.Count > 0)
                gvCliente.DataSource = listaCliente;
            else
                gvCliente.DataSource = new List<Cliente>();

            gvCliente.DataBind();
        }

        public void ListaClienteByNome(string nome)
        {
            ClienteRepository repository = new ClienteRepository();

            if (string.IsNullOrEmpty(nome))
            {
                Response.Write("Digite um nome para consulta!.");
                return;
            }

            var listaNome = repository.ObterClienteByNome(nome);
            if (listaNome.Count > 0)
                gvCliente.DataSource = listaNome;
            else
                gvCliente.DataSource = new List<Cliente>();

                gvCliente.DataBind();
                
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                int codigo = Convert.ToInt32(e.CommandArgument.ToString());

                if (codigo > 0)
                    Response.Redirect("Cadastro.aspx?ID=" + codigo);
            }

            if(e.CommandName == "Deletar")
            {
                int codigo = Convert.ToInt32(e.CommandArgument.ToString());

                if (codigo > 0)
                    Response.Redirect("Cadastro.aspx?ID=" + codigo);
            }
        }
    }
}