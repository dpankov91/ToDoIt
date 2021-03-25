using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace DAL
{
    public class AssigneeRepository : IAssigneeRepository
    {
        private readonly TodoContext _ctx;

        public AssigneeRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public Assignee CreateAssignee(Assignee assignee)
        {
            _ctx.Attach(assignee).State = EntityState.Added;
            _ctx.SaveChanges();
            return assignee;
        }

        public Assignee DeleteAssignee(int id)
        {
            var AssigneeDeleted = ReadById(id);
            if (AssigneeDeleted != null)
            {
                _ctx.Attach(AssigneeDeleted).State = EntityState.Deleted;
                _ctx.SaveChanges();
               
            }
            return AssigneeDeleted;
        }

        public IEnumerable<Assignee> ReadAll()
        {
            return _ctx.Assignees;
        }

        public Assignee ReadById(int id)
        {
            return _ctx.Assignees.FirstOrDefault(u => u.Id == id);
        }

        public Assignee UpdateAssignee(int id, Assignee AssigneeToUpdate)
        {
            var AssigneeUpdated = ReadById(id);
            if (AssigneeUpdated != null)
            {
                AssigneeUpdated.Name = AssigneeToUpdate.Name;
                _ctx.Attach(AssigneeUpdated).State = EntityState.Modified;
                _ctx.SaveChanges();
                
            }
            return AssigneeUpdated;
        }
    }
}
