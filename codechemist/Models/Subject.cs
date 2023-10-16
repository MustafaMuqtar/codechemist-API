using System.ComponentModel.DataAnnotations.Schema;

namespace codechemist.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? PublicId { get; set; }



        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}
