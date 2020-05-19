using System;
using System.Collections.Generic;
using System.Text;

namespace GestFilm.Models.Data
{
    public class Group
    {
		private int id;
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public Group(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public Group(string name)
		{
			this.name = name;
		}
	}
}
