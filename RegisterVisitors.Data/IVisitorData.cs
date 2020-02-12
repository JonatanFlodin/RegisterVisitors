using RegisterVisitors.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegisterVisitors.Data
{
    public interface IVisitorData
    {
        IEnumerable<Visitor> GetVisitorByDate(string date);
        IEnumerable<Visitor> GetVisitorByName(string name);
        Visitor GetById(int id);
        Visitor Add(Visitor newVisitor);
        Visitor Update(Visitor updatedVisitor);
        int Commit();
    }

    public class InMemoryVisitorData : IVisitorData
    {
        List<Visitor> visitors;
        public InMemoryVisitorData()
        {
            visitors = new List<Visitor>()
            {
                new Visitor {Id = 1, Name = "Jonatan Flodin", Company = "Orango", Visiting = "Ola", Date = DateTime.Now.ToString("yyyy/MM/dd")},
                new Visitor {Id = 2, Name = "Bengt", Company = "JU", Visiting = "Jonatan", Date = DateTime.Now.ToString("yyyy/MM/dd")},
                new Visitor {Id = 3, Name = "Anders", Company = "Jönköpöpings kommun", Visiting = "Arman", Date = "2020-02-11"}
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Visitor GetById(int id)
        {
            return visitors.SingleOrDefault(v => v.Id == id);
        }

        public IEnumerable<Visitor> GetVisitorByDate(string date)
        {
            return from v in visitors
                   where (v.Date == date)
                   orderby v.Name
                   select v;
        }

        public Visitor Add(Visitor newVisitor)
        {
            visitors.Add(newVisitor);
            newVisitor.Id = visitors.Max(v => v.Id) + 1;
            newVisitor.Date = DateTime.Now.ToString("yyyy/MM/dd");
            return newVisitor;
        }
 
        public Visitor Update(Visitor updatedVisitor)
        {
            var visitor = visitors.SingleOrDefault(v => v.Id == updatedVisitor.Id);
            if (visitor != null)
            {
                visitor.Name = updatedVisitor.Name;
                visitor.Company = updatedVisitor.Company;
                visitor.Visiting = updatedVisitor.Visiting;
            }
            return visitor;
        }

        public IEnumerable<Visitor> GetVisitorByName(string name)
        {
            return from v in visitors
                   where string.IsNullOrEmpty(name) || v.Name.StartsWith(name)
                   orderby v.Name
                   select v;
        }
    }
}
