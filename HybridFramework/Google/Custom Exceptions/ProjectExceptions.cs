using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Custom_Exceptions
{
    internal class ProjectExceptions : Exception
    {
        public List<string> CustomMessages = new List<string>();

        public ProjectExceptions(string message) : base(message)
        {
            CustomMessages.Add(message);

        }
    }
}
