using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Infrastructure.Crosscutting.Resources;

namespace TEKTON.Infrastructure.Crosscutting.ExceptionsTypes
{
    public class NotFoundException : Exception
    {
        private string _errorMessage;
        public NotFoundException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public NotFoundException()
        {
            _errorMessage = Messages.NotFoundResource;
        }

        public override string Message
        {
            get
            {
                return _errorMessage;
            }
        }
    }
}
