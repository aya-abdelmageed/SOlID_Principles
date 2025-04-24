using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    // 1.
    // a. Based on specifications, we need to create an interface and a TeamLead class to implement it.
    // b. Later another role like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced into the system,
    // Apply needed refactoring to for better design and mention the current design smells



    /// <summary>
    /// interfaces Task management Interface for creating, assign and excute tasks
    /// as not all roles will work on the whole task so add each in 
    /// different interface from other tasks methods
    /// </summary>
    /// 
    public interface ITaskCreation
    {
        Task CreateSubTask(string t, string d);
    }

    public interface ITaskAssigning
    {
        void AssignTask(IWorker worker, Task t);
    }


    public interface ITaskExcution
    {
        void WorkOnTask(Task t);

    }

    /// <summary>
    /// This interface to keep track of name all of the system worker either leader or developer
    /// </summary>
    public interface IWorker 
    {
        string Name { get; set; }
    }


    /// <summary>
    /// Leader will impelement both interfaces 
    /// </summary>
    public class TeamLead : IWorker, ITaskCreation, ITaskAssigning, ITaskExcution
    {
        public string Name { get; set; }
        //DIP for creating new instance of task
        public ITaskCreation taskCreation { get; set; }
        public void AssignTask(IWorker worker, Task t)
        {
            //Code to assign a task. 
            t.AssignTo(worker);
        }
        public Task CreateSubTask(string t, string d)
        {
            //Code to create a sub task
            return taskCreation.CreateSubTask(t,d);

        }
        public void WorkOnTask(Task t)
        {
            //Code to implement perform assigned task.
            Console.WriteLine("The worker " + this.Name + " on task " + t.Title);
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void AssignTo(IWorker d) 
        { 
            Console.WriteLine("The task " + this.Title + " is assigned to "  +d.Name);
        }
    }

    public class Developer : IWorker, ITaskExcution
    {
        public string Name { get; set; }


        public void WorkOnTask(Task t)
        {
            //Code to implement perform assigned task.
            Console.WriteLine("The worker " + this.Name + " on task " + t.Title);
        }
    }

    public class Manager : IWorker, ITaskAssigning
    {
        public string Name { get; set; }
        //DIP for creating new instance of task
        public ITaskCreation taskCreation { get; set; }

        public void AssignTask(IWorker worker, Task t)
        {
            //Code to assign a task. 
            t.AssignTo(worker);
        }
    }

}
