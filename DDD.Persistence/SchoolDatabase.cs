using CodeTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeTest.Persistence
{
    public class SchoolDatabase : System.Data.Entity.DbContext, CodeTest.Persistence.ISchoolDatabase
    {
        public SchoolDatabase()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["SchoolDatabaseCS"].ConnectionString)
        {
            Database.SetInitializer<SchoolDatabase>(new CreateDatabaseIfNotExists<SchoolDatabase>());
            Database.SetInitializer<SchoolDatabase>(new DropCreateDatabaseIfModelChanges<SchoolDatabase>());
        }
        public System.Data.Entity.DbSet<Class> Classess { get; set; }
        public System.Data.Entity.DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            this.MapEntitiesToDatabase(modelBuilder);
        }

        private void MapEntitiesToDatabase(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            //Classess
            modelBuilder.Entity<Class>()
                .ToTable("Classess")
                .HasKey(ss => ss.ClassID)
                .HasMany<Student>(ss => ss.Students)
                .WithRequired(c => c.Class)
                .HasForeignKey(c => c.ClassID);



            //Students
            modelBuilder.Entity<Student>()
                .ToTable("Student")
                .HasKey(c => c.StudentID);

         
        }
        public int CommitChanges()
        {
            return base.SaveChangesAsync().Result;
        }

    }
}
