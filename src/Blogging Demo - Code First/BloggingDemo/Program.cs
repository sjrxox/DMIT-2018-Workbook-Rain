using BloggingDemo.DAL;
using BloggingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BloggingDemo
{
    class Program
    {
        // . = member access operator (using this means whatever is on the right belongs to the left
        // class. something then it is static
        // object. = then not static
        static void Main(string[] args)
        {
            var app = new Program();
            app.Welcome();
            app.Run();
        }

        private void Run()
        {
            Welcome();
            // Display the blogs in the database
            using (var context = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog
                {
                    Name = name
                };


                context.Blogs.Add(blog);
                context.SaveChanges();
;                // Display all blogs from the database
                List<Blog> blogs = context.Blogs.ToList();
                DisplayBlogNames(blogs);
            }
        }

        private void DisplayBlogNames(List<Blog> blogs)
        {
            foreach(var item in blogs)
            {
                Console.WriteLine(item.Name);
            }
        }

        private void Welcome()
        {
            Console.WriteLine("Blogging Demo Program");
        }
    }

    namespace Entities
    {
        public class Blog
        {
            // "Primary Key" by convention
            public int BlogId { get; set; }
            public string Name { get; set; }

            // Navigation Property
            public virtual ICollection<Post> Posts {get; set;}
        }


        public class Post
        {
            // Primary Key by convention
            public int PostId { get; set; }
            public string Title { get; set; } 
            public string Content { get; set; }
           
        }
    }
    namespace DAL
    {
        public class BloggingContext : DbContext
        {
            public BloggingContext() : base("name=BlogDb")
            {

            }

            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
        
    }
}
