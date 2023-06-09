﻿using System;
using System.Web;
using System.Web.Security;
using Datapost.Access;
using System.Data;

namespace site
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            // https://www.connectionstrings.com/access
            string conexao = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={HttpContext.Current.Server.MapPath("~/App_Data/Usuarios.accdb")};Persist Security Info=False;";


            string sql = $"SELECT * FROM Usuarios WHERE NomeAcesso='{NomeAcesso.Text}' AND Senha='{Senha.Text}';";
            Response.Write($"<script>alert('{sql}')</script>");


            try
            {
                DAO data = new DAO();
                data.DataProviderName = DAO.ProviderName.OleDb;
                data.ConnectionString = conexao;

                DataTable tb = new DataTable();
                tb = (DataTable)data.Query(sql);


                // Se a Tabela tb contem uma linha significa que o usuário foi encontrado.  
                if (tb.Rows.Count == 1)
                {
                    // Cria a variavel de sessão para identificar que o usuário esta autenticado e
                    // permitir a exibição das opções do menu.
                    Session["autenticado"] = "";

                    // 1. Inicializa a classe de autenticação
                    FormsAuthentication.Initialize();

                    // 2. CRIAR O TICKET
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, tb.Rows[0]["NomeCompleto"].ToString(),
                    DateTime.Now, DateTime.Now.AddMinutes(20), false,
                    FormsAuthentication.FormsCookiePath);

                    // 3. CRIPTOGRAFA P TICKET E GRAVAR NO COOKIE DO NAVEGADOR
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ticket)));

                    // Redireciona para o form que o usuário tentou acessar
                    Response.Redirect(FormsAuthentication.GetRedirectUrl("Admin", false));
                }
                else
                {
                    Erro.Text = "Dados de acesso invalidos";
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "Erro ao tentar fazer Login " + ex.Message.ToString() , true);
            }
        }
    }
}