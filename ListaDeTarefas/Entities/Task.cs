using System.Text;

namespace ListaDeTarefas.Entities
{
    internal class Task
    {

        public int Id { get;}
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; private set; }

        public Task(int id, string title, string description, bool isCompleted = false)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }

        public void CompleteTask(int id)
        {
            
            IsCompleted = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {Id} | Título: {Title} | Descrição: {Description} | " +
                $"{(IsCompleted ? "Completa" : "Incompleta")}");
            return sb.ToString();
        }
    }
}
