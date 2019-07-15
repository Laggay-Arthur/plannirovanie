using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;


namespace Plan_Args
{
    struct work
    {
        public work(int E, int P)
        {
            this.E = E;
            this.P = P;
        }
        public int E;
        public int P;
    }
    public partial class MainWindow : Window
    {// SJN, Round Robin(RR), FIFO, LIFO
        public MainWindow() { InitializeComponent(); init = true; tasks = new List<work>(); backupList = new List<work>(); TasksInput.Focus(); }
        byte Q = 2;//Минимальное время выполнения
        List<work> tasks, backupList;
        bool init = false;
        string rb_name = "sjf";
        void AddNewWork_Click(object sender, RoutedEventArgs e)
        {// Добавляем новое задание в список
            if (!int.TryParse(TasksInput.Text, out int P) || P < 1)
            { MessageBox.Show("Ошибка ввода нового задания!"); TasksInput.Text = ""; return; }

            TasksInput.Text = "";
            backupList.Add(new work(backupList.Count, P));
            TaskList.Items.Add(backupList.Count - 1 + "   :   " + P);
            TasksInput.Focus();
        }
        void DeleteWork_Click(object sender, RoutedEventArgs e)
        {// Очистка списка процессов
            while (TaskList.Items.Count > 1) TaskList.Items.RemoveAt(1);
            backupList.Clear(); tasks.Clear(); Result.Items.Clear(); Q = 2;
        }
        void StartWorks_Click(object sender, RoutedEventArgs e)
        {// Запустить выбранный алгоритм
            if (backupList.Count == 0) { MessageBox.Show("Нет заданий к выполнению"); return; }

            if (!byte.TryParse(ProccesTime.Text, out Q) || Q < 1)
            { MessageBox.Show("Ошбика ввода минимального времени исполнения!"); ProccesTime.Text = 2 + ""; return; }
            tasks.Clear(); tasks.AddRange(backupList); Result.Items.Clear();
            if (rb_name == "sjf") Algorithms.SJF.Start(Q, tasks, ref Result);

            else if (rb_name == "rr") Algorithms.RR.Start(Q, tasks, ref Result);

            else if (rb_name == "fifo") Algorithms.FIFO.Start(Q, tasks, ref Result);

            else if (rb_name == "lifo") Algorithms.LIFO.Start(Q, tasks, ref Result);
        }
        void RadioBatton_Checked(object sender, RoutedEventArgs e) { rb_name = ((RadioButton)sender).Name; if (init) Result.Items.Clear(); }
        void WorkInput_KeyUp(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) AddNewWork_Click(null, null); }
        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}