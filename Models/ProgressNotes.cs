using System.ComponentModel.DataAnnotations.Schema;

namespace APIForBlazorApp.Models
{
    public class ProgressNote
    {
        public Patient Patient { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string VisitDate { get; set; }

    }
}