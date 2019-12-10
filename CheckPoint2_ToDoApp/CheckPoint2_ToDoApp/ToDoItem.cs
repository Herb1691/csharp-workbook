using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint2_ToDoApp
{
    public enum Flag { Pending, Done }
    class ToDoItem
    {
        public int Id { get; private set; }
        public String Status { get; set; }
        public String Description { get; set; }

        public ToDoItem (String Description)
        {
            this.Description = Description;
            this.Status = "Pending";
        }

        public ToDoItem(String Description, int Id)
        {
            this.Description = Description;
            this.Id = Id;
            this.Status = "Pending";
        }
    }
}
