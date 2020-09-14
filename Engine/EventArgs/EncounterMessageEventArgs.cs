using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EventArgs
{
    public class EncounterMessageEventArgs : System.EventArgs
    {
        public string Message { get; private set; }
        public EncounterMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
