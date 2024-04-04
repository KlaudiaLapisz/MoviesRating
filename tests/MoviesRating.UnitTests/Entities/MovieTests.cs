using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesRating.UnitTests.Entities
{
    public class MovieTests
    {
        [Fact]
        public void CreateMovie_ShouldThrowsEmptyMovieIdException_WhenMovieIdIsEmpty()
        {
            // Arrange
            var movieId = Guid.Empty;
            var title = "Obecność";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieIdException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsEmptyMovieTitleException_WhenTitleIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieTitleException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsMovieTitleLengthExceededException_WhenTitleIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "qwertyuiop-asdfghjklz-xcvbnmqwer-qwertyuiop-asdfghjklz";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<MovieTitleLengthExceededException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsIncorrectYearOfProductionException_WhenYearOfProductionIncorrect()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Obecność";
            var yearOfProduction = 1899;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<IncorrectYearOfProductionException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsEmptyMovieDescriptionException_WhenDescriptionEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Obecność";
            var yearOfProduction = 2010;
            var description = "";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieDescriptionException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsEmptyMovieDirectorException_WhenDirectorEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Obecność";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            Director director = null;
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieDirectorException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldThrowsEmptyMovieGenreException_WhenGenreEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Obecność";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            Genre genre = null;

            // Act
            var exception = Record.Exception(() => new Movie(movieId, title, yearOfProduction, description, director, genre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieGenreException>(exception);
        }

        [Fact]
        public void CreateMovie_ShouldCreateMovie_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Obecność";
            var yearOfProduction = 2010;
            var description = "Badacze zjawisk paranormalnych Roger i Carolyn Perron wraz z pięcioma córkami przenoszą się do zaniedbanego domu na wsi, gdzie zamierzają wychować dzieci z dala od niebezpieczeństw, jakie czekają na nie w dużym mieście.\r\n";
            var director = new Director(Guid.NewGuid(), "James", "Wan");
            var genre = new Genre(Guid.NewGuid(), "Horror");

            // Act
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Assert
            Assert.Equal(movieId, movie.MovieId);
            Assert.Equal(title, movie.Title);
            Assert.Equal(yearOfProduction, movie.YearOfProduction);
            Assert.Equal(description, movie.Description);
            Assert.Equal(director.DirectorId, movie.Director.DirectorId);
            Assert.Equal(director.FirstName, movie.Director.FirstName);
            Assert.Equal(director.LastName, movie.Director.LastName);
            Assert.Equal(genre.GenreId, movie.Genre.GenreId);
            Assert.Equal(genre.Name, movie.Genre.Name);
        }
    }
}
