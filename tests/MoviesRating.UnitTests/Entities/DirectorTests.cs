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

        [Fact]
        public void ChangeFirstName_ShouldThrowsEmptyDirectorFirstNameException_WhenFirstNameIsEmpty()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var newFirstName = "";
            var lastName = "Wann";
            var director = new Director(directorId, firstName, lastName);

            // Act
            var exception = Record.Exception(() => director.ChangeFirstName(newFirstName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyDirectorFirstNameException>(exception);
        }

        [Fact]
        public void ChangeFirstName_ShouldThrowsDirectorFirstNameLengthExceededException_WhenFirstNameIsTooLong()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var newFirstName = "qwertyuiop-asdfghjklz-cvbnmqwtyu";
            var lastName = "Wann";
            var director = new Director(directorId, firstName, lastName);

            // Act
            var exception = Record.Exception(() => director.ChangeFirstName(newFirstName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DirectorFirstNameLengthExceededException>(exception);
        }

        [Fact]
        public void ChangeFirstName_ShouldChangeFirstName_WhenSuccess()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var newFirstName = "Agnieszka";
            var lastName = "Holland";
            var director = new Director(directorId, firstName, lastName);

            // Act
            director.ChangeFirstName(newFirstName);

            // Assert
            Assert.Equal(newFirstName, director.FirstName);
        }

        [Fact]
        public void ChangeLastName_ShouldThrowsEmptyDirectorLastNameException_WhenLastNameIsEmpty()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var lastName = "Wann";
            var newLastName = "";
            var director = new Director(directorId, firstName, lastName);

            // Act
            var exception = Record.Exception(() => director.ChangeLastName(newLastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EmptyDirectorLastNameException>(exception);
        }

        [Fact]
        public void ChangeLastName_ShouldThrowsDirectorLastNameLengthExceededException_WhenLastNameIsTooLong()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var lastName = "Wann";
            var newLastName = "qwertyuiopa-qwertyuiop-qwertyuiop";
            var director = new Director(directorId, firstName, lastName);

            // Act
            var exception = Record.Exception(() => director.ChangeLastName(newLastName));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DirectorLastNameLengthExceededException>(exception);
        }

        [Fact]
        public void ChangeLastName_ShouldChangeLastName_WhenSuccess()
        {
            // Arrange
            var directorId = Guid.NewGuid();
            var firstName = "James";
            var lastName = "Holland";
            var newLastName = "Wann";
            var director = new Director(directorId, firstName, lastName);

            // Act
            director.ChangeFirstName(newLastName);

            // Assert
            Assert.Equal(newLastName, director.FirstName);
        }
    }
}
