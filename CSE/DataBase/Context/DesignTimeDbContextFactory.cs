using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace DataBase.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
       public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = "Data Source=mssql6.gear.host;Initial Catalog=cse;User ID=cse;Password=Pr9O8fdOvG_!";
            builder.UseSqlServer(connectionString);
            return new DataContext(builder.Options);
        }
    }
}
