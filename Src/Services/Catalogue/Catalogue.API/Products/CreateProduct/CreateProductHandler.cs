using BuildingBlock.CQRS;
using Catalogue.API.Models;
using Marten;
using MediatR;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    Decimal Price) : ICommand<CreateProductResult>; 
public record CreateProductResult(Guid id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Business Logic to create product
        
        //create the product
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        
        //Save the product in DB
        session.Store(product);
        await session.SaveChangesAsync();
        //return the response
        return new CreateProductResult(product.Id);
    }
}