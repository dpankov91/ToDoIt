using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace TestProject
{
    public class TaskUnitTest
    {
        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }

        [Fact]
        public void testValidTaskServiceIsCreated()
        {
            var TaskRepositoryMock = new Mock<ITaskRepository>();
            Action action = () => new TaskService(TaskRepositoryMock.Object).Should().NotBe(null);

        }


    }
}