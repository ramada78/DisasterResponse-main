using DisasterResponse.Domain;
using DisasterResponse.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using System;

namespace DisasterResponse.Infrastructure.Context;

public class DisasterDbContext : DbContext
{
    public DisasterDbContext(DbContextOptions<DisasterDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Two tables that have one-to-many relationship with (IncomeAid) table.
        modelBuilder.Entity<IncomeAid>()
            .HasOne(i => i.Donor)
            .WithMany(d => d.IncomeAids)
            .HasForeignKey(i => i.DonorId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<IncomeAid>()
            .HasOne(i => i.Aid)
            .WithMany(d => d.IncomeAids)
            .HasForeignKey(i => i.AidId)
            .OnDelete(DeleteBehavior.Restrict);

        //the following lines (in addition to PropertyComparer.cs) are to solve DamageCases problems: No1. List is not a supported type in DB provider,
        // No2. The property 'IndividualAffected.DamageCases' is a collection or enumeration type with a value converter but with no value comparer.

        modelBuilder.Entity<IndividualAffected>()
            .Property(prop => prop.DamageCases)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.None).Select(x => Enum.Parse<DamageCase>(x)).ToList()
            , new PropertyComparer());
        
        base.OnModelCreating(modelBuilder);

        //EF do not support DateOnly datatype
        modelBuilder.Entity<IndividualAffected>()
            .Property(e => e.BirthDate)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v)
            );

    }

    public DbSet<Donor> Donors => Set<Donor>();
    public DbSet<Aid> Aids => Set<Aid>();
    public DbSet<AidRequest> AidRequests => Set<AidRequest>();
    public DbSet<IndividualAffected> IndividualsAffected => Set<IndividualAffected>();
}