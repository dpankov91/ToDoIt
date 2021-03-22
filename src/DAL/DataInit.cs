﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }



    }
}
