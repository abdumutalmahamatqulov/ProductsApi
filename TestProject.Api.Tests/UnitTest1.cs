using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Products.Repositories;
using TestProject.Api;
using Xunit;

namespace TestProject.Api.Tests;

public class Tests
{
    /*    public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DisCount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? FileMetadataId { get; set; }
        public DateTime CreateData { get; set; }
        public Category Category { get; set; }
        public FileMetadata FileMetadata { get; set; }*/
    [Fact]
    public async Task GetByFilter()
    {
        List<Product> list = new List<Product>() 
        {
            new Product{Id = Guid.Parse("ffffffff-ffff-ffff-ffff-aaaaaaaaffff"),
                        Name = "olma",
                        Description = "daraxt",
                        Price = 12,
                        CategoryId = Guid.Parse("ffffafff-ffff-ffff-ffff-aaaaaaaaffff")
                        },
            new Product{Id = Guid.Parse("ffffffff-ffff-ffff-ffff-aaaaaaaafffa"),
                        Name = "bexi",
                        Description ="terak",
                        Price = 15,
                        CategoryId = Guid.Parse("aaffffff-ffff-ffff-ffff-aaaaaaaaffff")}
        };

        var mockLogger = new Mock<ILogger<ProductRepository>>();
        var context = new Mock<AppDbContext>();

        context.Setup(x => x.Products)
            .Returns(() => list.AsQueryable());

        var repository = new ProductRepository(context.Object, mockLogger.Object);

        var result =  repository.GetAll(true);
/*        var newproduct = repository.Create(new Product
        {
            Id = Guid.Parse("ffffffff-ffff-ffff-ffff-aaaaaaaaffff"),
            Name = "olma",
            Description = "daraxt",
            Price = 12,
            CategoryId = Guid.Parse("ffffafff-ffff-ffff-ffff-aaaaaaaaffff")
        });*/
        Assert.That(result, Is.Not.Null);
        
    }
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}