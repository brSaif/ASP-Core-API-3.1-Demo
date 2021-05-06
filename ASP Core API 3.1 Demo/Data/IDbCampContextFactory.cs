namespace ASP_Core_API_3._1_Demo.Data
{
    public interface IDbCampContextFactory
    {
        CampContext CreateDbContext(string[] args);
    }
}