namespace DatabaseLayer
{
    using ModelLayer;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBContext : DbContext
    {
        static string DefaultConnectionString;
        static DBContext()
        {
            var env = Environment.GetEnvironmentVariable("VS_TESTING", EnvironmentVariableTarget.User);
            Console.WriteLine(env);
            if (env == null || env != "1")
            {
                DefaultConnectionString = "DBContext";
            }
            else
            {
                DefaultConnectionString = "Azure";
            }
            Console.WriteLine("Using connection string " + DefaultConnectionString);
        }

        public DBContext()
            : base("name=" + DefaultConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Teacher>()
                .HasMany<Subject>(t => t.Subjects)
                .WithRequired()
                .HasForeignKey(s => s.TeacherId)
                .WillCascadeOnDelete();
        }

        public virtual DbSet<UserProfile> Users { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<BookSession> BookSessions { get; set; }
        public virtual DbSet<TimeSlot> Timeslots { get; set; }
        public virtual DbSet<WorkDay> WorkDays { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

    }

    
}