using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudTarefas.Models
{
    [Table("Priorities")]
    public class Priority
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PriorityName { get; set; }
        public string PriorityColor { get; set; }
    }
}
