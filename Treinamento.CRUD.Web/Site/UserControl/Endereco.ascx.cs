using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Treinamento.CRUD.Repository.Biz;

namespace Treinamento.CRUD.Web.Site.UserControl
{
    public partial class Endereco : System.Web.UI.UserControl
    {
        public int CodigoUF
        {
            get;
            set;
        }

        public int CodigoCidade
        {
            get;
            set;
        }

        public string Logradouro
        {
            get { return txtCep.Text; }
            set { txtCep.Text = value; }
        }
        public string Numero
        {
            get { return txtNumero.Text;  }
            set { txtNumero.Text = value;  }
        }
        public string CEP
        {
            get { return txtCep.Text; }
            set { txtCep.Text = value; }
        }

        private ListItem Selecione = new ListItem("-Selecione-", "0");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarComponentes();
                
            }
        }

        private void CarregarComponentes()
        {
            CarregaComboUF();
             int codigo = int.Parse(ddlUF.SelectedValue);

            CarregaComboCidade(codigo);
        }

        private void CarregaComboUF()
        {
            UFrepository ufRepo = new UFrepository();
            ddlUF.DataSource = ufRepo.ListaByUF();
            ddlUF.DataTextField = "Nome";
            ddlUF.DataValueField = "ID";
            ddlUF.DataBind();

            ddlUF.Items.Insert(0, Selecione);
        }

        private void CarregaComboCidade(int codigoUF)
        {
             
            if(codigoUF > 0)
            {
                CidadeReposistory cidadeRepo = new CidadeReposistory();
                ddlCidade.DataSource = cidadeRepo.ListaByCidade(codigoUF);
                ddlCidade.DataTextField = "Nome";
                ddlCidade.DataValueField = "ID";
                ddlCidade.DataBind();
            }
                
            ddlCidade.Items.Insert(0, Selecione);
        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaComboCidade(int.Parse(ddlUF.SelectedValue));
        }
    }
}