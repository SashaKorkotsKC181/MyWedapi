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
        public IEnumerable<MyList> GetAllLists()
        {
            return db.MyLists;
        }
        public MyTask AddTask(int id, MyTask model)
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
        public MyList AddList(MyList model)
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

        public IEnumerable<MyTask> GetAllTaskFromList(int id)
        {
            return db.MyTasks.Where(b => b.MyListId == id);
        }

        public MyList UpdateList(int id, MyList model)
        {
            model.MyListId = id;
            db.MyLists.Update(model);
            db.SaveChanges();
            return model;
        }
        public MyTask UpdateTask(int idl, int idt, MyTask model)
        {
            model.MyListId = idl;
            model.MyTaskId = idt;
            db.MyTasks.Update(model);
            db.SaveChanges();
            return model;
        }

        public MyList DeleteList(int id)
        {
            MyList deletedList = db.MyLists.Where(b => b.MyListId == id).Single();
            db.Remove(deletedList);
            db.SaveChanges();
            return deletedList;
        }
        public MyTask DeleteTask(int idl, int idt)
        {
            MyTask deletedList = db.MyTasks.Where(b => b.MyListId == idl && b.MyTaskId == idt).Single();
            db.Remove(deletedList);
            db.SaveChanges();
            return deletedList;
        }
    }

}