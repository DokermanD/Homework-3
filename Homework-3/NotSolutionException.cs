using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class NotSolutionException : Exception
    {
        public NotSolutionException(string mesage) :base(mesage)
        {
        
        }
    }
}
