using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICE.TaskProcessor.Tests
{
    [TestFixture]
    public class SchedulerTests
    {

        Scheduler _runner;

        [SetUp]
        public void TestSetup()
        {
            _runner = new Scheduler();
        }

        [Test]
        [TestCase("a,b", "", "a,b")]
        [TestCase("a,b", "a=>b", "b,a")]
        [TestCase("a,b,c,d", "a=>b,c=>d", "b,a,d,c")]
        [TestCase("a,b,c", "a=>b,b=>c", "c,b,a")]
        public void TestScheduler(string tasks, string dependencies, string expectedResult)
        {
            var tasksList = new TaskList(tasks);
            var dependencyList = new DependencyList(dependencies);

            var result = _runner.Run(tasksList, dependencyList);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        [TestCase("a,b,c,d", "a=>b,b=>c,c=>a")]
        public void TestSchdulerRaisesExceptionOnCircularReference(string tasks, string dependencies)
        {
            var tasksList = new TaskList(tasks);
            var dependencyList = new DependencyList(dependencies);

            var result = _runner.Run(tasksList, dependencyList);
            // Not testing the result - should have raised an exception

        }
    }
}
