using AccessControl.Domain.Entities.Authentication;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AccessControl.Domain.Tests.Entities
{
    [Trait("Entities", "User")]
    public sealed class UserTests
    {
        //private readonly Faker _faker = new("pt_BR");
        //private readonly ITestOutputHelper _testOutputHelper;

        //public UserTests(ITestOutputHelper testOutputHelper)
        //{
        //    _testOutputHelper = testOutputHelper;
        //}

        [Theory]
        [InlineData("Usuario 1")]
        [InlineData("Usuario 2")]
        public void TheoryConstructor_GivenAllParameters_ThenShouldSetThePropertiesCorrectly(string expectedUserName)
        {
            // Given All Parameters
            // Arrange

            // Act
            var carro = new User(expectedUserName);

            // Then should set the properties correctly
            // Assert
            Assert.Equal(expectedUserName, carro.Name);
        }
    }
}