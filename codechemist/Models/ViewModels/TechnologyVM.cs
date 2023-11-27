namespace codechemist.Models.ViewModels
{
    public class TechnologyVM
    {

        public string Title { get; set; }
        public IFormFile Image { get; set; }

    }

    public class TechnologyLessonVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public IEnumerable<TechnologyLessonSubjectVM> TechnologyLessons { get; set; }
    }

    public class TechnologyLessonSubjectVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<TechnologySubjectVM> LessonSubjects { get; set; }
    }


    public class TechnologySubjectVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Exercise SubjectsExercises { get; set; }


    }

    public class TechnologyExerciseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PDF { get; set; }

    }
}
