namespace codechemist.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }



        public List<Lesson> Lessons { get; set; }



    }
}
