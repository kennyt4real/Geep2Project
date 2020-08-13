using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using Geep.Models.Core;

namespace Geep.DataAccess.Context
{
    public class GeepDbContext : IdentityDbContext<ApplicationUser>
    {
        public GeepDbContext(DbContextOptions<GeepDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Agent>().Property(u => u.AgentId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Iterate through all EF Entity types
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                #region Convert UniqueKeyAttribute on Entities to UniqueKey in DB
                var properties = entityType.GetProperties();
                if (properties != null && properties.Any())
                {
                    foreach (var property in properties)
                    {
                        var uniqueKeys = GetUniqueKeyAttributes(entityType, property);
                        if (uniqueKeys != null)
                        {
                            foreach (var uniqueKey in uniqueKeys.Where(x => x.Order == 0))
                            {
                                // Single column Unique Key
                                if (string.IsNullOrWhiteSpace(uniqueKey.GroupId))
                                {
                                    entityType.AddIndex(property).IsUnique = true;
                                }
                                // Multiple column Unique Key
                                else
                                {
                                    var mutableProperties = new List<IMutableProperty>();
                                    properties.ToList().ForEach(x =>
                                    {
                                        var uks = GetUniqueKeyAttributes(entityType, x);
                                        if (uks != null)
                                        {
                                            foreach (var uk in uks)
                                            {
                                                if (uk != null && uk.GroupId == uniqueKey.GroupId)
                                                {
                                                    mutableProperties.Add(x);
                                                }
                                            }
                                        }
                                    });
                                    entityType.AddIndex(mutableProperties).IsUnique = true;
                                }
                            }
                        }
                    }
                }
                #endregion Convert UniqueKeyAttribute on Entities to UniqueKey in DB
            }

            DatabaseSeed.PopulateUserRole(builder); // calling a static class to populate users and roles
        }



        private static IEnumerable<UniqueKeyAttribute> GetUniqueKeyAttributes(IMutableEntityType entityType, IMutableProperty property)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException(nameof(entityType));
            }
            else if (entityType.ClrType == null)
            {
                throw new ArgumentNullException(nameof(entityType.ClrType));
            }
            else if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }
            else if (property.Name == null)
            {
                throw new ArgumentNullException(nameof(property.Name));
            }
            var propInfo = entityType.ClrType.GetProperty(
                property.Name,
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);
            if (propInfo == null)
            {
                return null;
            }
            return propInfo.GetCustomAttributes<UniqueKeyAttribute>();
        }
              
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<AssociationBeneficiary> AssociationBeneficiaries { get; set; }
        public DbSet<ClusterLocation> ClusterLocations { get; set; }
        public DbSet<AgentClusterLocation> AgentClusterLocations { get; set; }
        public DbSet<LocalGovernmentArea> LocalGovernmentAreas { get; set; }
        public DbSet<State> States { get; set; }

    }
}
