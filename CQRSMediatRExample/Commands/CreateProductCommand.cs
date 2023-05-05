using MediatR;

namespace CQRSMediatRExample.Commands
{
    public record CreateProductCommand(Product Product) : IRequest;
}
