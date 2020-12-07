using System;
using System.Collections.Generic;
using System.Text;

namespace UsersEntities
{
    public class User
    {
        private int id;
        public int Id
        {
            get => id;
            set { if (value > 0) id = value; }
        }
        private string name;
        public string Name
        {
            get => name;
            set { name = value; }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set {if(value < DateTime.Now) dateOfBirth = value; }
        }
        public int Age => (int)(DateTime.Now - dateOfBirth).TotalDays / 365;
        public User()
        {
            name = "";
            dateOfBirth = new DateTime(1990,01,01);
        }
        public User(string _name, DateTime _dateOfBirth)
        {
            name = _name;
            if(_dateOfBirth > new DateTime(1900,01,01)) dateOfBirth = _dateOfBirth;
            else dateOfBirth = new DateTime(1990, 01, 01);
        }
        private HashSet<string> awards = new HashSet<string>();
        public bool AddAward(string value)
        {
            if (awards.Add(value)) return true;
            else return false;
        }
        public string GetAwards()
        {
            StringBuilder AwardsToString = new StringBuilder();
            foreach(string item in awards)
            {
                AwardsToString.Append($"{item} ");
            }
            return AwardsToString.ToString();
        }
        public override string ToString()
        {
            return $"{id} {name} {dateOfBirth.ToString("yyyy,MM,dd")} {Age} {GetAwards()}";
        }
    }
}
