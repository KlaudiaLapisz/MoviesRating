using MediatR;

namespace MoviesRating.Infrastructure.UnitOfWorks.Decorators
{
    internal class UnitOfWorkCommandHandlerDecorator<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest
    {
        private readonly IRequestHandler<TRequest> _handler;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TRequest> handler, IUnitOfWork unitOfWork)
        {
            _handler = handler;
            _unitOfWork = unitOfWork;
        }

        public  async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ExecuteAsync(() => _handler.Handle(request, cancellationToken));
        }
    }
}
