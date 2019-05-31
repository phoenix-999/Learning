using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sheduller
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskFactory factory = new TaskFactory(new CustomTaskSheduller());
            factory.StartNew(() => { Console.WriteLine("task run"); }).Wait();

        }
    }

    class CustomTaskSheduller : TaskScheduler
    {
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>();

        private readonly LinkedList<Task> delayTasks = new LinkedList<Task>();

        public CustomTaskSheduller()
        {
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks;
        }

        protected override void QueueTask(Task task)
        {
            if (DateTime.Now.Hour == 18)
            {
                _tasks.AddLast(task);
                foreach(var tsk in delayTasks)
                {
                    _tasks.AddFirst(tsk);
                }
            }
            else
            {
                delayTasks.AddLast(task);
            }

            
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
