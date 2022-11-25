namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfPublication { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }
        public string Cover { get; set; }

        public Book(int id, string name,string author , int yearOfPublication, int cost, int amount, string cover)
        {
            Id = id;
            Author = author;
            Name = name;
            YearOfPublication = yearOfPublication;
            Amount = amount;
            Cost = cost;
            Cover = cover;
        }
    }
}
