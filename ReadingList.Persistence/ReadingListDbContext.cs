using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Persistence
{
    public class ReadingListDbContext : DbContext
    {
        
        public ReadingListDbContext(DbContextOptions<ReadingListDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, 
                        Name = "The Da Vinci Code", Finished = false, 
                        ImgUrl = "https://bookishloom.files.wordpress.com/2020/04/513wb5gwt9l.jpg?w=256",
                        PriorityNumber = 1,
                    },
                    new Book { Id = 2, 
                        Name = "Harry Potter And the Deathly Hallows", 
                        Finished = false, 
                        ImgUrl = "https://m.media-amazon.com/images/I/51jyI6lYi1L._AC_SY780_.jpg",
                        PriorityNumber = 5,
                    },
                    new Book { Id = 3, 
                        Name = "The Girl with the Dragon Tattoo", 
                        Finished = false, 
                        ImgUrl= "http://bookcoverarchive.com/wp-content/uploads/amazon/the_girl_with_the_dragon_tattoo.jpg",
                        PriorityNumber = 3,
                    },
                    new Book { Id = 4, 
                        Name = "A Short History of Nearly Everything", 
                        Finished = false, 
                        ImgUrl= "https://ecsmedia.pl/c/a-short-history-of-nearly-everything-w-iext121467176.jpg",
                        PriorityNumber = 4,
                    },
                    new Book { Id = 5, 
                        Name = "The Girl Who Kicked the Hornets' Nest", 
                        Finished = false, 
                        PriorityNumber = 2,
                    }
                );
        }
    }
    
}
