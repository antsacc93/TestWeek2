using System;
using System.Collections;

namespace Week2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList tasks = TaskIO.GetTasksFromFile();
            Console.WriteLine("Benvenuto in Task Manager");
            bool quit = false;

            char key;

            do
            {
                Console.WriteLine("Premi 1 - Aggiungi Task");
                Console.WriteLine("Premi 2 - Elimina un task");
                Console.WriteLine("Premi 3 - Visualizza tutti i task");
                Console.WriteLine("Premi 4 - Filtra per importanza");
                Console.WriteLine("Premi q - Esci");

                key = Console.ReadKey().KeyChar;
                Console.ReadLine();
                switch (key)
                {
                    case '1':
                        //TO DO: Metodo per aggiungere un task OK
                        Task task = TaskManagement.CreateTask();
                        tasks.Add(task);
                        break;
                    case '2':
                        //TODO: Elimina Task OK 
                        TaskManagement.DeleteTask(ref tasks);
                        break;
                    case '3':
                        //TODO: Stampa tutti i task OK
                        TaskManagement.DisplayTasks(tasks);
                        break;
                    case '4':
                        //TODO: Filtra per importanza OK
                        TaskManagement.FilterTasks(tasks);
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Riprovare");
                        break;
                }

            } while (!quit);

            TaskIO.UpdateTasksOnFile(tasks);
        }

        
    }
}
