using System;
using System.Linq;

namespace KodluyoruzBootcampEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet",Rating = 4 });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                //db.Remove(blog);
                db.SaveChanges();



                var blogs = db.Blogs.Where(b => b.Rating > 3).OrderBy(b => b.Url).ToList();

                blogs.ForEach(blog =>
                {
                    Console.WriteLine(blog.Posts);
                });





            }
        }
    }
}
