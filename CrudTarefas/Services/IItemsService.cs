using CrudTarefas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudTarefas.Services
{
    public interface IItemsService
    {
        List<Item> GetAllItems();
        void InsertItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
        bool ExistsItem(string name, string description, string priorityName);
    }
}
