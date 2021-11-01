namespace Codwer.Intern.Persistence.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IDCover { get; set; }
        public int IDPartnerPrice { get; set; }
        public int IDLanguage { get; set; }
        public Cover Cover { get; set; }
        public PartnerPrice  PartnerPrice { get; set; }
        public Language Language { get; set; }
    }
}
