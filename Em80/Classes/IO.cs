using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public static partial class EmulatedSystem 
    {
        public static class io
        {
            public delegate void IOEventHandler(byte port);
            public static event IOEventHandler Output;
            public static event IOEventHandler Input;

            public static void o(byte port)
            {
                if (Output != null) Output(port);
            }

            public static void i(byte port)
            {
                cpu.registers.a = 0xff;
                if (Input != null) Input(port);
            }
        }
    }
}
