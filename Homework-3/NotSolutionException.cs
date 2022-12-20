using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    public class NotSolutionException : Exception
    {
        public enum Severity {Warning, Error}
        public NotSolutionException(string mesage) :base(mesage)
        {
           
        }
    }
}
