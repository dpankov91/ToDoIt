using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;


namespace BLL
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IAssigneeRepository _assigneeRepository;
      
        public AssigneeService(IAssigneeRepository assigneeRepository )
        {
            _assigneeRepository = assigneeRepository ?? throw new NullReferenceException("Repo cannot be null"); ;
        }
        public Assignee CreateAssignee(Assignee assignee)
        {
            return _assigneeRepository.CreateAssignee(assignee);
        }

        public Assignee DeleteAssignee(int id)
        {

            if (id <= 0)
                throw new ArgumentNullException("id cannot be null or negative");

            return _assigneeRepository.DeleteAssignee(id);
        }

        public List<Assignee> ReadAll()
        {
            return _assigneeRepository.ReadAll().ToList();
        }

        public Assignee ReadById(int id)
        {
            return _assigneeRepository.ReadById(id);
        }

        public Assignee UpdateAssignee(int id, Assignee assignee)
        {

            if ( id <= 0)
                throw new ArgumentNullException("id cannot be null or negative");

            return _assigneeRepository.UpdateAssignee(id, assignee);
        }
    }
}
