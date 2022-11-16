using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal interface IManager
    {
        void AddClient();

        void ChangeSurname();
        void ChangeName();
        void ChangePatronymic();
        void ChangePhoneNumber();
        void ChangePassportID();
    }
}
