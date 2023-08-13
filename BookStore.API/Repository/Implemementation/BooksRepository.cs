using BookStore.API.Data;
using BookStore.API.Models.Domain;
using BookStore.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository.Implemementation
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BooksRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await dbContext.BookItem.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
        }
         async Task<String> IBooksRepository.DeleteAsync(String slug)
        {
            var existingBook = dbContext.BookItem.FirstOrDefault(b => b.UrlHandle == slug);
            if (existingBook != null)
            {
                dbContext.BookItem.Remove(existingBook);
                await dbContext.SaveChangesAsync();
            }

            return "";
        }

        async Task<List<Book>> IBooksRepository.GetAsync()
        {
            return await dbContext.BookItem.ToListAsync();
        }

        Task<Book> IBooksRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            Book dbbook = dbContext.BookItem.Where(s => s.UrlHandle == book.UrlHandle).FirstOrDefault();

            if (dbbook != null)
            {
                dbbook.Title = book.Title;
                dbbook.Description = book.Description;
                dbbook.Price = book.Price;
                dbbook.Category = book.Category;

                dbContext.Update(dbbook);
                await dbContext.SaveChangesAsync();
            }


            return book;
        }

    }
}
