using System;

namespace Codwer.Intern.Persistence.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
        
        public DateTime Year { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int EditionId { get; set; }
        public Edition Edition { get; set; }


=======
        public int IDCover { get; set; }
        public int IDPartnerPrice { get; set; }
        public int IDLanguage { get; set; }
        public Cover Cover { get; set; }
        public PartnerPrice  PartnerPrice { get; set; }
        public Language Language { get; set; }
>>>>>>> 657f03c61e2ea4dbdda2e9f7500da989e0947487
    }
}
