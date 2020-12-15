using Application.Handlers;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using Xunit;

namespace UnitTests
{
    public class TestTests
    {
        [Fact]
        public void PassingTest()
        {
        }
        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(3, 2));
        }
        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
