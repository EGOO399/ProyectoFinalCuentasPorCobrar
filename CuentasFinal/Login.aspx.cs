using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuentasFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Sirve para poner la cadena de conexion creada con sql server y la instancia
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-CJGOUMHV;initial catalog=prueba;
Integrated Security=True;"))


            {

                //Abre la conexion de Base de Datos

                sqlCon.Open();

                //Hace una query para seleccionar el nombre de usuario y la clave
                string query = "SELECT COUNT(1) FROM usuario WHERE username=@username AND password=@password";

                //ejecuta la query
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                //Valida si es lo que tiene los textbox si son iguales o no a lo que esta seleccionando
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                //ejecuta comparacion
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    //valida si el usuario es igual al texto nos manda a Index
                    Session["username"] = txtUserName.Text.Trim();
                    //Response.Redirect("~/ Index.html");
                    Response.Redirect("~/Home/Index");


                }
                else { lblErrorMessage.Visible = true; }
            }



        }
    }
}