using ListaDeTarefas.Exceptions;

namespace ListaDeTarefas.Entities
{
    internal class TaskManager
    {

        public List<Task> Tasks { get; private set; } = new List<Task>();

        public void AddTask(Task task)
        {
            if (Tasks.Exists(t => t.Id == task.Id))
                throw new DomainException("Já existe uma tarefa com este ID");
            else
                Tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            Task taskToRemove = Tasks.Find(task => task.Id == id);
            if (taskToRemove != null)
                Tasks.Remove(taskToRemove);
            else
                throw new DomainException("ID não encontrado");
        }

        public void ListTasks()
        {
            if (Tasks.Count > 0)
            {
                List<Task> list = Tasks.OrderBy(task => task.Id).ToList();
                foreach(Task task in list)
                    Console.WriteLine(task.ToString());
            }
            else
                throw new DomainException("Não há tarefas cadastradas");
        }

        public void MarkTaskAsComplete(int id)
        {
            Task taskToComplete = Tasks.Find(task => task.Id == id);
            if(taskToComplete == null)
                throw new DomainException("ID inexistente");
            else
            {
                if (!taskToComplete.IsCompleted)
                    taskToComplete.CompleteTask(id);
                else
                    throw new DomainException("Esta tarefa já está concluída");
            }
        }      
    }
}
