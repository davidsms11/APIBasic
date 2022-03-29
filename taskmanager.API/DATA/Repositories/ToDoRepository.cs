using MongoDB.Driver;
using System.Collections.Generic;
using taskmanager.API.DATA.Configurations;
using taskmanager.API.Models;

namespace taskmanager.API.DATA.Repositories
{
    public class ToDoRepository : IToDoRepository
    {

        private readonly IMongoCollection<ToDo> _toDoCollection;

        public ToDoRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient( databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _toDoCollection = database.GetCollection<ToDo>("ToDo");
        }

        public void Add(ToDo todo)
        {
            _toDoCollection.InsertOne(todo);
        }

        public void Update(string id, ToDo todoUpdate)
        {
            _toDoCollection.ReplaceOne(t => t.Id == id, todoUpdate );
        }

        public IEnumerable<ToDo> get()
        {
            return _toDoCollection.Find(t => true).ToList();
        }

        public ToDo get(string id)
        {
            return _toDoCollection.Find(t => t.Id == id).FirstOrDefault();
        }

        public void delete(string id)
        {
            _toDoCollection.DeleteOne(t => t.Id == id);
        }
    }
}
