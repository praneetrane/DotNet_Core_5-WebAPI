﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description="1st book description",
                        IsRead=true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genre="BioGraphy",
                        Author="1st Author",
                        CoverUrl="https....",
                        DateAdded=DateTime.Now
                    },
                    new Book()
                    {
                        Title = "02nd Book Title",
                        Description = "02nd book description",
                        IsRead = false,
                       
                        Genre = "BioGraphy",
                        Author = "First Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
           
                }
            }
        }
    }
}
