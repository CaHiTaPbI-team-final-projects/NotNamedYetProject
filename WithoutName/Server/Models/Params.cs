using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    [Serializable]
    public class Params
    {
        public object ClassForSend { get; set; }
        public string Command { get; set; }
    }
}
