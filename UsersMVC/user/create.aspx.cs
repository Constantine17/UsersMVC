using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UsersMVC.user
{
    public partial class create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSendData_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData();
            if (this.TextPassword1.Text == this.TextPassword2.Text)
            {
                userData.name = this.TextName.Text;
                userData.lastName = this.TextLastName.Text;
                userData.email = this.TextEmail.Text;
                userData.phone = this.TextPhone.Text;
                userData.password = this.TextPassword1.Text.GetHashCode();
                WorkDataBase o = new WorkDataBase();

                o.NonExistEmail(userData);
            }
        }
    }
}