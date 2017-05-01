<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Treinamento.CRUD.Web.Cadastro" %>

<%@ Register Src="~/Site/UserControl/Endereco.ascx" TagPrefix="uc1" TagName="Endereco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="page-header">
        <h3>Cadastro de Cliente</h3>
    </div>

    <div class="row">
        <div class="col-md-12">

            <div class="form-group">
                <asp:Label ID="lblNome" runat="server">Nome</asp:Label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCPF" runat="server">CPF</asp:Label>
                <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" MaxLength="14"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblTelefone" runat="server">Telefone</asp:Label>
                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
            </div>

            <uc1:Endereco runat="server" ID="Endereco" />

            <%--<div class="form-group">
                <asp:Label ID="lblEndereco" runat="server">Endereço</asp:Label>
                <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control"></asp:TextBox>
            </div>--%>
        </div>
        <div class="col-md-11">
            <div class="form-group">
                <asp:Button ID="btnCadastrar" runat="server" CssClass="btn btn-success" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnAtualizar" runat="server" CssClass="btn btn-info" Text="Confirma Edição" OnClick="btnAtualizar_Click" />
                <asp:Button ID="btnDeletar" runat="server" CssClass="btn btn-danger" Text="Deletar" OnClick="btnDeletar_Click" />
            </div>
        </div>
        <div class="col-md-1">
            <div class="form-group">
                <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-info" Text="Salvar" OnClick="btnSalvar_Click" />
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlmsgSucesso" runat="server">
                <div class="alert alert-success" id="success-alert" role="alert">
                    <strong>Sucesso!</strong>
                    <asp:Label ID="lblTextAlertSuccess" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="pnlMsgInforma" runat="server">
                <div class="alert alert-info" id="info-alert" role="alert">
                    <strong>Informa!</strong>
                    <asp:Label ID="lblTextAlertInforma" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
        </div>
        <div class="col-md-12">
            <asp:Panel ID="pnlMsgError" runat="server">
                <div class="alert alert-danger" id="danger-alert" role="alert">
                    <strong>Falha!</strong>
                    <asp:Label ID="lblTextAlertDanger" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script type="text/javascript" src="../../Scripts/mensagensAlerta.js"></script>

</asp:Content>
