using System;
using Microsoft.EntityFrameworkCore;
using polyglot_dotnet.Entity;

namespace polyglot_dotnet.Data;

public class DbConn: DbContext
{
    public DbConn(DbContextOptions<DbConn> options):base(options){

    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }
}
