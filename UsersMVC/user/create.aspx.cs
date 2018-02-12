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
        }

        protected void ButtonSendData_Click(object sender, EventArgs e)
        {
            try
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
                if (userData.email == "") { this.TextEmail.BorderColor = Color.Red; valideForm = false; }
                if (userData.phone == "") { this.TextPhone.BorderColor = Color.Red; valideForm = false; } 

                if (!valideForm)
                {
                    this.Message.Text = "*Зполните, пожайлуста, все поля.";
                    return;
                }
                //}

                // провека совпадения паролей
                if (this.TextPassword1.Text == this.TextPassword2.Text && this.TextPassword1.Text != "")
                {
                    userData.password = this.TextPassword1.Text.GetHashCode();
                    WorkDataBase insertUser = new WorkDataBase();

                    Guid id = insertUser.NonExistEmail(userData);
                    if (id == Guid.Empty)
                    {
                        this.Message.Text = "*Данный Email уже используеться";
                        return;
                    }
                    CreateCookie(id);
                    FormsAuthentication.RedirectFromLoginPage(id.ToString(), false);
                    Response.Redirect(@"/user/Restricted/get.aspx");
                    //Server.Transfer("user/get.aspx");
                }
                else
                {
                    this.Message.Text = "*Пароли не совпадают";
                    this.TextPassword1.Text = "";
                    this.TextPassword2.Text = "";

                    return;
                }
            }
            catch(Exception ex) {
                new Log().WriteException(ex, "Error create user");
            }
        }

        // создание куки файлов для последующей индификации пользователя в системе
        private void CreateCookie(Guid id)
        {
            HttpCookie cookie = new HttpCookie("User");
            cookie["Id"] = id.ToString();
            Response.Cookies.Add(cookie);
        }

        protected void TextName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextPhone_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/user/login.aspx");
        }
    }
}