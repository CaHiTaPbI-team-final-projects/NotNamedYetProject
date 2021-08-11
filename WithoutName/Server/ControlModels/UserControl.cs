using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
namespace Server.ControlModels
{
    class UserControl
    {
        private EDM edm;
        public void SetEDM(EDM edm)
        {
            this.edm = edm;
        }
        public void ADD_USER(string login, string password)
        {
            //dolbaza.Users.Add(new User() { Login = login, Password = password, Name = "default" });
        }

        public void DEL_USER()
        { }

        public void UPDATE_USER()
        { }

    }
}
