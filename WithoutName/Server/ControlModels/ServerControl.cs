using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.EF;
using Server.Models;
using System.Runtime.Serialization.Formatters.Binary;
namespace Server.ControlModels
{
    public class ServerControl
    {
        #region Controls
        private EDM dolbaza;
        private AccountControl AccountControl;
        private CardControl CardControl;
        private CategoryControl CategoryControl;
        private CurrencyControl CurrencyControl;
        private ReceiptControl ReceiptControl;
        private TransactionControl TransactionControl;
        private UserControl UserControl;
        private WarrantyControl WarrantyControl;
        #endregion

        #region Set EDMS for controls
        public void SetEdms()
        {
            AccountControl.SetEDM(dolbaza);
            CardControl.SetEDM(dolbaza);
            CategoryControl.SetEDM(dolbaza);
            CurrencyControl.SetEDM(dolbaza);
            ReceiptControl.SetEDM(dolbaza);
            TransactionControl.SetEDM(dolbaza);
            UserControl.SetEDM(dolbaza);
            WarrantyControl.SetEDM(dolbaza);
        }
        #endregion

        public ServerControl()
        {
            dolbaza = new EDM();
            AccountControl = new AccountControl();
            CardControl = new CardControl();
            CategoryControl = new CategoryControl();
            CurrencyControl = new CurrencyControl();
            ReceiptControl = new ReceiptControl();
            TransactionControl = new TransactionControl();
            UserControl = new UserControl();
            WarrantyControl = new WarrantyControl();
            SetEdms();
        }

        public void Main(string request)
        {

            switch (request)
            {
                case "ADD_ACCOUNT":
                    break;
                case "DEL_ACCOUNT":
                    break;
                case "UPDATE_ACCOUNT":
                    break;
                case "ADD_CATEGORY":
                    break;
                case "DEL_CATEGORY":
                    break;
                case "UPDATE_CATEGORY":
                    break;
                case "ADD_CURENCY":
                    break;
                case "DEL_CURENCY":
                    break;
                case "UPDATE_CURENCY":
                    break;
                case "ADD_CARD":
                    break;
                case "DEL_CARD":
                    break;
                case "UPDATE_CARD":
                    break;
                case "ADD_RECEIPT":
                    break;
                case "DEL_RECEIPT":
                    break;
                case "UPDATE_RECEIPT":
                    break;
                case "ADD_WARRANTY":
                    break;
                case "DEL_WARRANTY":
                    break;
                case "UPDATE_WARRANTY":
                    break;
                case "ADD_USER":
                    break;
                case "DEL_USER":
                    break;
                case "UPDATE_USER":
                    break;
                case "ADD_TRANSACTION":
                    break;
                case "DEL_TRANSACTION":
                    break;
                case "UPDATE_TRANSCATION":
                    break;

            }
        }

        private List<string> UnpackRequest(string request)
        {
            return request.Split(';').ToList();
        }

        public decimal GETSTAT(int categoryId)
        {
            var opaList = dolbaza.Transactions.Where(x => x.CategoryId == categoryId).ToList();
            decimal res = 0;

            foreach (var item in opaList)
            {
                res += item.Amount;
            }

            return res;
        }     

    }
}