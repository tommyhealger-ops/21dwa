using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int current = 0;
        int score = 0;
        string[] questions =
        {
            "Что такое абрек",
            "Что такое абрек",
            "Что такое абрек",
            "Что такое абрек",
        };

        string[][] answers =
        {
            new string[] { "жопа", "жопа2", "жопка", "жопоа" },
            new string[] { "жопа", "жопа2", "жопка", "жопоа" },
            new string[] { "жопа", "жопа2", "жопка", "жопоа" },
            new string[] { "жопа", "жопа2", "жопка", "жопоа" },
        };

        int[] correct = { 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
            ShowQuestion();
        }

        void ShowQuestion()
        {
            if (current >= questions.Length)
            {
                MessageBox.Show("Тест завершен! Баллы: " + score + " из " + questions.Length);
                btnNext.IsEnabled = false;
                return;
            }

            rb1.Content = answers[current][0];
            rb2.Content = answers[current][1];
            rb3.Content = answers[current][2];
            rb4.Content = answers[current][3];

            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;

            txtQuestion.Text = " Вопрос " + (current + 1) + " из " + questions.Length;
        }
            

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int selected = -1;

            if (rb1.IsChecked == true) selected = 0;
            else if (rb2.IsChecked == true) selected = 1;
            else if (rb3.IsChecked == true) selected = 2;
            else if (rb4.IsChecked == true) selected = 3;

            if (selected == -1)
            {
                MessageBox.Show("Выберите вариант ответа!");
                return;

               
            }

            if (selected == correct[current]) score++;
            current++;
            ShowQuestion();
        }
    }
}
