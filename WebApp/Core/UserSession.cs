using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;


namespace WebApp.Core
{
    public class UserSession
    {
        public string Username { get; set; }
        public string UserID { get; set; }
        public string Role { get; set; }
        public UserSession()
        {
            Username = "default";
        }
        public static UserSession Current
        {
            get
            {
                UserSession session = (UserSession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new UserSession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
            set
            {
                HttpContext.Current.Session["__MySession__"] = value;
            }
        }

    }
}