using Library2.Server.Services;
using Library2.Shared;
using NSubstitute;

namespace LibraryServerTest;

public class BookServiceTest
{
    
    
    [Theory]
    [InlineData(1)]
    public void ValidINumber_Get_ReturnsBook(int INumber)
    {
        var mockedBookService = Substitute.For<IBookService>();
        var book = new Book
        {
            Inventory_number = 1, Title = "test1", Author = "valakiTest", Publisher = "RandomPublisher", Rental = null
        };
        
        mockedBookService.Get(Arg.Is(1))
            .Returns(book);
        
        Assert.Equal(INumber,mockedBookService.Get(1).Result.Inventory_number);
    }
    
    [Fact]
    public void InvalidINumber_Get_ReturnsBook()
    {
        var mockedBookService = Substitute.For<IBookService>();
        var book = new Book
        {
            Inventory_number = 1, Title = "test1", Author = "valakiTest", Publisher = "RandomPublisher", Rental = null
        };
        
        mockedBookService.Get(Arg.Is(1))
            .Returns(book);
        
        Assert.NotEqual(2,mockedBookService.Get(1).Result.Inventory_number);
    }
    
    
}