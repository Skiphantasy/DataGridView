/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


namespace Exercise8
{
    class Group
    {
        #region attributes
        string[] subjects;
        string name;
        #endregion
        #region constructor
        public Group(string[] subjects, string name)
        {
            this.subjects = subjects;
            this.name = name;
        }
        #endregion
        #region properties
        public string[] Subjects { get => subjects; set => subjects = value; }
        public string Name { get => name; set => name = value; }
        #endregion
    }
}
