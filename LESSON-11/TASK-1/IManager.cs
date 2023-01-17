using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal interface IManager : IConsultant
    {
        void DataChange(int selectedIndex, string dataToReplace, string newData);

        void AddClient();

    }
}
