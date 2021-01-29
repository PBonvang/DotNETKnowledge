namespace DataAccess.Entities
{
    public class Framework
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public List<Feature> Features { get; set; }
    }
}