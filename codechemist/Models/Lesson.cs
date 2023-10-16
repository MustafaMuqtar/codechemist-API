using System.ComponentModel.DataAnnotations.Schema;

namespace codechemist.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PublicId { get; set; }


        public List<Subject> Subjects { get; set; }

        public int TechnologyId { get; set; }
        [ForeignKey("TechnologyId")]
        public Technology Technology { get; set; }

    }
}
