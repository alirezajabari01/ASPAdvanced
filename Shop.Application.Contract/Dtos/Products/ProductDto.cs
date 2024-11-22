using Shop.Application.Contract.Dtos.Commons;

namespace Shop.Application.Contract.Dtos.Products;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    private string imagePath;
    public string ImagePath
    {
        get
        {
            return ImagePathProvider.HttpImagePath + imagePath;
        }
        set
        {
            imagePath = value;
        }
    }
}
