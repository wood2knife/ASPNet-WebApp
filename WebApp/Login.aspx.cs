using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Data.Common;
using System.Data;
using WebApp.Core;

namespace WebApp
{
    public partial class login : System.Web.UI.Page
    {

        private SqlConnection _sqlConnection = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(PasswordTextBox.Text));
            StringBuilder sb = new StringBuilder();
            foreach (var letter in hash)
            {
                sb.Append(letter.ToString("x"));
            }
            string getUserRole = $"SELECT TOP 1 UserID, ROLE FROM UsersCreds WHERE LOGIN = @login AND PASSWORD = @password";
            DataTable dataTableRole = DB.GetDataFromDB(getUserRole, new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = LoginTextBox.Text,
                    ParameterName= "@login",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                },
                new SqlParameter
                {
                    Value = sb.ToString(),
                    ParameterName= "@password",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                }
            });
            try
            {
                if (dataTableRole != null)
                {
                    var Curl = new UserSession();
                    Curl.Username = LoginTextBox.Text;
                    Curl.UserID = dataTableRole.Rows[0][0].ToString();
                    Curl.Role = dataTableRole.Rows[0][1].ToString();
                    UserSession.Current = Curl;
                    Response.Redirect("StudentsDB.aspx");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (_sqlConnection != null && _sqlConnection.State != ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }

            
        }
    }
}