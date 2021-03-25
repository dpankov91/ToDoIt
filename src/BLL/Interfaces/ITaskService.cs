using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


namespace BLL.Interfaces
{
    public interface ITaskService
    {
        Task CreateTask(Task task);
        Task ReadTaskById(int id);
        List<Task> ReadAllTasks();
        Task UpdateTask(int id, Task task);
        Task DeleteTask(int id);
    }
}
