using Module32MVCFinal2.Models.Db;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Module32MVCFinal2.Models.Db.Entities;

namespace Module32MVCFinal2
{
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }
        /// Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; } 

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
