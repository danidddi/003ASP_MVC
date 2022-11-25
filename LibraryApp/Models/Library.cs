using Newtonsoft.Json;

namespace LibraryApp.Models
{
    public class Library
    {
        private readonly string _path = $"{Environment.CurrentDirectory}\\App_Data\\library.json";
        public List<Book> Books { get; set; }

        public Library()
        {
            if (File.Exists(_path)) Deserialize();
            else
            {
                Books = new List<Book>()
                {
                    new Book(1,"Шерлок Холмс", "Артур Конан Доил", 2022,  2000, 1, "sherlock.jpg"),
                    new Book(2,"Код Да Винчи", "Дэн Браун", 2021,  2500, 5,"code.jpg"),
                    new Book(3,"Десять негритят", "Агата Кристи", 2020, 2100, 3,"ten.jpg"),
                    new Book(4,"Портрет Дориана Грея", "Оскар Уайльд", 2019, 1900, 3, "dorian.jpg"),
                    new Book(5,"Робинзон Крузо", "Даниель Дефо", 2018, 2600, 6,"cruzo.jpg")
                };
                Serialize();
            }
        }

        public void Delete(Book book) => Books.Remove(book);
        public void Add(Book book) => Books.Add(book);
        public void Serialize() => File.WriteAllText(_path, JsonConvert.SerializeObject(Books, Formatting.Indented));
        public void Deserialize()
            => Books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(_path));

    }
}
