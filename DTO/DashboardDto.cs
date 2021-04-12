using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public class DashboardDto
    {
        public int CountOfToadyTasks { get; set; }
        public List<MyListWithCountDto> MyListsNoDone { get; set; }
    }
}