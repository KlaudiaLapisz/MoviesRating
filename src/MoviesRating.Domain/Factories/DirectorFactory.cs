using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Factories
{
    internal class DirectorFactory : IDirectorFactory
    {
        public Director CreateDirector(Guid directorId, string firstName, string lastName)
        {
            var director = new Director(directorId, firstName, lastName);
            return director;
        }
    }
}
