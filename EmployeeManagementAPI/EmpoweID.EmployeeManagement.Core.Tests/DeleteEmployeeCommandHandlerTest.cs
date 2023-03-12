using EmpoweID.EmployeeManagement.Core.CommandHandlers;
using EmpoweID.EmployeeManagement.Core.Model;
using EmpoweID.EmployeeManagement.Data.Entities;
using EmpoweID.EmployeeManagement.Data.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmpoweID.EmployeeManagement.Core.Tests
{
    public class DeleteEmployeeCommandHandlerTest
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private DeleteEmployeeCommandHandler _handler;

        public DeleteEmployeeCommandHandlerTest()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _handler = new DeleteEmployeeCommandHandler(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async void DeleteEmployeeCommandHandler_Should_Delete()
        {
            _employeeRepositoryMock.Setup(x => x.GetEmployeeByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Employee { });
            _employeeRepositoryMock.Setup(x => x.DeleteEmployeeAsync(It.IsAny<Guid>())).Returns(Task.CompletedTask);

            var request = new DeleteEmployeeRequest { Id = Guid.NewGuid() };
            var result = await _handler.HandleAsync(request);

            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteEmployeeCommandHandler_Should_Throw_Exeption_When_Entity_Not_Exist()
        {
            _employeeRepositoryMock.Setup(x => x.DeleteEmployeeAsync(It.IsAny<Guid>())).Returns(Task.CompletedTask);

            var request = new DeleteEmployeeRequest { Id = Guid.NewGuid() };
            var result = Assert.ThrowsAsync<Exception>(async () => await _handler.HandleAsync(request));
        }
    }
}