﻿using Eddie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eddie.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}