<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Endereco.ascx.cs" Inherits="Treinamento.CRUD.Web.Site.UserControl.Endereco" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Formulário</h3>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblUF" runat="server" Text="UF"></asp:Label>
                    <asp:DropDownList ID="ddlUF" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
                    <asp:DropDownList ID="ddlCidade" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-xs-6">
                <div class="form-group">
                    <asp:Label ID="lblLogradouro" runat="server" Text="Logradouro"></asp:Label>
                    <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-xs-3">
                <div class="form-group">
                    <asp:Label ID="lblNumero" runat="server" Text="Numero"></asp:Label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-xs-3">
                <div class="form-group">
                    <asp:Label ID="lblCep" runat="server" Text="CEP"></asp:Label>
                    <asp:TextBox ID="txtCep" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>

