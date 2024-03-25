using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Service
{
    public class BookService
    { 
        private readonly IMongoCollection<Book> _booksCollection; 
        public BookService(IOptions<BookStoreDataBaseSettings> dbSettings) 
        { 
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString); 
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName); 
            _booksCollection = mongoDataBase.GetCollection<Book>(dbSettings.Value.CollectionName);
        } 

        public async Task<List<Book>> GetBooksAsync() => await _booksCollection.Find(_ => true).ToListAsync(); 
        public async Task<Book?> GetBookAsync(string id) => await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task AddBookAsync(Book newBook) => await _booksCollection.InsertOneAsync(newBook); 
        public async Task UpdateBookAsync(string id, Book book) => await _booksCollection.ReplaceOneAsync(x => x.Id == id, book); 
        public async Task RemoveBookAsync(string id) => await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
