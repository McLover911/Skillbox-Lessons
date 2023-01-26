using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1.Employees.Consultant
{
    internal class ChangesHider : Changes
    {
        public new string TypeOfChanges
        {
            get { if (TypeOfChangedData == "Номер паспорта") return "Нет доступа";
                  else return _typeOfChanges; }
        }

        public ChangesHider() { }

        private ChangesHider(DateTime dateOfChanges,
                               string nameOfChangedPerson,
                               string typeOfChangedData,
                               string typeOfChanges,
                               string whoChanged)
        {
            _dateOfChange = dateOfChanges;
            _nameOfChangedPerson = nameOfChangedPerson;
            _typeOfChangedData = typeOfChangedData;
            _typeOfChanges = typeOfChanges;
            _whoChanged = whoChanged;
        }

        public override List<Changes> ReturnListOfChanges()
        {
            string[] changes = File.ReadAllLines(@"Tables\Logs.txt");
            string[] change;

            List<Changes> listOfChanges = new List<Changes>();

            for (int i = 0; i < changes.Length; i++)
            {
                change = changes[i].Split('#');

                listOfChanges.Add(new ChangesHider(DateTime.Parse(change[0]),
                                                   change[1],
                                                   change[2],
                                                   change[3],
                                                   change[4]));
            }
            return listOfChanges;
        }
    }
}
