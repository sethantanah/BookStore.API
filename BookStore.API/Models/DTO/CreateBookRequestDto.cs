namespace BookStore.API.Models.DTO
{
    public class CreateBookRequestDto
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public string price { get; set; } = string.Empty;
        public bool isEditing { get; set; } = false;
        public string urlHandle { get; set; } = string.Empty;
    }
}