using System;
using System.Collections.Generic;
using System.Text;

namespace GestFilm.Models.Data
{
    public class Event
    {
        private int id;
        private string name;
        private string film;
        private DateTime dateEvent;
        private bool isFilmValid;
        private bool isDateValid;
        private int groupId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Film
        {
            get { return film; }
            set { film = value; }
        }

        public DateTime DateEvent
        {
            get { return dateEvent; }
            set { dateEvent = value; }
        }

        public bool IsFilmValid
        {
            get { return isFilmValid; }
            set { isFilmValid = value; }
        }

        public bool IsDateValid
        {
            get { return isDateValid; }
            set { isDateValid = value; }
        }

        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public Event(string name, string film, DateTime dateEvent, int groupId)
        {
            Name = name;
            Film = film;
            DateEvent = dateEvent;
            GroupId = groupId;
            IsDateValid = false;
            IsFilmValid = false;
        }

        public Event(int id, string name, string film, DateTime dateEvent, int groupId, bool isDateValid, bool isFilmValid)
            : this(name, film, dateEvent, groupId)
        {
            Id = id;
            IsDateValid = isDateValid;
            IsFilmValid = isFilmValid;
        }
    }
}
