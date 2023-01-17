using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    public class Changes
    {
        private DateTime _dateOfChange;
        private string _nameOfChangedPerson;
        private string _typeOfChangedData;
        private string _typeOfChanges;
        private string _whoChanged;

        public DateTime DateOfChange { get { return _dateOfChange; } }
        public string NameOfChangedPerson { get { return _nameOfChangedPerson; } }
        public string TypeOfChangedData { get { return _typeOfChangedData; } }
        public string TypeOfChanges { get { return _typeOfChanges; } }
        public string WhoChanged { get { return _whoChanged; } }

        public Changes(DateTime dateOfChanges,
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
       
    }
}
