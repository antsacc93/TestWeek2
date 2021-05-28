using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class TaskIO
    {
        public static string PathText { get; } = Path.Combine(Environment
            .GetFolderPath(Environment.SpecialFolder.Desktop), "Week2.Test/Tasks.txt");

        public static ArrayList GetTasksFromFile()
        {
            string line;
            ArrayList tasks = new ArrayList();

            if (!File.Exists(PathText))
            {
                File.CreateText(PathText);
            }

            using (StreamReader reader = File.OpenText(PathText))
            {
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] taskData = line.Split(",");

                    Task task = new Task()
                    {
                        Descrizione = taskData[0],
                        DataScadenza = DateTime.Parse(taskData[1]),
                        Livello = (LivelloImportanza)Enum.Parse(typeof(LivelloImportanza), taskData[2])
                    };

                    tasks.Add(task);
                }
            }
            return tasks;
        }
        public static void UpdateTasksOnFile(ArrayList tasks)
        {
            using (StreamWriter writer = File.CreateText(PathText))
            {
                writer.WriteLineAsync("Descrizione,DataScadenza,Importanza");
                foreach(Task task in tasks)
                {
                    writer.WriteLineAsync(task.Descrizione + ","
                        + task.DataScadenza.ToShortDateString() + "," + task.Livello);
                }
                
            }
        }
    }
}
