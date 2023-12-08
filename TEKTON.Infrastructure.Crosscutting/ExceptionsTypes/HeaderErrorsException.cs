using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Infrastructure.Crosscutting.ExceptionsTypes
{
    public class HeaderErrorsException : Exception
    {
        public List<string> ErrorsMessages { get; set; }

        public HeaderErrorsException(List<string> errorsMessages)
        {
            ErrorsMessages = errorsMessages;
        }
    }
}
