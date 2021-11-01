using System;

namespace Codwer.Intern.Persistence.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime Year { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int EditionId { get; set; }
        public Edition Edition { get; set; }


    }
}
