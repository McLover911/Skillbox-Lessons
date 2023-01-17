using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal interface IConsultant
    {
        void ChangeThePhoneNumber(string textBoxNewNumber, int selectedIndex, string currentPhoneNumber, string fullName);
    }
}
