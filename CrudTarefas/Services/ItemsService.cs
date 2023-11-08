using CrudTarefas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrudTarefas.Services
{
    public class ItemsService : IItemsService
    {
        private SQLiteConnection _connection;

        public ItemsService()
        {
            SetupDb();
        }

        private void SetupDb()
        {
            if(_connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemsDb.db3");

                _connection = new SQLiteConnection(dbPath);
                _connection.CreateTable<Item>();
                _connection.CreateTable<Priority>();
            }
        }

        public void InsertItem(Item item)
        {
            _connection.Insert(item);
        }

        public void UpdateItem(Item item)
        {
            _connection.Update(item);
        }

        public void DeleteItem(int id)
        {
            _connection.Delete(id);
        }

        public List<Item> GetAllItems()
        {
            var items = _connection.Table<Item>().ToList();
            return items;
        }

        public bool ExistsItem(string name, string description, string priorityName)
        {
            var existsItem = _connection.Table<Item>().FirstOrDefault(it => it.Name == name && it.Description == description 
            && it.ItemPriority.PriorityName == priorityName);
            return existsItem != null;
        }

    }
}
