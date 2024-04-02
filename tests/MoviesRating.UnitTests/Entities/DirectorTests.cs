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
    public class DirectorTests
    {
        [Fact]
        public void CreateDirector_ShouldThrowsEmptyDirectorIdException_WhenDirectorIdIsEmpty()
        {
            // Arrange
            var directorId = Guid.Empty;
            var firstName = "Agnieszka";
            var lastName = "Holland";

            // Act
            var exception = Record.Exception(() => new Director(directorId, firstName, lastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyDirectorIdException>(exception);
        }

        [Fact]
        public void CreateDirector_ShouldCreateDirector_WhenSuccess()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "Agnieszka";
            var lastName = "Holland";

            // Act
            var director = new Director(directorId, firstName, lastName);

            // Assert
            Assert.NotNull(director);
            Assert.Equal(directorId, director.DirectorId);
            Assert.Equal(firstName, director.FirstName);
            Assert.Equal(lastName, director.LastName);
        }

        [Fact]
        public void CreateDirector_ShouldThrowsEmptyDirectorFirstNameException_WhenDirectorFirstNameIsEmpty()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "";
            var lastName = "Holland";

            // Act
            var exception = Record.Exception(() => new Director(directorId, firstName, lastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyDirectorFirstNameException>(exception);
        }

        [Fact]
        public void CreateDirector_ShouldThrowsDirectorFirstNameLengthExceededException_WhenDirectorFirstNameIsTooLong()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "qwertyuiop-asdfghjklz-xcvbnmqwer";
            var lastName = "Holland";

            // Act
            var exception = Record.Exception(() => new Director(directorId, firstName, lastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DirectorFirstNameLengthExceededException>(exception);
        }

        [Fact]
        public void CreateDirector_ShouldThrowsEmptyDirectorLastNameException_WhenDirectorLastNameIsEmpty()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "Agnieszka";
            var lastName = "";

            // Act
            var exception = Record.Exception(() => new Director(directorId, firstName, lastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyDirectorLastNameException>(exception);
        }


        [Fact]
        public void CreateDirector_ShouldThrowsDirectorLastNameLengthExceededException_WhenDirectorLastNameIsTooLong()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "Agnieszka";
            var lastName = "qwertyuiop-asdfghjklz-qwertgbhjn";

            // Act
            var exception = Record.Exception(() => new Director(directorId, firstName, lastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DirectorLastNameLengthExceededException>(exception);
        }


    }
}
