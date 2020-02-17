using Microsoft.EntityFrameworkCore;
using RegisterVisitors.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegisterVisitors.Data
{
    public class SqlVisitorData : IVisitorData
    {
        private readonly RegisterVisitorsDbContext db;

        public SqlVisitorData(RegisterVisitorsDbContext db)
        {
            this.db = db;
        }

        public Visitor Add(Visitor newVisitor)
        {
            newVisitor.Date = DateTime.Now.ToString("yyyy/MM/dd");
            db.Add(newVisitor);
            return newVisitor;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Visitor Delete(int id)
        {
            var visitor = GetById(id);
            if(visitor != null)
            {
                db.Visitors.Remove(visitor);
            }
            return visitor;
        }

        public Visitor GetById(int id)
        {
            return db.Visitors.Find(id);
        }

        public IEnumerable<Visitor> GetVisitorByDate(string date)
        {
            var query = from v in db.Visitors
                        where (v.Date == date)
                        orderby v.Name
                        select v;

            return query;
        }

        public IEnumerable<Visitor> GetVisitorByName(string name)
        {
            var query = from v in db.Visitors
                        where v.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby v.Name
                        select v;

            return query;
        }

        public Visitor Update(Visitor updatedVisitor)
        {
            var entity = db.Visitors.Attach(updatedVisitor);
            entity.State = EntityState.Modified;
            return updatedVisitor;
        }
    }
}
