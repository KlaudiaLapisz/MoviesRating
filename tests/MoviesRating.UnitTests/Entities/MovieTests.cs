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

        [Fact]
        public void ChangeTitle_ShouldChangeTitle_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Zielona Mila";
            var newTitle = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            movie.ChangeTitle(newTitle);

            // Assert
            Assert.Equal(newTitle, movie.Title);
        }

        [Fact]
        public void ChangeTitle_ShouldThrowsEmptyMovieTitleException_WhenTitleIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Zielona Mila";
            var newTitle = "";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeTitle(newTitle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieTitleException>(exception);
        }

        [Fact]
        public void ChangeTitle_ShouldThrowsMovieTitleLengthExceededException_WhenTitleIsTooLong()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Zielona Mila";
            var newTitle = "qwertyuiop-qwertyuiop-qwertyuiop-qwertyuiop-qwertyuiop";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeTitle(newTitle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<MovieTitleLengthExceededException>(exception);
        }

        [Fact]
        public void ChangeYearOfProduction_ShouldThrowsIncorrectYearOfProductionException_WhenYearOfProductionIsIncorrect()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var newYearOfProduction = 1513;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeYearOfProduction(newYearOfProduction));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<IncorrectYearOfProductionException>(exception);
        }

        [Fact]
        public void ChangeYearOfProduction_ShouldChangeYearOfProduction_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1981;
            var newYearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            movie.ChangeYearOfProduction(newYearOfProduction);

            // Assert
            Assert.Equal(newYearOfProduction, movie.YearOfProduction);
        }

        [Fact]
        public void ChangeDescription_ShouldThrowsEmptyMovieDescriptionException_WhenDescriptionIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var newDescription = "";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeDescription(newDescription));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieDescriptionException>(exception);
        }

        [Fact]
        public void ChangeDescription_ShouldChangeDescription_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Mark podejmuje pracę stróża odciętego od świata hotelu Look. Wkrótce wszystko zamienia się w koszmar.";
            var newDescription = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            movie.ChangeDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, movie.Description);
        }

        [Fact]
        public void ChangeDirector_ShouldThrowsEmptyMovieDirectorException_WhenDirectorIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            Director newDirector = null;
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeDirector(newDirector));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieDirectorException>(exception);
        }

        [Fact]
        public void ChangeDirector_ShouldChangeDirector_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Mark podejmuje pracę stróża odciętego od świata hotelu Look. Wkrótce wszystko zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanly", "Kubrik");
            var newDirector = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            movie.ChangeDirector(newDirector);

            // Assert
            Assert.Equal(newDirector, movie.Director);
        }

        [Fact]
        public void ChangeGenre_ShouldThrowsEmptyMovieGenreException_WhenGenreIsEmpty()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Jack podejmuje pracę stróża odciętego od świata hotelu Overlook. Wkrótce idylla zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanley", "Kubrick");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            Genre newGenre = null;
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            var exception = Record.Exception(() => movie.ChangeGenre(newGenre));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyMovieGenreException>(exception);
        }

        [Fact]
        public void ChangeGenre_ShouldChangeGenre_WhenSuccess()
        {
            // Arrange
            var movieId = Guid.NewGuid();
            var title = "Lśnienie";
            var yearOfProduction = 1980;
            var description = "Mark podejmuje pracę stróża odciętego od świata hotelu Look. Wkrótce wszystko zamienia się w koszmar.";
            var director = new Director(Guid.NewGuid(), "Stanly", "Kubrik");
            var genre = new Genre(Guid.NewGuid(), "Horror");
            var newGenre = new Genre(Guid.NewGuid(), "Thriller");
            var movie = new Movie(movieId, title, yearOfProduction, description, director, genre);

            // Act
            movie.ChangeGenre(newGenre);

            // Assert
            Assert.Equal(newGenre, movie.Genre);
        }
    }
}

