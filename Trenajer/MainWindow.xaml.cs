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
        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            string[] enw = new string[25];
            List<int> notsame = new List<int>();
            int count = 0;
            

            var EnW = db.Words.Select(x => x.ENWord).ToList();
            

            foreach (string t in EnW)
            {
                enw[count] = t.ToString()+"\r\n";                
                count++;
            }


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
                        break; // совпадение найдено, элемент не подходит
                }
                if (j == i)
                { // совпадение не найдено
                    a[i] = num; // сохраняем элемент
                    i++; // переходим к следующему элементу
                }
            }
            
            for (int i = 0; i < 10; i++)
            {

                EnWord.Text += i + 1 + " " + enw[a[i]];
            }

            

        }
        
    }
}
