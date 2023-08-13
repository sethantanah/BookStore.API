using BookStore.API.Models.Domain;

namespace BookStore.API.Repository.Interface

{
    public interface IBooksRepository
    {
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<String> DeleteAsync(string slug);
        Task<List<Book>> GetAsync();
        Task<Book> GetByIdAsync(int id);
    }
}
