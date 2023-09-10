using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIForBlazorApp.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }


        public string State { get; set; }

        public string City { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}