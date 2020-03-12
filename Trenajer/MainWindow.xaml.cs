using System;
using System.Collections.Generic;
using System.Linq;
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


namespace Trenajer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrenajerEntities db = new TrenajerEntities();

        string[] enword = new string[25];
        string[] ruword = new string[25];

        List<int> notsame = new List<int>();
        List<Word> RusWords = new List<Word>();
        List<Word> EngWords = new List<Word>();

        double CountAll = 0;

        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            Fulling();
        }
        
        public string Fulling()
        {
            Random rnd = new Random();

            //Выгрузка слов

            int count = 0;
            foreach (string t in db.Words.Select(x => x.ENWord).ToList())
            {
                enword[count] = t.ToString();
                count++;
            }

            count = 0;
            foreach (string t in db.Words.Select(x => x.RUWord).ToList())
            {
                ruword[count] = t.ToString();
                count++;
            }

            //Против повторений в выводе 
            int[] a = new int[10];
            a[0] = rnd.Next(0, 24);

            for (int i = 0; i < 10;)
            {
                int num = rnd.Next(0, 24); // генерируем элемент
                int j;
                // поиск совпадения среди заполненных элементов
                for (j = 0; j < i; j++)
                {
                    if (num == a[j])
                    {
                        break; // совпадение найдено, элемент не подходит
                    }
                }
                if (j == i)
                { // совпадение не найдено
                    a[i] = num; // сохраняем элемент
                    i++; // переходим к следующему элементу
                }
            }

            //Вывод на экран англ
            for (int i = 0; i < 10; i++)
            {
                EngWords.Add(new Word { IdWords = i + 1, ENWord = enword[a[i]] });
                EnWordTB.ItemsSource = EngWords.ToList();
            }
            
            EnWordTB.SelectedIndex = index;


            //перемешивание перводов
            for (int i = a.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                // обменять значения data[j] и data[i]
                int temp = a[j];
                a[j] = a[i];
                a[i] = temp;
            }

            //вывод на экран переводы
            for (int i = 0; i < 10; i++)
            {             
                RusWords.Add(new Word { IdWords = i + 1, RUWord = ruword[a[i]] });
                RuWordTB.ItemsSource = RusWords.ToList();
            }
            return "0";
        }
           
        private void BTNChek_Click(object sender, RoutedEventArgs e)
        {

          
            Word word = EnWordTB.SelectedItem as Word;
            int id;
            bool IsNum = int.TryParse(ChekTB.Text, out id);
            
            bool error_ = true;

            if (IsNum)
            {
                CountAll++;
                foreach (var item in RusWords)
                {
                    if (word.GetWord == item.RUWord && item.IdWords == id)
                    {                        
                        EnWordTB.SelectedIndex = index;
                        EnWordTB.SelectedIndex++;
                        index++;
                        error_ = false;
                        ChekTB.Clear();
                        ErrorLab.Visibility = System.Windows.Visibility.Hidden;
                    }
                }

                if (error_)
                {
                    ErrorLab.Visibility = System.Windows.Visibility.Visible;
                    ChekTB.Clear();
                }

                ChekTB.Focus();

                if (index == 10)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Продолжить?", "Все слова отгаданны", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        RusWords.Clear();
                        EngWords.Clear();
                        Fulling();                        
                    }
                    else
                    {
                        double CountProc = 1000 / CountAll;
                        MessageBox.Show("% Правильных ответов: " + Math.Round(CountProc));
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void ChekTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BTNChek_Click(sender,e);
            }
        }
    }
}
