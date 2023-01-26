using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    internal class Changes : Client
    {
        private protected DateTime _dateOfChange;
        private protected string _nameOfChangedPerson;
        private protected string _typeOfChangedData;
        private protected string _typeOfChanges;
        private protected string _whoChanged;

        public DateTime DateOfChange { get { return _dateOfChange; } }
        public string NameOfChangedPerson { get { return _nameOfChangedPerson; } }
        public string TypeOfChangedData { get { return _typeOfChangedData; } }
        public string TypeOfChanges { get { return _typeOfChanges; } }
        public string WhoChanged { get { return _whoChanged; } }

        public Changes() { }
        private Changes(DateTime dateOfChanges,
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

        /// <summary>
        /// Сохраняет данные об изменении клиента
        /// </summary>
        /// <param name="nameOfPerson"> Чьи данные изменяются </param>
        /// <param name="typeOfChangedData"> Какие данные изменяются </param>
        /// <param name="typeOfChanges"> Как изменились данные </param>
        /// <param name="whoChanged"> Кто изменил данные </param>
        public void SaveChanges(string nameOfPerson, string typeOfChangedData, string typeOfChanges, string whoChanged)
        {
            Changes changes = new Changes(DateTime.Now, nameOfPerson, typeOfChangedData, typeOfChanges, whoChanged);
            
            string Log = changes.DateOfChange.ToString() + '#' +
                         changes.NameOfChangedPerson + '#' +
                         changes.TypeOfChangedData + '#' +
                         changes.TypeOfChanges + '#' +
                         changes.WhoChanged + "\n";

            File.AppendAllText(@"Tables\Logs.txt", Log);
        }

        /// <summary>
        /// Возвращает список изменений
        /// </summary>
        /// <returns> Список изменений </returns>
        public virtual List<Changes> ReturnListOfChanges()
        {
            string[] changes = File.ReadAllLines(@"Tables\Logs.txt");
            string[] change;

            List<Changes> listOfChanges = new List<Changes>();

            for (int i = 0; i < changes.Length; i++)
            {
                change = changes[i].Split('#');

                listOfChanges.Add(new Changes(DateTime.Parse(change[0]),
                                             change[1],
                                             change[2],
                                             change[3],
                                             change[4]));
            }
            return listOfChanges;
        }
    }
}
