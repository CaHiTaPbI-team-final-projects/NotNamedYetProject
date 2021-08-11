using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
namespace Server.ControlModels
{
    class ReceiptControl
    {
        private EDM edm;
        public void SetEDM(EDM edm)
        {
            this.edm = edm;
        }
        public void ADD_RECEIPT()
        { }

        public void DEL_RECEIPT()
        { }

        public void UPDATE_RECEIPT()
        { }
    }
}
