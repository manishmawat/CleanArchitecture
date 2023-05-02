using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using NetArchTest.Rules;
using Trails.Infrastructure;

namespace Trails.Tests
{
    [TestClass]
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Trails.Domain";
        private const string ApplicationNamespace = "Trails.Application";
        private const string InfraNamespace = "Trails.Infrastructure";
        private const string PresentationNamespace = "Trails.Presentation";
        private const string WebNamespace = "Trails.WebApi";

        [TestMethod]
        public void Domain_Should_Not_HaveDependencyOnOtherProject()
        {
            //Arrange
            var assembly = typeof(Trails.Domain.Primitives.Entity).Assembly;

            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfraNamespace,
                PresentationNamespace,
                WebNamespace
            };

            //Act
            var testResult =Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Application_Should_Not_HaveDependencyOnOtherProject()
        {
            //Arrange
            var assembly = typeof(Trails.Application.DependencyInjection).Assembly;

            var otherProjects = new[]
            {
                InfraNamespace,
                PresentationNamespace,
                WebNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Handler_Should_Have_DependencyOnDomain()
        {
            //Arrange
            var assembly = typeof(Trails.Application.DependencyInjection).Assembly;

            //Act
            var testResult = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Infra_Should_Not_HaveDependencyOnOtherProject()
        {
            //Arrange
            var assembly = typeof(Trails.Infrastructure.DependencyInjection).Assembly;

            var otherProjects = new[]
            {
                PresentationNamespace,
                WebNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Presentation_Should_Not_HaveDependencyOnOtherProject()
        {
            //Arrange
            var assembly = typeof(Trails.Presentation.DependencyInjection).Assembly;

            var otherProjects = new[]
            {
                InfraNamespace,
                WebNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

        [TestMethod]
        public void Controllers_Should_HaveDependencyOnMediatR()
        {
            //Arrange
            var assembly = typeof(Presentation.DependencyInjection).Assembly;

            //Act
            var testResult = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            //Assert
            Assert.IsTrue(testResult.IsSuccessful);
        }

    }
}
