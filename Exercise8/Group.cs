using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    class Group
    {
        string[] subjects;
        string name;

        public Group(string[] subjects, string name)
        {
            this.subjects = subjects;
            this.name = name;
        }

        public string[] Subjects { get => subjects; set => subjects = value; }
        public string Name { get => name; set => name = value; }
    }
}
