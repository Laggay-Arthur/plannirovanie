namespace Plan_Args.Algorithms
{
    static class FIFO//First In, First Out
    {
        static public void Start(byte Q, System.Collections.Generic.List<work> tasks, ref System.Windows.Controls.ListBox output)
        {
            while (tasks.Count > 0)
            {
                int taskId = tasks[0].E;
                int time = tasks[0].P;

                output.Items.Add("E" + taskId + "  :  " + time);

                tasks.RemoveAt(0);// Удаляем из начала
                if (time - Q >= 0) tasks.Insert(0, new work(taskId, time - Q));// Добавляем в начало
                else if (time != 0 && Q > time) output.Items.Add("E" + taskId + "  :  " + 0);
            }
        }
    }
}