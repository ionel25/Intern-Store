using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codwer.Intern.DataTransferObjects.Books
{
  public   class BookInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int AuthorId { get; set; }
        public int EditionId { get; set; }
        public int CoverID { get; set; }
        public int PartnerPriceID { get; set; }
        public int LanguageID { get; set; }
       
    }
}
