namespace BookStoreApi.Models
{
    public class BookStoreDataBaseSettings
    { 
        public string ConnectionString { get; set; } = null!; 
        public string DataBaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
