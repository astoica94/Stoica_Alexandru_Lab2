using Microsoft.AspNetCore.Mvc.RazorPages;
using Stoica_Alexandru_Lab2.Data;

namespace Stoica_Alexandru_Lab2.Models

{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Stoica_Alexandru_Lab2Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                book.BookCategories.Select(c => c.CategoryID));
            
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateBookCategories(Stoica_Alexandru_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null) {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedBookCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.CategoryID));
            foreach (var cat in context.Category)
            {
                if (selectedBookCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(new BookCategory { CategoryID = cat.ID, BookID = bookToUpdate.ID });
                    }
                } else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory courseToRemove = bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
