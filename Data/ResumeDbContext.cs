using System;
using Microsoft.EntityFrameworkCore;
using Resume.Presentation.Models.Entitis.Education;
using Resume.Presentation.Models.Entitis.Exprience;
using Resume.Presentation.Models.Entitis.MySkills;

namespace Resume.Presentation.Data
{
	public class ResumeDbContext : DbContext
	{
		public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>
        options.UseSqlite("Data Source=DataResume.db");
        public DbSet<Education> Educations { get; set; }
        public DbSet<Exprience> Expriences { get; set; }
        public DbSet<MySkills> MySkills { get; set; }

    }
}

