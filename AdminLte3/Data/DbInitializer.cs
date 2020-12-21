using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdminLte3.Models;
using AdminLte3.Data;

namespace AdminLte3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TodosContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee { FirstMidName = "مصطفی",   LastName = "رحیمی" },
                new Employee { FirstMidName = "رمضان", LastName = "رحیمی" },
                new Employee { FirstMidName = "نادری",   LastName = "نادری" },
                new Employee { FirstMidName = "عباس",    LastName = "عباسی" },
                new Employee { FirstMidName = "صالح",      LastName = "باقری" },
                new Employee { FirstMidName = "علی",    LastName = "مظفری" },
                new Employee { FirstMidName = "عالم",    LastName = "خدادادی" },
                new Employee { FirstMidName = "علی اکبر",     LastName = "رمضانی" }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}