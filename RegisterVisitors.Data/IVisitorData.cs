using RegisterVisitors.Core;
using System.Collections.Generic;
using System.Text;

namespace RegisterVisitors.Data
{
    public interface IVisitorData
    {
        IEnumerable<Visitor> GetVisitorByDate(string date);
        IEnumerable<Visitor> GetVisitorByName(string name);
        Visitor GetById(int id);
        Visitor Add(Visitor newVisitor);
        Visitor Update(Visitor updatedVisitor);
        Visitor Delete(int id);
        int Commit();
    }
}
