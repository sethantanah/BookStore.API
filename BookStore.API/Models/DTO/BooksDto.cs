namespace BookStore.API.Models.DTO
{
	public class BooksDto
	{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public bool IsEditing { get; set; } = false;
    public string UrlHandle { get; set; } = string.Empty;
   }
}
