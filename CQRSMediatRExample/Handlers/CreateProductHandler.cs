using CQRSMediatRExample.Commands;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CreateProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.Product);
        }
    }
}
