using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;


namespace DAL
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _ctx;

        public TaskRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }

        public Task CreateTask(Task task)
        {
            _ctx.Attach(task).State = EntityState.Added;
            _ctx.SaveChanges();
            return task;
        }

        public Task DeleteTask(int id)
        {
            var taskDeleted = ReadTaskById(id);
            if (taskDeleted != null)
            {
                _ctx.Attach(taskDeleted).State = EntityState.Deleted;
                _ctx.SaveChanges();

            }

            return taskDeleted;
        }

        public IEnumerable<Task> ReadAllTasks()
        {
            return _ctx.Tasks.ToList();
        }

        public Task ReadTaskById(int id)
        {
            return _ctx.Tasks.FirstOrDefault(u => u.Id == id);
        }

        public Task UpdateTask(int id, Task task)
        {
            var TaskUpdated = ReadTaskById(id);
            if (TaskUpdated != null)
            {
                TaskUpdated.DueDate = task.DueDate;
                TaskUpdated.Assignee = task.Assignee;
                TaskUpdated.Description = task.Description;
                TaskUpdated.IsCompleted = task.IsCompleted;
                TaskUpdated.AssigneeId = task.AssigneeId;

                _ctx.Attach(TaskUpdated).State = EntityState.Modified;
                _ctx.SaveChanges();

            }

            return TaskUpdated;
        }
    }
}
