using MoviesRating.Infrastructure.DAL;

namespace MoviesRating.Infrastructure.UnitOfWorks
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MoviesRatingDbContext _dbContext;

        public UnitOfWork(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await action();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
