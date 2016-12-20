namespace ShareBook.Models
{
    public class GenreViewModel
    {
        public GenreViewModel(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
