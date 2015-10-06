using System;
namespace CodeTest.Persistence
{
    public interface ISchoolDatabase
    {
        System.Data.Entity.DbSet<CodeTest.Domain.Class> Classess { get; set; }
        System.Data.Entity.DbSet<CodeTest.Domain.Student> Students { get; set; }

        int CommitChanges();
    }
}
