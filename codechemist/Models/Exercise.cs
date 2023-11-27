using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace codechemist.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PDF { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        [JsonIgnore]

        public Subject Subject { get; set; }

    }
}
