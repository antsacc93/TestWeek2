using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class TaskManagement
    {
        public static Task CreateTask()
        {
            Task task = new Task();
            Console.WriteLine("Prego, inserire una descrizione");
            task.Descrizione = Console.ReadLine();

            bool IsSuccess = false;

            do
            {
                Console.WriteLine("Inserire una data di scadenza valida");
                IsSuccess = DateTime.TryParse(Console.ReadLine(), out DateTime dataScadenza);
                if (!IsSuccess || dataScadenza.Date < DateTime.Today)
                {
                    Console.WriteLine("Data inserita non valida. Riprova");
                    IsSuccess = false;
                }
                else
                {
                    task.DataScadenza = dataScadenza;
                }
            } while (!IsSuccess);

            char key;
            bool sceltaValida = true;

            do
            {
                Console.WriteLine("Specificare l'urgenza: \n 1. Bassa \n 2. Media \n 3. Alta");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '1':
                        task.Livello = LivelloImportanza.Basso;
                        break;
                    case '2':
                        task.Livello = LivelloImportanza.Medio;
                        break;
                    case '3':
                        task.Livello = LivelloImportanza.Alto;
                        break;
                    default:
                        Console.WriteLine("Per favore scegliere un valore valido");
                        sceltaValida = false;
                        break;
                }

            } while (!sceltaValida);
            return task;
        }

        public static void FilterTasks(ArrayList tasks)
        {
            bool success = true;
            do
            {
                try
                {
                    Console.WriteLine("Indicare l'urgenza");
                    LivelloImportanza livello = (LivelloImportanza)Enum.Parse(typeof(LivelloImportanza), Console.ReadLine());
                    ArrayList taskFiltrati = FilterTasksByLevel(livello, tasks);
                    DisplayTasks(taskFiltrati);
                    Console.WriteLine("Premi un tasto per continuare");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    success = false;
                }
            } while (!success);
        }

        private static ArrayList FilterTasksByLevel(LivelloImportanza livello, ArrayList tasks)
        {
            ArrayList filteredTasks = new ArrayList();
            foreach(Task task in tasks)
            {
                if(task.Livello == livello)
                {
                    filteredTasks.Add(task);
                }
            }
            return filteredTasks;
        }

        public static void DisplayTasks(ArrayList tasks)
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public static void DeleteTask(ref ArrayList tasks)
        {
            Console.WriteLine("Quale task vuoi eliminare? (Descrizione)");
            string descrizione = Console.ReadLine();
            Task taskDaEliminare = new Task();
            foreach (Task task in tasks)
            {
                if (task.Descrizione == descrizione)
                {
                    taskDaEliminare = task;
                }
            }
            tasks.Remove(taskDaEliminare);
        }
    }
}
