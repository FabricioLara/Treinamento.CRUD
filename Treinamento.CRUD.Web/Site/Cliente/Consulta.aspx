<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Treinamento.CRUD.Web.Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h3>Consulta</h3>
    </div>
    <div class="form-group" style="margin-top: 10px;">
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control" Placeholder="Busca por Nome."></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-success" Text="Pesquisar" OnClick="btnConsultar_Click" />
            </div>
        </div>      
    </div>
    <asp:Panel ID="pnlContainerGrid" runat="server">
        <asp:GridView ID="gvCliente" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvCliente_RowCommand">
            <Columns>
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Nome" HeaderText="Nome do Cliente" />                
                <asp:TemplateField>
                    <HeaderTemplate>Acao</HeaderTemplate>
                    <HeaderStyle Width="40px" Wrap="true" />
                    <ItemTemplate>                      
                            <asp:LinkButton ID="lkbEditar" runat="server"
                                Text="Editar"
                                CommandName="Editar"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                            </asp:LinkButton>                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbDeletar" runat="server"
                            Text="Deletar"
                            CommandName="Deletar"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
