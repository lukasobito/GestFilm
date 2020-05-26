using System;
using System.Collections.Generic;
using System.Text;

namespace GestFilm.Models.Data
{
    public class User
    {
        private int id;
        private string login;
        private string lastName;
        private string firstName;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public User(int id, string lastName, string firstName, string login)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Login = login;
        }
    }
}
