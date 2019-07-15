namespace Plan_Args.Algorithms
{
    static class LIFO//Last In, First Out
    {
        static public void Start(byte Q, System.Collections.Generic.List<work> tasks, ref System.Windows.Controls.ListBox output)
        {
            while (tasks.Count > 0)
            {
                int taskId = tasks[tasks.Count - 1].E;
                int time = tasks[tasks.Count - 1].P;

                output.Items.Add("E" + taskId + "  :  " + time);
                
                tasks.RemoveAt(tasks.Count - 1);// Удаляем из конца
                if (time - Q >= 0) tasks.Add(new work(taskId, time - Q));// Добавляем в конец
                else if (time != 0 && (time - 1 == 0 || Q > time)) output.Items.Add("E" + taskId + "  :  " + 0);
            }
        }
    }
}