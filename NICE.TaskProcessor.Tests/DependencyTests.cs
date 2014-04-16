using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NICE.TaskProcessor.Tests
{
    [TestFixture]
    public class DependencyTests
    {

        Scheduler _runner;

        [SetUp]
        public void TestSetup()
        {
            _runner = new Scheduler();
        }

        [Test]
        public void WhenEmptyTasksAndDependenciesReturnsEmpty()
        {
            var result = _runner.Run(new TaskList(""), new DependencyList(""));
            Assert.AreEqual(string.Empty, result);

        }

        [Test]
        public void WhenTasksButNoDependenciesReturnsTasks()
        {
            var result = _runner.Run(new TaskList("a,b"), new DependencyList(""));
            Assert.AreEqual("a,b", result);

        }

        [Test]
        public void TwoTasksSingleDependencies()
        {
            var tasks = new TaskList("a,b");
            var dependencies = new DependencyList("a=>b");

            var expectedResult = "b,a";
            var result = _runner.Run(tasks, dependencies);
            Assert.AreEqual(expectedResult, result);
        }



        [Test]
        [ExpectedException(typeof(Exception))]
        public void CreateDependenciyFailsWhenTheSame()
        {
            var dep = new Dependency("a", "a");
        }


        [Test]
        public void CreateDependencyFromLambaWorks()
        {
            var dep = new Dependency("a=>b");
            Assert.AreEqual("a", dep.Child);
            Assert.AreEqual("b", dep.Parent);

        }

        [Test]
        public void CreateDependencyLambdaIgnoresWhiteSpace()
        {
            var dep = new Dependency("a => b");
            Assert.AreEqual("a", dep.Child);
            Assert.AreEqual("b", dep.Parent);

        }

        [Test]
        public void CreateDependencyIgnoresWhitespace()
        {
            var dep = new Dependency(" a ", "     b  ");
            Assert.AreEqual("a", dep.Child);
            Assert.AreEqual("b", dep.Parent);
        }

        [Test]
        public void TaskListParsesList()
        {
            var list = new TaskList("a,b");
            Assert.AreEqual("a", list[0]);

        }

        [Test]
        public void TestDependenciesEmpty()
        {
            var deps = new DependencyList("");
            Assert.AreEqual(0, deps.Count);
        }

        [Test]
        public void TestDependecyListSingleItem()
        {
            var deps = new DependencyList("a=>b");
            Assert.AreEqual("b", deps[0].Parent);
            Assert.AreEqual("a", deps[0].Child);
        }

        [Test]
        public void TestDependenciesMultiple()
        {
            var deps = new DependencyList("a=>b,c=>d");
            Assert.AreEqual(2, deps.Count);

            Assert.AreEqual("b", deps[0].Parent);
            Assert.AreEqual("a", deps[0].Child);

            Assert.AreEqual("d", deps[1].Parent);
            Assert.AreEqual("c", deps[1].Child);

        }

    }
}
