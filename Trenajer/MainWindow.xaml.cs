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
        List<Word> rusWords = new List<Word>();
        List<Word> engWords = new List<Word>();
        int countotv = 0;
        int countobsh = 10;
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
                //EnWordTB.Text += i + 1 + " " + enword[a[i]];
                engWords.Add(new Word { IdWords = i + 1, ENWord = enword[a[i]] });
                EnWordTB.ItemsSource = engWords.ToList();
            }

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
                //RuWordTB.Text += i + 1 + "  " + ruword[a[i]];
                rusWords.Add(new Word { IdWords = i + 1, RUWord = ruword[a[i]] });
                RuWordTB.ItemsSource = rusWords.ToList();
            }
            return "0";
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            rusWords.Clear();
            engWords.Clear();
            Fulling();
            countobsh += 10;
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Word word = (sender as TextBox).DataContext as Word; //как в бд
            String textWord = (sender as TextBox).Text as String; // как на самом деле
            string trimText = textWord.Trim().Substring(textWord.Length - 1);
            int id;
            bool isNum = int.TryParse(trimText, out id);
            if (isNum)
            {
                foreach (var item in rusWords)
                {
                    if (word.GetWord == item.RUWord && item.IdWords == id)
                    {
                        MessageBox.Show("Молодец, ты отгадал это слово!");
                        countotv++;
                    }

                }
            }
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            //НЕ РАБОТАЕТ
            int a = countotv / countobsh * 100;
            MessageBox.Show("% Правильных ответов: " + countotv+"," + countobsh+"," + a);

        }
    }
}
