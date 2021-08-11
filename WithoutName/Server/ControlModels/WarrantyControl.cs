using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
namespace Server.ControlModels
{
    class WarrantyControl
    {
        private EDM edm;
        public void SetEDM(EDM edm)
        {
            this.edm = edm;
        }
        public void ADD_WARRANTY()
        { }

        public void DEL_WARRANTY()
        { }

        public void UPDATE_WARRANTY()
        { }
    }
}
