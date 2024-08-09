using ListaDeTarefas.Exceptions;

namespace ListaDeTarefas.Entities
{
    internal class TaskValidator
    {
        private readonly List<Task> _tasks;

        public TaskValidator(List<Task> tasks)
        {
            _tasks = tasks;
        }
        public void ValidateTaskId(int id)
        {
            if (_tasks.Exists(t => t.Id == id))
                throw new DomainException("Já existe uma tarefa com este ID.");
        }

        public void ValidateTasksExist()
        {
            if (_tasks.Count == 0)
                throw new DomainException("Não há tarefas cadastradas.");
        }
    }
}
