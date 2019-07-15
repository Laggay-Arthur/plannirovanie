namespace Plan_Args.Algorithms
{
    static class RR//Round Robin
    {
        static public void Start(byte Q, System.Collections.Generic.List<work> tasks, ref System.Windows.Controls.ListBox output)
        {
            while (tasks.Count > 0)
            {
                int taskId = tasks[0].E;
                int time = tasks[0].P;

                output.Items.Add("E" + taskId + "  :  " + time);

                tasks.RemoveAt(0);// Удаляем из начала
                if (time != 0)
                {
                    if (time - Q >= 0) tasks.Add(new work(taskId, time - Q));// Добавляем в конец
                    else if (time - Q <= 0) tasks.Add(new work(taskId, 0));// Добавляем в конец
                }
            }
        }
    }
}