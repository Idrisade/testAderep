namespace SuperHeroAPI
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class SuperHeroDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
