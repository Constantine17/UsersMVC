using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersMVC.user.Restricted
{
    public partial class get : System.Web.UI.Page
    {
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

                if (Page.IsPostBack) return;

                this.TextName.Text = userData.name;
                this.TextLastName.Text = userData.lastName;
                this.TextEmail.Text = userData.email;
                this.TextPhone.Text = userData.phone;
            }
            catch (Exception ex)
            {
                new Log().WriteException(ex, "Error get user date");
            }
        }

        protected void ButtonChangeData_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/user/Restricted/update.aspx");
        }
    }
}