using System.Collections.Generic;
using ToDoList.Models;

namespace MyWedapi
{
    public class ToDoListsServices
    {

        Dictionary<int, Dictionary<int, MyTask>> listsOfTasks = new Dictionary<int, Dictionary<int, MyTask>>()
        {
            {1, new Dictionary<int, MyTask>(){
            {1 ,new MyTask() {Title ="make class"}},
            {2 ,new MyTask() {Title ="make struct"}}
            }},
            {2, new Dictionary<int, MyTask>(){
            {1 ,new MyTask() {Title ="make class"}},
            {2 ,new MyTask() {Title ="make struct"}}
            }},
        };
        public int lastIndex = 2;
        public Dictionary<int, Dictionary<int, MyTask>> GetAllLists()
        {
            return listsOfTasks;
        }
        public  IEnumerable<MyTask> GetAllFromList(int id)
        {
            return listsOfTasks[id].Values;
        }
        public MyTask GetFromListMyTask(int idl, int idt)
        {
            return listsOfTasks[idl][idt];
        }
        
        public MyTask AddTask(int id, MyTask model)
        {
            MyTask todoItem = new MyTask
            {
                /* Id = ++lastIndex, */
                Title = model.Title,
                Done = model.Done,
                Description = model.Description
            };
            listsOfTasks[id].Add(++lastIndex, todoItem);

            return todoItem;
        }
        public bool IsContainsId(int id)
        {
            return listsOfTasks.ContainsKey(id);
        }
        public Dictionary<int, MyTask> DeleteListById(int id)
        {
            Dictionary<int, MyTask> deleteTask = listsOfTasks[id];
            listsOfTasks.Remove(id);
            return listsOfTasks[id];
        }
    }

}