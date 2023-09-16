using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIForBlazorApp.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }= string.Empty;

        public string Address { get; set; }= string.Empty;


        public string State { get; set; }= string.Empty;

        public string City { get; set; }= string.Empty;

        public string CreatedAt { get; set; }= string.Empty;

        public string UpdatedAt { get; set; }= string.Empty;

        public bool IsDeleted { get; set; }
    }
}