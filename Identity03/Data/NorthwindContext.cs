﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Identity03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity03.Data;
public partial class NorthwindContext : IdentityDbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Supplier> Suppliers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Supplier>().ToTable("Suppliers", t => t.ExcludeFromMigrations());
        List<IdentityRole> roles = new List<IdentityRole>() {
            new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole() { Name = "User", NormalizedName = "USER" }
        };


        List<IdentityUser> users = new List<IdentityUser>() {
            new IdentityUser { UserName = "Admin", NormalizedUserName = "ADMIN", Email = "admin000@gmail.com", NormalizedEmail = "ADMIN000@GMAIL.COM" },
            new IdentityUser { UserName = "pedro", NormalizedUserName = "PEDRO", Email = "pedro000@gmail.com", NormalizedEmail = "ADMIN000@GMAIL.COM" }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.Entity<IdentityUser>().HasData(users);

        var passwordHasher = new PasswordHasher<IdentityUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "$Admin000");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "$Pedro000");

        //https://techriders.tajamar.es/seed-identity-users-roles-con-ef-core-en-net-core/
        List<IdentityUserRole<String>> userRoles = new List<IdentityUserRole<String>>()
        {
            new IdentityUserRole<string>{
                UserId=users[0].Id, RoleId=roles[0].Id
                                            },
            new IdentityUserRole<string>{
                UserId=users[1].Id, RoleId=roles[1].Id
            }
        };

        modelBuilder.Entity<IdentityUser>().HasData(userRoles);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}