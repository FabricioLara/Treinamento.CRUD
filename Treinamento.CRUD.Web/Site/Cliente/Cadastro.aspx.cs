using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Treinamento.CRUD.Dominio.Entidade;
using Treinamento.CRUD.Dominio.Enum;
using Treinamento.CRUD.Repository.Biz;


namespace Treinamento.CRUD.Web
{
    public partial class Cadastro : System.Web.UI.Page
    {
        private int codigo = 0;
        public OperacaoCrud opcao;

        public int IDCliente
        {

            get
            {
                int.TryParse(Request.QueryString["ID"], out codigo);
                return codigo;
            }
            set
            {
                if (value > 0)
                    codigo = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (IDCliente > 0)
                {
                    CarregarFormulario(IDCliente);
                    ExibirBotoes(false, true, true, true);
                    ExibirMensagemAlerta(false, false, false, null, null, null);
                    return;
                }
            }

            ExibirBotoes(true, false, false, false);
            HabilitarEDesabilitarCampos(false);
            ExibirMensagemAlerta(false, false, false, null, null, null);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDCliente == 0)
                    opcao = OperacaoCrud.Cadastrar;
                else
                    opcao = OperacaoCrud.Atualizar;

                if (opcao == OperacaoCrud.Cadastrar)
                {
                    bool isCadastrado = false;

                    Cliente cliente = new Cliente();
                    cliente.CPF = txtCPF.Text;
                    cliente.Nome = txtNome.Text;
                    cliente.Telefone = txtTelefone.Text;
                    cliente.UF = new UF() { ID = Endereco.CodigoUF };
                    cliente.Cidade = new Cidade() { ID = Endereco.CodigoCidade };
                    cliente.Logradouro = Endereco.Logradouro;
                    cliente.Numero = Endereco.Numero;
                    cliente.CEP = Endereco.CEP;

                    ClienteRepository repository = new ClienteRepository();

                    if (cliente != null)
                        isCadastrado = repository.Inserir(cliente);

                    LimparCampos();

                    if (isCadastrado)
                        ExibirMensagemAlerta(true, false, false, "Cliente Cadastrado Com Sucesso!.", null, null);
                    else
                        ExibirMensagemAlerta(false, true, false, null, "Cliente Não Cadastrado.", null);
                   
                }
                else if (opcao == OperacaoCrud.Atualizar)
                {
                    ExibirBotoes(false, true, true, true);

                    ClienteRepository repository = new ClienteRepository();

                    if (IDCliente == 0)
                    {
                        ExibirMensagemAlerta(false, false, true,null,null, "Por favor, O ID do cliente não pode ser 0");
                        return;
                    }
                    else
                    {
                        Cliente cliente = repository.ObterClienteByCodigo(IDCliente);

                        cliente.Nome = txtNome.Text;
                        cliente.CPF = txtCPF.Text;
                        cliente.Telefone = txtTelefone.Text;
                        cliente.UF = new UF() { ID = Endereco.CodigoUF };
                        cliente.Cidade = new Cidade() { ID = Endereco.CodigoCidade };
                        cliente.Logradouro = Endereco.Logradouro;
                        cliente.Numero = Endereco.Numero;
                        cliente.CEP = Endereco.CEP;

                        bool isAtualizar = repository.Atualizar(cliente);
                        LimparCampos();

                        if (isAtualizar)
                            ExibirMensagemAlerta(true, false, false, "Cliente Atualizado com Sucesso.", null, null);
                        else
                            ExibirMensagemAlerta(false, true, false, "Cliente Não Atualizado", null, null);

                        Response.Redirect("Cadastro.aspx");
                    }                   
                }
            }
            catch (Exception ex)
            {
                lblTextAlertDanger.Text = ex.Message;
                ExibirMensagemAlerta(false, true, false, null, ex.Message, null);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            HabilitarEDesabilitarCampos(true);
            ExibirBotoes(true, false, false, true);    
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            HabilitarEDesabilitarCampos(false);
            ExibirBotoes(false, true, false, true);
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            HabilitarEDesabilitarCampos(false);
            ExibirBotoes(false, false, true, false);
            opcao = OperacaoCrud.Deletar;

            if (opcao == OperacaoCrud.Deletar)
            {
                ClienteRepository repository = new ClienteRepository();

                if (IDCliente == 0)
                {
                    ExibirMensagemAlerta(false, false, true, null, null, "Por favor, O ID do cliente não pode ser 0");
                    return;
                }
                else
                {
                    HabilitarEDesabilitarCampos(false);
                    bool isDeletar = repository.Deletar(IDCliente);

                    if (isDeletar)
                        ExibirMensagemAlerta(true, false, false, "Cliente Deletado com Sucesso.", null, null);
                    else
                        ExibirMensagemAlerta(false, true, false, "Cliente Não Deletado", null, null);

                    Response.Redirect("Cadastro.aspx");
                }
            }
        }

        public void ExibirMensagemAlerta(bool sucesso, bool error, bool informa, string msgSucesso , string msgError, string msgInforma)
        {

            if (sucesso)
            {
                pnlmsgSucesso.Visible = sucesso;
                lblTextAlertSuccess.Text = msgSucesso;
            }
            else if (error)
            {
                pnlMsgError.Visible = error;
                lblTextAlertDanger.Text = msgError;
            }
            else if(informa){
                pnlMsgInforma.Visible = informa;
                lblTextAlertInforma.Text = msgInforma;
            }
            else
            {
                pnlmsgSucesso.Visible = sucesso;
                lblTextAlertSuccess.Text = "";

                pnlMsgError.Visible = error;
                lblTextAlertDanger.Text = "";

                pnlMsgInforma.Visible = informa;
                lblTextAlertInforma.Text = "";
            }

        }

        public void ExibirBotoes(bool isCadastrar, bool isAtualizar, bool isDeletar, bool isSalvar)
        {

            btnCadastrar.Enabled = isCadastrar;
            btnAtualizar.Enabled = isAtualizar;
            btnDeletar.Enabled = isDeletar;
            btnSalvar.Enabled = isSalvar;
        }

        public void CarregarFormulario(int codigo)
        {

            ClienteRepository repository = new ClienteRepository();
            Cliente cliente = repository.ObterClienteByCodigo(codigo);

            if (cliente != null)
            {
                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;
                txtTelefone.Text = cliente.Telefone;
                Endereco.CodigoUF = cliente.UF.ID;
                Endereco.CodigoCidade = cliente.Cidade.ID;
                Endereco.Logradouro = cliente.Logradouro;
                Endereco.Numero = cliente.Numero;
                Endereco.CEP = cliente.CEP;
            }
        }

        public void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            Endereco.Logradouro = "";
        }

        public void HabilitarEDesabilitarCampos(bool isHabilita)
        {
            txtNome.Enabled = isHabilita;
            txtCPF.Enabled = isHabilita;
            txtTelefone.Enabled = isHabilita;
            Endereco.EnableViewState = isHabilita;
        }


    }
}