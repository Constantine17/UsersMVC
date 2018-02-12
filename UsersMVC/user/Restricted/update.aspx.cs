using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Security;

namespace UsersMVC.user.Restricted
{
    public partial class update : System.Web.UI.Page
    {
        private Guid userId; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Empty;
                if (Request.Cookies["User"] != null)
                {
                    string userSettings;
                    if (Request.Cookies["User"]["Id"] != null)
                    {
                        userSettings = Request.Cookies["User"]["Id"];
                        id = new Guid(userSettings);
                    }
                }
                else return;

                WorkDataBase getUser = new WorkDataBase();
                var userData = getUser.GetUserData(id);
                this.userId = id;

                if (Page.IsPostBack) return;

                this.TextName.Text = userData.name;
                this.TextLastName.Text = userData.lastName;
                this.TextEmail.Text = userData.email;
                this.TextPhone.Text = userData.phone;
            }
            catch (Exception ex)
            {
                new Log().WriteException(ex, "Error load page update");
            }
        }

        protected void ButtonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                UserData userData = new UserData();

                bool valideForm = true;
                userData.id = this.userId;
                userData.name = this.TextName.Text;
                userData.lastName = this.TextLastName.Text;
                userData.email = this.TextEmail.Text;
                userData.phone = this.TextPhone.Text;

                if (userData.name == "") { this.TextName.BorderColor = Color.Red; valideForm = false; }
                if (userData.lastName == "") { this.TextLastName.BorderColor = Color.Red; valideForm = false; }
                if (userData.phone == "") { this.TextPhone.BorderColor = Color.Red; valideForm = false; } 

                if (!valideForm)
                {
                    this.Message.Text = "*Не верно заполнены поля";
                    return;
                }

                WorkDataBase updateData = new WorkDataBase();
                updateData.UpdateUserData(userData);
                try { Response.Redirect(@"/user/Restricted/get.aspx"); } // так как Response всегда вызывает исключение
                catch { }
            }
            catch (Exception ex)
            {
                new Log().WriteException(ex, "Error save user date page update");
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/user/Restricted/get.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            new Log().WriteEvent("User singout", "id=" + userId);
        }
    }
}