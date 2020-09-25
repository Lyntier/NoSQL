namespace NoSQL.DataAccess
{
    /// <summary> Interface needed for Dependency Injection into referencing class libraries. </summary>
    public interface ISettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    /// <summary> Contains settings needed by class libraries. </summary>
    public class Settings : ISettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}