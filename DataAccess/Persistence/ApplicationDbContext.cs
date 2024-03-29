﻿using DataAccess.Core.Entities;
using DataAccess.Persistence.Entity_Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Build> Builds { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SuggestedBuild> SuggestedBuilds { get; set; }

        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FollowingConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new BuildConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CaseConfiguration());
            modelBuilder.Configurations.Add(new CpuConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new MotherboardConfiguration());
            modelBuilder.Configurations.Add(new PsuConfiguration());
            modelBuilder.Configurations.Add(new RamConfiguration());
            modelBuilder.Configurations.Add(new StorageConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new SuggestedBuildConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
