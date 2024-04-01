using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Exceptions;
using System;
using Xunit;

namespace MoviesRating.UnitTests.Entities
{
    public class GenreTests
    {
        [Fact]
        public void CreateGenre_ShouldThrowsEmptyGenreIdException_WhenGenreIdIsEmpty()
        {
            // Arrange
            var genreId = Guid.Empty;
            var genreName = "Thriller";

            // Act
            var exception = Record.Exception(() => new Genre(genreId, genreName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyGenreIdException>(exception);
        }

        [Fact]
        public void CreateGenre_ShouldThrowsEmptyGenreNameException_WhenGenreNameIsEmpty()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "";

            // Act
            var exception = Record.Exception(() => new Genre(genreId, genreName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyGenreNameException>(exception);
        }

        [Fact]
        public void CreateGenre_ShouldThrowsGenreNameLengthExceededException_WhenGenreNameIsTooLong()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "qwertyuiop-asdfghjklz-xcvbnmqwer-qwertyuiop-asdfghjklz";

            // Act
            var exception = Record.Exception(() => new Genre(genreId, genreName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<GenreNameLengthExceededException>(exception);
        }

        [Fact]
        public void CreateGenre_ShouldCreateGenre_WhenSuccess()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "Thriller";

            // Act
            var genre = new Genre(genreId, genreName);

            // Assert
            Assert.NotNull(genre);
            Assert.Equal(genreId, genre.GenreId);
            Assert.Equal(genreName, genre.Name);
        }

        [Fact]
        public void ChangeName_ShouldThrowsEmptyGenreNameException_WhenGenreNameIsEmpty()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "Horror";
            var newGenreName = "";
            var genre = new Genre(genreId, genreName);

            // Act
            var exception = Record.Exception(() => genre.ChangeName(newGenreName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyGenreNameException>(exception);
        }

        [Fact]
        public void ChangeName_ShouldThrowsGenreNameLengthExceededException_WhenGenreNameIsTooLong()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "Horror";
            var newGenreName = "qwertyuiop-asdfghjklz-xcvbnmqwer-qwertyuiop-asdfghjklz";
            var genre = new Genre(genreId, genreName);

            // Act
            var exception = Record.Exception(() => genre.ChangeName(newGenreName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<GenreNameLengthExceededException>(exception);
        }

        [Fact]
        public void ChangeName_ShouldChangeName_WhenSuccess()
        {
            // Arrange
            var genreId = Guid.NewGuid();
            var genreName = "Thriller";
            var newGenreName = "Horror";
            var genre = new Genre(genreId, genreName);

            // Act
            genre.ChangeName(newGenreName);
           
            // Assert
            Assert.Equal(newGenreName, genre.Name);
        }
    }
}
