﻿using System;
using System.Collections.Generic;
using KodluyoruzBootcampEFCore.DAL.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzBootcampEFCore
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    
}
