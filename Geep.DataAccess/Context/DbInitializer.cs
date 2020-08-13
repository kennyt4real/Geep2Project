using Geep.Models.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geep.DataAccess.Context
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<GeepDbContext>();
            context.Database.EnsureCreated();

            if (!context.States.Any())
            {
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 37,
                    StateName = "Federal Capital Territory"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 1,
                    StateName = "Abia"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 2,
                    StateName = "Adamawa"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 3,
                    StateName = "Akwa Ibom"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 4,
                    StateName = "Anambra"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 5,
                    StateName = "Bauchi"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 6,
                    StateName = "Bayelsa"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 7,
                    StateName = "Benue"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 8,
                    StateName = "Borno"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 9,

                    StateName = "Cross River"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 10,
                    StateName = "Delta"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 11,
                    StateName = "Ebonyi"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 12,
                    StateName = "Enugu"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 13,
                    StateName = "Edo"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 14,
                    StateName = "Ekiti"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 15,
                    StateName = "Gombe"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 16,
                    StateName = "Imo"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 17,
                    StateName = "Jigawa"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 18,
                    StateName = "Kaduna"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 19,
                    StateName = "Kano"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 20,
                    StateName = "Katsina"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 21,
                    StateName = "Kebbi"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 22,
                    StateName = "Kogi"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 23,
                    StateName = "Kwara"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 24,
                    StateName = "Lagos"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 25,
                    StateName = "Nasarawa"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 26,
                    StateName = "Niger"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 27,
                    StateName = "Ogun"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 28,
                    StateName = "Ondo"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 29,
                    StateName = "Osun"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 30,
                    StateName = "Oyo"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 31,
                    StateName = "Plateau"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 32,
                    StateName = "Rivers"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 33,
                    StateName = "Sokoto"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 34,
                    StateName = "Taraba"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 35,
                    StateName = "Yobe"
                });
                context.States.Add(new State()
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    ReferenceId = 36,
                    StateName = "Zamfara"
                });

                context.SaveChanges();
            }
        }
    }
}
