using System;

namespace taskmanager.API.Models
{
    public class ToDo
    {
        public ToDo( string name, string description )
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            DatumRegister = DateTime.Now;
            DateEnd = null;
            IsCompleted = false;
           
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsCompleted { get; private set; }

        public DateTime DatumRegister { get; private set; }
            
        public DateTime? DateEnd { get; private set; }

        public void UpdateToDo(string name, string description, bool? isCompleted = false)
        {
            Name = name;
            Description=description;
            IsCompleted = isCompleted ?? false;

            if (IsCompleted)
            {
                DateEnd = DateTime.Now;
            }
            
        }
    }
}
