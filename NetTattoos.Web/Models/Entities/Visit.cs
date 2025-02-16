namespace NetTattoos.Web.Models.Entities
{
    public class Visit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Visit_type { get; set; }
        public string Visit_date { get; set; }

    }
}
