using System.Linq;


namespace Plan_Args.Algorithms
{
    static class SJF//Shortest Job First 
    {
        static public void Start(byte Q, System.Collections.Generic.List<work> tasks, ref System.Windows.Controls.ListBox output)
        {
            while (tasks.Count > 0)
            {
                tasks = tasks.OrderBy(o => o.P).ToList();// Сортируем по возрастанию

                int taskId = tasks[0].E;
                int time = tasks[0].P;

                output.Items.Add("E" + taskId + "  :  " + time);

                tasks.RemoveAt(0);// Удаляем из начала
                if (time - Q >= 0)
                    tasks.Add(new work(taskId, time - Q));// Добавляем в конец
                else if (time != 0 && (time - 1 == 0 || Q > time))
                    output.Items.Add("E" + taskId + "  :  " + 0);
            }
        }
    }
}