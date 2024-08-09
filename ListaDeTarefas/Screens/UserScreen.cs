using ListaDeTarefas.Entities;
using ListaDeTarefas.Exceptions;
using ListaDeTarefas.Interfaces;

namespace ListaDeTarefas.Screens
{
    internal class UserScreen
    {

        private TaskManager _taskManager;
        private readonly ITaskValidator _taskValidator;

        public UserScreen(TaskManager taskManager, ITaskValidator taskValidator)
        {
            _taskManager = taskManager;
            _taskValidator = taskValidator;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    switch (Menu())
                    {
                        case "1":
                            AddNewTask();
                            break;
                        case "2":
                            RemoveExistingTask();
                            break;
                        case "3":
                            DisplayTasks();
                            break;
                        case "4":
                            CompleteTask();
                            break;
                        case "5":
                            Console.WriteLine("Saindo do programa...");
                            Console.ReadKey();
                            return;
                        default:
                            Console.WriteLine("Opção inválida! Digite novamente...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (DomainException e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                    ShowMessageAndClear();
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Formato inválido!");
                    ShowMessageAndClear();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro inesperado: {e.Message}");
                    ShowMessageAndClear();
                }
            }
        }

        public string Menu()
        {
            Console.WriteLine("LISTA DE TAREFAS");
            Console.WriteLine("1- Adicionar tarefa");
            Console.WriteLine("2- Remover tarefa");
            Console.WriteLine("3- Listar tarefas");
            Console.WriteLine("4- Marcar tarefa como concluída");
            Console.WriteLine("5- Sair do programa");
            return Console.ReadLine();
        }

        public void AddNewTask()
        {
            Console.Clear();
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            _taskValidator.ValidateTaskId(id);
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            _taskManager.AddTask(new Entities.Task(id, title, description));

            ShowMessageAndClear("Tarefa cadastrada com sucesso!");
        }

        public void RemoveExistingTask()
        {
            Console.Clear();
            _taskValidator.ValidateTasksExist();
            Console.Write("Digite o ID da tarefa que deseja remover: ");
            int idToRemove = int.Parse(Console.ReadLine());
            _taskManager.RemoveTask(idToRemove);
            ShowMessageAndClear("Tarefa removida com sucesso!");
        }

        public void CompleteTask()
        {
            Console.Clear();
            _taskValidator.ValidateTasksExist();
            Console.Write("Digite o ID da tarefa que deseja marcar como concluída: ");
            int idToComplete = int.Parse(Console.ReadLine());
            _taskManager.MarkTaskAsComplete(idToComplete);
            ShowMessageAndClear("Tarefa completa com sucesso!");
        }

        public void DisplayTasks()
        {
            Console.Clear();
            _taskValidator.ValidateTasksExist();
            Console.WriteLine("TAREFAS CADASTRADAS");
            _taskManager.ListTasks();
            ShowMessageAndClear();
        }

        public void ShowMessageAndClear(string message = "")
        {
            Console.WriteLine($"\n{message}");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
