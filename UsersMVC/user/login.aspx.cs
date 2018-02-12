using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsersMVC.user
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                WorkDataBase user = new WorkDataBase();
                Guid userId = user.SearchUser(this.LoginForm.UserName, this.LoginForm.Password.GetHashCode());
                if (userId != Guid.Empty)
                {
                    CreateCookie(userId);
                    FormsAuthentication.RedirectFromLoginPage(userId.ToString(), false);
                    try { Response.Redirect(@"/user/Restricted/get.aspx"); } // так как Response всегда вызывает исключение
                    catch { }
                }
            }
            catch(Exception ex)
            {
                new Log().WriteException(ex, "Error login user");
            }
        }

        // создание куки файлов для последующей индификации пользователя в системе
        private void CreateCookie(Guid id)
        {
            HttpCookie cookie = new HttpCookie("User");
            cookie["Id"] = id.ToString();
            Response.Cookies.Add(cookie);
        }

        protected void ButtonToCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/user/create.aspx");
        }
    }
}