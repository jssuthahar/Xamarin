using SQLite;
namespace DevEnvExe_LocalStorage
{
    public class RegEntity
    {
        public RegEntity()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
