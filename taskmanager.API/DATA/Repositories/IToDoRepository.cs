using System.Collections.Generic;
using taskmanager.API.Models;

namespace taskmanager.API.DATA.Repositories
{
    public interface IToDoRepository
    {
        void Add(ToDo todo);

        void Update( string id, ToDo todoUpdate);

        IEnumerable<ToDo> get();

        ToDo get(string id);

        void delete(string id);


    }
}
