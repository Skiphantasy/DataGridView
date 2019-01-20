/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using System.Collections.Generic;


namespace Exercise8
{
    class Student
    {
        #region attributes
        string name;
        List<float> marks;
        #endregion
        #region constructor
        public Student(string name, List <float> marks)
        {
            this.name = name;
            this.marks = marks;
        }
        #endregion
        #region properties
        public string Name { get => name; set => name = value; }
        public List<float> Marks { get => marks; set => marks = value; }
        #endregion
    }
}
