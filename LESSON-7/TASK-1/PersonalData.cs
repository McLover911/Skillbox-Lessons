using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_1
{
    public struct PersonalData
    {
        private string id;
        private string dateTime;
        private string fullName;
        private string age;
        private string growth;
        private string birthDate;
        private string birthPlace;

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public string Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Growth
        {
            get { return this.growth; }
            set { this.growth = value; }
        }

        public string BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public string BirthPlace
        {
            get { return this.birthPlace; }
            set { this.birthPlace = value; }
        }
    }
}
