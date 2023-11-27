namespace codechemist.Models.ViewModels
{
    public class SubjectVM
    {
        public string Title { get; set; }
        public IFormFile Content { get; set; }
        public int LessonId { get; set; }

    }

    public class SubjectËxerciseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ExerciseInSubjectVM ExerciseInSubjectVMs { get; set; }

    }


    public class ExerciseInSubjectVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PDF { get; set; }

    }
}
