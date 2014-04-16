using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICE.TaskProcessor
{

    public class DependencyList: List<Dependency>
    {

        public DependencyList(string lambdaList)
        {

            if (lambdaList == string.Empty)
                return;
            
            var lambas = lambdaList.Split(',');
            
            for (var i = 0; i < lambas.Count(); i++)
            {
                var dep = new Dependency(lambas[i]);
                this.Add(dep);
            }

        }
    }

    public class Dependency
    {
        public string Parent { get; private set; }
        public string Child { get; private set; }

        private void __construct(string parent, string dependent)
        {
            if (parent == dependent)
                throw new Exception("Invalid dependency " + dependent + "=>" + parent);
            Parent = parent.Trim();
            Child = dependent.Trim();
        }

        public Dependency(string parent, string dependent)
        {
            __construct(parent, dependent);
        }

        public Dependency(string lambaDependency)
        {
            string[] delimiters = { "=>" };

            if (string.IsNullOrWhiteSpace(lambaDependency))
                throw new ArgumentException("Empty constructor");
            
            var arr = lambaDependency.Split(delimiters, System.StringSplitOptions.None);


            if (arr.Length == 0)
                throw new Exception("Bad constructor " + lambaDependency);

            if (arr.Length != 2)
                throw new Exception("Bad constructor " + lambaDependency);

            __construct(arr[1], arr[0]);



        }

    }

    public class TaskList: List<string>
    {

        public TaskList(string delimitedTaskNames)
        {
            var tasks = delimitedTaskNames.Split(',');
            this.AddRange(tasks.ToList());

        }

        public override string ToString()
        {
            return string.Join(",", this);
        }

    }


    public class Scheduler
    {

        private List<string> _outputQueue;
        private DependencyList _dependencies;
        private TaskList _tasks;

        private Stack<string> _circularChecker;

        public string Run(TaskList tasks, DependencyList dependencies)
        {


            _outputQueue = new List<string>();
            _circularChecker = new Stack<string>();

            if (tasks.Count == 0)
                return string.Empty;

            if (dependencies.Count == 0)
                return tasks.ToString();

            _dependencies = dependencies;
            _tasks = tasks;

            for (var i = 0; i < tasks.Count; i++)
            {
                _processTask(tasks[i]);
            }

            return string.Join(",", _outputQueue.ToArray());

        }

        private void _processTask(string task)
        {
            if (_circularChecker.Contains(task))
                throw new Exception("Circular reference");

            if (!_tasks.Contains(task))
                throw new Exception("Task " + task + " not found in the original list " + _tasks.ToString());

            _circularChecker.Push(task);
            
                //Do nothing if the task is already in the queue
            if (_outputQueue.Any(q => q == task))
                return;

            //Does the task have a dependency
            var deps = _dependencies.Where(d => d.Child == task);
            foreach (var dep in deps)
            {
                _processTask(dep.Parent);
            }

            //Finally add the task to the queue
            _outputQueue.Add(task);

            _circularChecker.Pop();


        }



    }
}
