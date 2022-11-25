using Microsoft.AspNetCore.Mvc;

using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class LibraryController : Controller
    {
        public Library Library { get; set; }

        public LibraryController() => Library = new Library();
        public IActionResult Index() => View(Library.Books);
        public IActionResult Add()
        {
            Library.Add(new Book(6,"Утраченный символ","Дэн Браун", 2019, 2500,32,"simvol.jpg"));
            Library.Serialize();
            return View("Index", Library.Books);
        }
        public IActionResult Delete(int id)
        {
            Library.Delete(Library.Books.FirstOrDefault(x => x.Id == id));
            Library.Serialize();
            return View("Index", Library.Books);
        }
        public IActionResult SortByAuthor()=> View("Index", Library.Books.OrderBy(a => a.Author));
        public IActionResult SortByYear()=> View("Index", Library.Books.OrderBy(a => a.YearOfPublication));
        public IActionResult ShowOld()
        {
            var year = Library.Books.Min(x => x.YearOfPublication);
            return View("Index", Library.Books.FindAll(x => x.YearOfPublication == year));
        }
        public IActionResult ShowNew() {
            var year = Library.Books.Max(x => x.YearOfPublication);
            return View("Index", Library.Books.FindAll(x => x.YearOfPublication == year));
        }
        public IActionResult MaxAmount()
        {
            var amount = Library.Books.Max(x => x.Amount);
            return View("Index", Library.Books.FindAll(x => x.Amount == amount));
        }
    }
}
