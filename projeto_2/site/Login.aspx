﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="site.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row margin-top-60">
        <div class="col-3">
            <div class="box padding-20">
                <h1>Entrar</h1>
                <br />
                <br />
                <asp:Label ID="Msg" runat="server"></asp:Label>
                <br />
                <label>NOME DE ACESSO</label>
                <asp:TextBox ID="NomeAcesso" runat="server"></asp:TextBox>
                <label>SENHA</label>
                <asp:TextBox ID="Senha" TextMode="Password"
                    runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Erro" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Entrar" OnClick="Entrar_Click"
                    runat="server" Text="Entrar" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
