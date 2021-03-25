using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


namespace DAL
{
    public class DataInit
    {

        public void Seed(TodoContext ctx)
        {

            Assignee assignee1 = new Assignee()
            {
                Name = "Preben",
            };

            ctx.Assignees.Add(assignee1);


            Assignee assignee2 = new Assignee()
            {
                Name = "Emma",
            };

            ctx.Assignees.Add(assignee2);

            Assignee assignee3 = new Assignee()
            {
                Name = "Olivia",
            };

            ctx.Assignees.Add(assignee3);

            // Tasks

            Task task1 = new Task()
            {
                Description = "DevOps Project",
                DueDate = DateTime.Parse("10/03/2021")
            };
            ctx.Tasks.Add(task1);

            Task task2 = new Task()
            {
                Description = "FullStack Project",
                DueDate = DateTime.Parse("10/01/2021")
            };
            ctx.Tasks.Add(task2);

            Task task3 = new Task()
            {
                Description = "Android Project",
                DueDate = DateTime.Parse("10/02/2021")
            };
            ctx.Tasks.Add(task3);
            ctx.SaveChanges();
        }



    }
}
