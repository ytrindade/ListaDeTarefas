using ListaDeTarefas.Entities;
using ListaDeTarefas.Screens;
using ListaDeTarefas.Interfaces;

namespace ListaDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            ITaskValidator taskValidator = new TaskValidator(taskManager.Tasks);
            UserScreen userScreen = new UserScreen(taskManager, taskValidator);
            userScreen.Run();
        }
    }
}
