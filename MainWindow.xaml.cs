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

namespace WPFPerenosSlov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        String SourceWord;

        bool isGolos(char A)
        {
            String Pattern = "АаЕеЄєИиІіЇїОоУуЮюЯя";
            if (Pattern.IndexOf(A) >= 0)
                return true;
            else return false;
        }
        bool isPrigolos(char A)
        {
            String Pattern = "БбВвГгҐґДдЖж3зЙйКкЛлМмНнПпРрСсТтФфXхЦцЧчШшЩщ";
            if (Pattern.IndexOf(A) >= 0)
                return true;
            else return false;
        }
        bool isRozdilnik(char A)
        {
            String Pattern = ",.?!:;- ";
            if (Pattern.IndexOf(A) >= 0)
                return true;
            else return false;
        }
        bool isLitera(char A)
        {
            if (isGolos(A) || isPrigolos(A))
                return true;
            else return false;
        }
        bool isStikGolos(char A, char B, char C, char D)
        {
            if (isPrigolos(A) && isGolos(B) && isGolos(C) && isLitera(D)) return true;
            else return false;
        }
        bool isStikPrigolos(char A, char B, char C)
        {
            if (isGolos(A) && isPrigolos(B) && isPrigolos(C)) return true;
            else return false;
        }
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            SourceWord = textBox1.Text;
            textBox2.Clear();
            bool findSklad = false;
            bool findSklad1 = false;
            bool findSklad2 = false;
            textBox2.AppendText(SourceWord[0].ToString());
            int k = 0, l = 0;
            for (int i = 1; i < SourceWord.Length; i++)
            {
                textBox2.AppendText(SourceWord[i].ToString());
                if (i < (SourceWord.Length - 2))
                {
                    if (isStikGolos(SourceWord[i - 1], SourceWord[i], SourceWord[i + 1], SourceWord[i + 2]))
                    {
                        textBox2.AppendText("-");
                        findSklad = true;
                    }
                    if (isStikPrigolos(SourceWord[i - 1], SourceWord[i], SourceWord[i + 1]))
                    {
                        findSklad1 = false;
                        for (int j = (i + 1); j < SourceWord.Length; j++)
                        {
                            if (isRozdilnik(SourceWord[j])) break;
                            if (isGolos(SourceWord[j])) findSklad1 = true;
                        }
                        if (findSklad1)
                        {
                            textBox2.AppendText("-");
                            findSklad = true;
                        }
                    }
                    if (!findSklad)
                    {
                        if (isRozdilnik(SourceWord[i])) k = 0;
                        k++;
                        if ((k > 1) && (isGolos(SourceWord[i])) && (!isRozdilnik(SourceWord[i - 1])))
                        {
                            l = 0;
                            findSklad2 = false;
                            for (int j = (i + 1); j < SourceWord.Length; j++)
                            {
                                if (isRozdilnik(SourceWord[j])) break;
                                if (j < (SourceWord.Length - 1))
                                {
                                    if (isStikGolos('б', SourceWord[j], SourceWord[j + 1], ' ')) break;
                                    if (isStikPrigolos(SourceWord[j - 1], SourceWord[j], SourceWord[j + 1])) break;
                                }
                                l++;
                                if (isGolos(SourceWord[j])) findSklad2 = true;
                            }
                            if (findSklad2 && (l > 1)) textBox2.AppendText("-");
                        }
                    }
                    if (isRozdilnik(SourceWord[i])) findSklad = false;
                }
            }
        }
    }
}
