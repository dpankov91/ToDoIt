using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interfaces
{
    public interface IAssigneeService
    {
        Assignee CreateAssignee(Assignee assignee);
        Assignee ReadById(int id);
        List<Assignee> ReadAll();
        Assignee UpdateAssignee(int id, Assignee assignee);
        Assignee DeleteAssignee(int id);
    }
}
