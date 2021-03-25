using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository ;
        }
        public Task CreateTask(Task task)
        {
            return _taskRepository.CreateTask( task);
        }

        public Task DeleteTask(int id)
        {
            if (id <= 0)
            {
                throw new NullReferenceException();
            }

            return _taskRepository.DeleteTask(id);
        }

        public List<Task> ReadAllTasks()
        {
            return _taskRepository.ReadAllTasks().ToList();
        }

        public Task ReadTaskById(int id)
        {
            return _taskRepository.ReadTaskById(id);
        }

        public Task UpdateTask(int id, Task task)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("id cannot be null or negative");
            }

            return _taskRepository.UpdateTask(id, task);

        }
        
    }
}
