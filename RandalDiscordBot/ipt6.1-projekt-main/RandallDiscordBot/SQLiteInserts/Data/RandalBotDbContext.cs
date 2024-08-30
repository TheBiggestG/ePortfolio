using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SQLiteInserts.Models;

namespace SQLiteInserts.Data;

public partial class RandalBotDbContext : DbContext
{
    public RandalBotDbContext()
    {
    }

    public RandalBotDbContext(DbContextOptions<RandalBotDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<ComplaintType> ComplaintTypes { get; set; }

    public virtual DbSet<DiscordServer> DiscordServers { get; set; }

    public virtual DbSet<DiscordUser> DiscordUsers { get; set; }

    public virtual DbSet<LogType> LogTypes { get; set; }

    public virtual DbSet<UserAccessToServer> UserAccessToServers { get; set; }

    public virtual DbSet<UserIsInServer> UserIsInServers { get; set; }

    public virtual DbSet<UserLog> UserLogs { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\SQLite\\database\\RandalBotDB.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.ToTable("Complaint");

            entity.Property(e => e._id)
                //.ValueGeneratedNever()
                //.HasColumnType("int identity");
                .HasColumnName("ComplaintId")  
                .ValueGeneratedOnAdd();
            entity.Property(e => e._text).HasColumnType("varchar(500)")
                           .HasColumnName("ComplaintText");
            entity.Property(e => e.FkComplaintTypeId)
                .HasColumnType("INT")
                .HasColumnName("fk_ComplaintTypeId");
            entity.Property(e => e.FkUserLoginId)
                .HasColumnType("INT")
                .HasColumnName("fk_UserLoginId");

            entity.HasOne(d => d.FkComplaintType).WithMany(p => p.Complaints).HasForeignKey(d => d.FkComplaintTypeId);

            entity.HasOne(d => d.FkUserLogin).WithMany(p => p.Complaints).HasForeignKey(d => d.FkUserLoginId);
        });

        modelBuilder.Entity<ComplaintType>(entity =>
        {
            entity.ToTable("ComplaintType");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ComplaintTypeId");
            entity.Property(e => e._name)
                .HasColumnType("varchar(50)")
                .HasColumnName("ComplaintTypeName");
        });

        modelBuilder.Entity<DiscordServer>(entity =>
        {
            entity.ToTable("DiscordServer");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("DiscordServerId");
            entity.Property(e => e._internalId)
                .HasColumnType("INT")
                .HasColumnName("DiscordServerInternalId");
            entity.Property(e => e._name)
                .HasColumnType("varchar(50)")
                .HasColumnName("DiscordServerName");
        });

        modelBuilder.Entity<DiscordUser>(entity =>
        {
            entity.ToTable("DiscordUser");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("DiscordUserId");
            entity.Property(e => e._internalId)
                .HasColumnType("int identity")
                .HasColumnName("DiscordUserInternalId");
            entity.Property(e => e._name)
                .HasColumnType("varchar(150)")
                .HasColumnName("DiscordUserName");
            entity.Property(e => e.Points).HasColumnType("INT");
        });

        modelBuilder.Entity<LogType>(entity =>
        {
            entity.ToTable("LogType");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("LogTypeId");
            entity.Property(e => e._name)
                .HasColumnType("varchar(50)")
                .HasColumnName("LogTypeName");
        });

        modelBuilder.Entity<UserAccessToServer>(entity =>
        {
            entity.ToTable("UserAccessToServer");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserAccessToServerId");
            entity.Property(e => e.FkServerId)
                .HasColumnType("INT")
                .HasColumnName("fk_ServerId");
            entity.Property(e => e.FkUserLoginId)
                .HasColumnType("INT")
                .HasColumnName("fk_UserLoginId");

            entity.HasOne(d => d.FkServer).WithMany(p => p.UserAccessToServers).HasForeignKey(d => d.FkServerId);

            entity.HasOne(d => d.FkUserLogin).WithMany(p => p.UserAccessToServers).HasForeignKey(d => d.FkUserLoginId);
        });

        modelBuilder.Entity<UserIsInServer>(entity =>
        {
            entity.ToTable("UserIsInServer");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserIsInServerId");
            entity.Property(e => e.FkDiscordUserId)
                .HasColumnType("INT")
                .HasColumnName("fk_DiscordUserId");
            entity.Property(e => e.FkServerId)
                .HasColumnType("INT")
                .HasColumnName("fk_ServerId");

            entity.HasOne(d => d.FkDiscordUser).WithMany(p => p.UserIsInServers).HasForeignKey(d => d.FkDiscordUserId);

            entity.HasOne(d => d.FkServer).WithMany(p => p.UserIsInServers).HasForeignKey(d => d.FkServerId);
        });

        modelBuilder.Entity<UserLog>(entity =>
        {
            entity.ToTable("UserLog");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserLogId");
            entity.Property(e => e.FkDiscordUserId)
                .HasColumnType("INT")
                .HasColumnName("fk_DiscordUserId");
            entity.Property(e => e.FkLogTypeId)
                .HasColumnType("INT")
                .HasColumnName("fk_LogTypeId");
            entity.Property(e => e._text)
                .HasColumnType("varchar(255)")
                .HasColumnName("UserLogText");

            entity.HasOne(d => d.FkDiscordUser).WithMany(p => p.UserLogs).HasForeignKey(d => d.FkDiscordUserId);

            entity.HasOne(d => d.FkLogType).WithMany(p => p.UserLogs).HasForeignKey(d => d.FkLogTypeId);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.ToTable("UserLogin");

            entity.Property(e => e._id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserLoginId");
            entity.Property(e => e._name)
                .HasColumnType("varchar(50)")
                .HasColumnName("UserLoginName");
            entity.Property(e => e.UserLoginPassword)
                .HasColumnType("varchar(50)")
                .HasColumnName("UserLoginPassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
