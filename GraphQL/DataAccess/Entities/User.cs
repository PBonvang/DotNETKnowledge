namespace DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Framework> Frameworks { get; set; }
    }
}