using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        string q = "select * from usuarios where us_clave = '" + us_usuario.Value.ToString() + "'";
        if (Conexion.SqlExecute(q ).Rows.Count>0 )
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario registrado previamente');", true);
            rbtAcepto.Checked = false;
            us_usuario.Value = "";
            us_password.Value = "";
        }
        else
        {
            
            if(!rbtAcepto.Checked || us_password.Value.Length <=4 || us_usuario.Value.Length <=0 )
            {
                if (!rbtAcepto.Checked)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Debes aceptar los términos y condiciones');", true);
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario o contraseña demasiado corto (mínimo 5 caracteres) ');", true);
                }
                    
            }
            else
            {
                q = "insert into usuarios select '" + us_usuario.Value.ToString() + "','" + us_password.Value.ToString() + "','N/A','1'";
                Conexion.SqlExecute(q);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario registrado correctamente, mantente al pendiente de las novedades con el DOF.');", true);
               rbtAcepto.Checked = false;
                us_usuario.Value = "";
                us_password.Value = "";

            }
            
        }
 
        
    }

}