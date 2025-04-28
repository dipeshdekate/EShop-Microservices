using MediatR;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    string Price) : IRequest<CreateProductResult>; 
public record CreateProductResult(Guid id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //Business Logic to create product
        throw new NotImplementedException();
    }
}