using ListaDeTarefas.Entities;
using ListaDeTarefas.Screens;

namespace ListaDeTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskValidator taskValidator = new TaskValidator(taskManager.Tasks);
            UserScreen userScreen = new UserScreen(taskManager, taskValidator);
            userScreen.Run();
        }
    }
}
