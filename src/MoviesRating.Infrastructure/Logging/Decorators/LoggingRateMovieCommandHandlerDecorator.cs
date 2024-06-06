using MediatR;
using Microsoft.Extensions.Logging;
using MoviesRating.Application.Commands;
using MoviesRating.Domain.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Logging.Decorators
{
    internal class LoggingRateMovieCommandHandlerDecorator : IRequestHandler<RateMovieCommand>
    {
        private readonly IRequestHandler<RateMovieCommand> _rateMovieCommandHandler;
        private readonly ILogger<LoggingRateMovieCommandHandlerDecorator> _logger;
        private readonly IClock _clock;

        public LoggingRateMovieCommandHandlerDecorator(IRequestHandler<RateMovieCommand> rateMovieCommandHandler, ILogger<LoggingRateMovieCommandHandlerDecorator> logger, IClock clock)
        {
            _rateMovieCommandHandler = rateMovieCommandHandler;
            _logger = logger;
            _clock = clock;
        }

        public async Task Handle(RateMovieCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Started handling a command: LoggingRateMovieCommandHandlerDecorator at {_clock.GetCurrentDay()}");
            await _rateMovieCommandHandler.Handle(request, cancellationToken);
            _logger.LogInformation($"Finishing handling a command: LoggingRateMovieCommandHandlerDecorator at {_clock.GetCurrentDay()}");

        }
    }
}
