using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudTarefas.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ManyToOne]
        public Priority ItemPriority { get; set; }
        
    }
}
