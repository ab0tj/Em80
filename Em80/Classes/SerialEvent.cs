using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public class SerialEventArgs : EventArgs
    {
        public int port;
        public byte data;
    }
}
