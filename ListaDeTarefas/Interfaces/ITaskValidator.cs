namespace ListaDeTarefas.Interfaces
{
    internal interface ITaskValidator
    {
        void ValidateTaskId(int id);
        void ValidateTasksExist();
    }
}
