using System;
using System.Text.Json;
using CrazyLibraryMVC.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Services
{
    public class DataImportService
    {
        private readonly IBookRepository m_BookRepository;
        private readonly IAuthorRepository m_AuthorRepository;
        private readonly ICustomerRepository m_CustomerRepository;
        private readonly IBookHistoryRepository m_BookHistoryRepository;
        private readonly Random m_Random = new Random();

        public DataImportService(IBookRepository bookRepository,
            IAuthorRepository authorRepository, ICustomerRepository customerRepository,
            IBookHistoryRepository bookHistoryRepository, Random random)
        {
            m_BookRepository = bookRepository;
            m_AuthorRepository = authorRepository;
            m_CustomerRepository = customerRepository;
            m_BookHistoryRepository = bookHistoryRepository;
            m_Random = random;
        }

        public async Task ImportFromJsonFile(string filePath)
        {
            try
            {
                // Read the JSON file
                string jsonContent = await File.ReadAllTextAsync(filePath);

                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    foreach (JsonElement element in doc.RootElement.EnumerateArray())
                    {
                        await ProcessJsonEntry(element);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception has occured while reading the JSON file:", ex);
            }
        }

        public async Task ProcessJsonEntry(JsonElement element)
        {
            try
            {
                // Extract data from the JSON element
                JsonElement bookElement = element.GetProperty("Book");
                JsonElement literaryCreation = bookElement.GetProperty("LiteraryCreation");
                JsonElement customerElement = element.GetProperty("Customer");
                string actionType = element.GetProperty("Type").GetString()
                    ?? throw new Exception("Action property is missing or null");
                DateTime actionDateTime = element.GetProperty("ActionDateTime").GetDateTime();

                // Process Author data and get the id
                int authorId = await ProcessAuthorData(literaryCreation);

                // Process Book data
                string bookId = await ProcessBookData(bookElement, authorId);

                // Process Customer data

                
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing JSON element", ex);
            }
        }

        // Creates a new author from the provided JSON, inserts it to the database and returns the auto-generated Id
        private async Task<int> ProcessAuthorData(JsonElement literaryCreation)
        {
            // Since the data has no birthdate for authors, define a default value 01/01/2000
            DateTime authBirthDate = new DateTime(2000, 1, 1);
            if (literaryCreation.TryGetProperty("Author", out var authorElement) &&
                authorElement.TryGetProperty("Name", out var authorNameElement) &&
                authorNameElement.ValueKind != JsonValueKind.Null)
            {
                string authorName = authorNameElement.GetString();
                var nameParts = authorName.Split(' ', 2);

                string authFirstName = nameParts[0];
                string authLastName = nameParts.Length > 1 ? nameParts[1] : "";
                Author newAuth = new Author { FirstName = authFirstName, LastName = authLastName, BirthDate = authBirthDate};
                return await m_AuthorRepository.InsertAuthorAsync(newAuth);

            }
            else
            {
                // If author has no name, create an author with unknown name
                Author newAuth = new Author { FirstName = "Unknown", LastName = "", BirthDate= authBirthDate };
                return await m_AuthorRepository.InsertAuthorAsync(newAuth);
            }
        }
        
        // Creates a new Book from provided JSON, inserts it to the database and returns the Id of the new book
        private async Task<string> ProcessBookData(JsonElement bookElement, int authorId)
        {
            var literaryCreation = bookElement.GetProperty("LiteraryCreation");
            string bookUniqueId = literaryCreation.GetProperty("UniqueID").GetString()
                ?? throw new Exception("UniqueId property is missing or null");
            string title = literaryCreation.GetProperty("Title").GetString()
                ?? throw new Exception("Title property is missing or null");
            string description = "";
            if (literaryCreation.TryGetProperty("Description", out var descriptionElement) &&
                !descriptionElement.ValueKind.Equals(JsonValueKind.Null))
            {
                description = descriptionElement.GetString();
            }
            DateTime publicationDate = new DateTime(2000, 1, 1, 0, 0, 0);
            if (bookElement.TryGetProperty("PublicationDate", out var dateElement) &&
                !dateElement.ValueKind.Equals(JsonValueKind.Null))
            {
                publicationDate = dateElement.GetDateTime();
            }
            string imageUrl = bookElement.GetProperty("Image_url").GetString()
                ?? throw new Exception("Image_url property is missing or null");
            string callNumber = bookElement.GetProperty("LibraryCallNumber").GetString()
                ?? throw new Exception("LibraryCallNumber property is missing or null");
            // Choose random number of copies and available copies
            int totalCopies = m_Random.Next(5, 15);
            int copiesAvailable = m_Random.Next(0, totalCopies);
            int borrowCount = totalCopies - copiesAvailable;

            Book newBook = new Book
            {
                Title = title,
                Description = description,
                PublicationDate = publicationDate,
                Image_url = imageUrl,
                LibraryCallNumber = callNumber,
                TotalCopies = totalCopies,
                CopiesAvailable = copiesAvailable,
                BorrowCount = borrowCount,
                AuthorId = authorId
            };
            await m_BookRepository.InsertBookAsync(newBook);
            return bookUniqueId;
        }

        private async Task<int> ProcessCustomerData(JsonElement customerElement)
        {
            string passport = customerElement.GetProperty("Passport").GetString()
                ?? throw new Exception("Passport property is missing or null");
            string firstName = customerElement.GetProperty("FirstName").GetString()
                ?? throw new Exception("FirstName property is missing or null");
            string lastName = customerElement.GetProperty("LastName").GetString()
                ?? throw new Exception("LastName property is missing or null");
            string address = customerElement.GetProperty("Address").GetString()
                ?? throw new Exception("Address property is missing or null");
            string city = customerElement.GetProperty("City").GetString()
                ?? throw new Exception("City property is missing or null");
            string email = customerElement.GetProperty("Email").GetString()
                ?? throw new Exception("Email property is missing or null");
            string phoneNumber = customerElement.GetProperty("PhoneNumber").GetString()
                ?? throw new Exception("PhoneNumber property is missing or null");
            string zip = customerElement.GetProperty("Zip").GetString()
                ?? throw new Exception("Zip property is missing or null");
            DateTime birthDate = customerElement.GetProperty("BirthDate").GetDateTime();

            Customer newCustomer = new Customer
            {
                Passport = passport,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                Email = email,
                PhoneNumber = phoneNumber,
                Zip = zip,
                BirthDate = birthDate
            };

            return 1;
        }
    }
}
