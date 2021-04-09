using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace MyWedapi
{
    public class ToDoListsServices
    {

        TodoListsContext db;
        public ToDoListsServices(TodoListsContext context)
        {
            this.db = context;
        }
        internal IEnumerable<MyList> GetAllLists()
        {
            return db.MyLists;
        }        
        internal MyTask AddTask(int id, MyTask model)
        {
            MyTask todoItem = new MyTask
            {
                Title = model.Title,
                Done = model.Done,
                Description = model.Description,
                MyListId = id
            };

            db.MyTasks.Add(todoItem);
            db.SaveChanges();
            return todoItem;
        }

        internal DashboardDto GetTodayTasks()
        {            
            List<MyListWithCountDto> list = new List<MyListWithCountDto>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select l.my_list_id, l.title, Count(t.done) from my_tasks t right join my_lists l on l.my_list_id=t.my_list_id  where t.done=false group by l.my_list_id, l.title order by l.my_list_id";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        list.Add(new MyListWithCountDto()
                        {
                            Id = result.GetInt32(0),
                            Title = result.IsDBNull(1) ? null : result.GetString(1),
                            
                            CountOfNoDoneTasks = result.GetInt32(2)
                        });
                    }

                }
            }        

            DashboardDto outp = new DashboardDto()
            {
                CountOfToadyTasks = db.MyTasks.Where(b => b.DoDate.Value.Date == DateTime.Today.Date).Count(),
                MyListsNoDone = list
            };

            
            return outp;
        }

        internal MyTask GetTask(int idList, int idTask)
        {
            return db.MyTasks.Where(b => b.MyListId == idList && b.MyTaskId == idTask).Single();
        }

        internal MyList GetList(int id)
        {
            return db.MyLists.Where(b => b.MyListId == id).Single();
        }

        internal IEnumerable<MyTask> GetMyListsWithTasks()
        {
            return db.MyTasks.Where(b => b.DoDate.Value.Date == DateTime.Today.Date).Include(b => b.MyList);
        }

        internal MyList AddList(MyList model)
    {
        MyList todoList = new MyList
        {
            Title = model.Title,
            Tasks = model.Tasks
        };
        db.MyLists.Add(todoList);
        db.SaveChanges();
        return todoList;
    }

    internal IEnumerable<MyTask> GetAllTaskFromList(int id, bool isAll)
    {
        if (isAll)
        {
            return db.MyTasks.Where(b => b.MyListId == id && b.Done == false);
        }
        else
        {
            return db.MyTasks.Where(b => b.MyListId == id);
        }
    }

    internal MyList UpdateList(int id, MyList model)
    {

        MyList oldList = this.GetList(id);
        oldList.MyListId = id;
        if (model.Title != null)
        {
            oldList.Title = model.Title;
        }
        if (model.Tasks != null)
        {
            oldList.Tasks = model.Tasks;
        }
        db.MyLists.Update(oldList);
        db.SaveChanges();
        return oldList;
    }
    internal MyTask UpdateTask(int idl, int idt, MyTask model)
    {
        MyTask oldTask = this.GetTask(idl, idt);
        oldTask.MyListId = idl;
        oldTask.MyTaskId = idt;
        if (model.Title != null)
        {
            oldTask.Title = model.Title;
        }
        if (model.Description != null)
        {
            oldTask.Description = model.Description;
        }
        if (model.DoDate != null)
        {
            oldTask.DoDate = model.DoDate;
        }
        if (model.Done != false)
        {
            oldTask.DoDate = model.DoDate;
        }
        db.MyTasks.Update(oldTask);
        db.SaveChanges();
        return oldTask;
    }

    internal MyList DeleteList(int id)
    {
        MyList deletedList = db.MyLists.Where(b => b.MyListId == id).Single();
        db.Remove(deletedList);
        db.SaveChanges();
        return deletedList;
    }
    internal MyTask DeleteTask(int idl, int idt)
    {
        MyTask deletedList = db.MyTasks.Where(b => b.MyListId == idl && b.MyTaskId == idt).Single();
        db.Remove(deletedList);
        db.SaveChanges();
        return deletedList;
    }
}

}