using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Factories
{
    public interface IDirectorFactory
    {
        Director CreateDirector(Guid directorId, string firstName, string lastName);
    }
}
