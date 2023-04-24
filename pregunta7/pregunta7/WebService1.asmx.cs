using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace pregunta7
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public void InsertarPersona(string ci, string nombreCompleto, DateTime fechaNacimiento, string telefono, string departamento)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AQVJKSE\\SQLEXPRESS;Initial Catalog=mibaseyessid;User ID=yessid;Password=123456;"))
            {
                string query = "INSERT INTO PERSONA (ci, nombreCompleto, fechaNaci, telefono, departamento) VALUES (@ci, @nombreCompleto, @fechaNacimiento, @telefono, @departamento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ci", ci);
                    command.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@departamento", departamento);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        [WebMethod]
        public void EliminarPersona(string ci)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AQVJKSE\\SQLEXPRESS;Initial Catalog=mibaseyessid;User ID=yessid;Password=123456;"))
            {
                connection.Open();

                string query = "DELETE FROM PERSONA WHERE ci = @ci";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ci", ci);

                command.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void ActualizarPersona(string ci, string nombreCompleto, DateTime fechaNaci, string telefono, string departamento)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AQVJKSE\\SQLEXPRESS;Initial Catalog=mibaseyessid;User ID=yessid;Password=123456;"))
            {
                connection.Open();

                string query = "UPDATE PERSONA SET nombreCompleto = @nombreCompleto, fechaNaci = @fechaNaci, telefono = @telefono, departamento = @departamento WHERE ci = @ci";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ci", ci);
                command.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                command.Parameters.AddWithValue("@fechaNaci", fechaNaci);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@departamento", departamento);

                command.ExecuteNonQuery();
            }
        }

    }
}

