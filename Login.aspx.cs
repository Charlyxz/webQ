using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        string user = us_usuario.Value.ToString();
        string pass = us_password.Value.ToString();


        DataTable u = Conexion.SqlExecute("select * from usuarios where us_clave = '" + user + "' and us_pass = '" + pass + "' ");
        HttpCookie cogeCookie = Request.Cookies.Get("Usuario");
        
        if (u.Rows.Count > 0)
        {

            if (cogeCookie == null)
            {

                HttpCookie addCookie = new HttpCookie("Usuario", user);
                Response.Cookies.Add(addCookie);
                cogeCookie = addCookie;
            }
            else
            {
                cogeCookie.Value = user;
                Response.Cookies.Set(cogeCookie);
            }

            Response.Redirect("Default.aspx");


        }
        else
        {

            
              
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario o contraseña incorrectos, intente de nuevo');", true);
        }
    }
}