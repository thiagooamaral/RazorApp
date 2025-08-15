using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazoApp.Pages
{
    public class Categories : PageModel
    {
        public List<Category> CategoryList { get; set; } = new();

        public void OnGet(
            int skip = 0, 
            int take = 25)
        {
            var temp = new List<Category>();

            for (int i = 0; i <= 100; i++)
            {
                temp.Add(new Category(i, $"Category-{i}", i * 18.95M));
            }

            CategoryList = temp
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }

    public record Category(int Id, string Title, decimal Price);
}
