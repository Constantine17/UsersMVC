using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Security;


namespace UsersMVC.user
{
    public partial class create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = new HttpCookie("User");
            cookie["username"] = "fistuser";
            Response.Cookies.Add(cookie);


            if (Request.Cookies["User"] != null)
            {
                string userSettings;
                if (Request.Cookies["User"]["username"] != null)
                { userSettings = Request.Cookies["User"]["username"]; }
            }
            /*
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket("user", true, 10);
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);
            Response.End();

            var gg = Request.Cookies;
            var ga = FormsAuthentication.Decrypt(FormsAuthentication.FormsCookieName);
            */
            /*
            tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
      DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (chkPersistCookie.Checked)
                ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);

            string strRedirect;
            strRedirect = Request["ReturnUrl"];
            if (strRedirect == null)
                strRedirect = "default.aspx";
            Response.Redirect(strRedirect, true);*/
        }

        protected void ButtonSendData_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData();

            // проверка зополнения полей {
            bool valideForm = true;
            userData.name = this.TextName.Text;
            userData.lastName = this.TextLastName.Text;
            userData.email = this.TextEmail.Text;
            userData.phone = this.TextPhone.Text;

            if (userData.name == "") { this.TextName.BorderColor = Color.Red; valideForm = false; }
            if (userData.lastName == "") { this.TextLastName.BorderColor = Color.Red; valideForm = false; }
            if (userData.email == "") { this.TextEmail.BorderColor = Color.Red; valideForm = false; } // проверить email
            if (userData.phone == "") { this.TextPhone.BorderColor = Color.Red; valideForm = false; } // перевести телефон в международный формат

            if (!valideForm) {
                this.Message.Text = "*Зполните, пожайлуста, все поля.";
                return;
            }
            //}

            // провека совпадения паролей
            if (this.TextPassword1.Text == this.TextPassword2.Text || this.TextPassword1.Text != "")
            {
                userData.password = this.TextPassword1.Text.GetHashCode();
                WorkDataBase o = new WorkDataBase();

                o.NonExistEmail(userData);
            }
            else {
                this.Message.Text = "*Пароли не совпадают";
                this.TextPassword1.Text = "";
                this.TextPassword2.Text = "";

                return;
            }

            //FormsAuthentication.g
        }

        protected void TextName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}