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

namespace bank_wpf
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
        int sum, rashod, mes, ostatok, postuplenie, god;
        double stavka;

        private void cmRasschet(object sender, RoutedEventArgs e)
        {
            if (tbRashod.Text =="" || tbStavka.Text=="" || tbSumma.Text=="")
            {
                MessageBox.Show("Не все данные введены!");
                return;
            }
            stavka = Convert.ToDouble(tbStavka.Text);
            sum = Convert.ToInt32(tbSumma.Text);
            rashod = Convert.ToInt32(tbRashod.Text);

            mes = 0;
            god = 0;
            ostatok = sum;

            if (sum * stavka/100/12>=rashod)
            {
                MessageBox.Show("Деньги не закончатся.\nПри расходе " + rashod + " поступление будет " + sum * stavka / 100/12);
                return;
            }

            lbRashod.Items.Clear();

            while(ostatok>rashod)
            {
                postuplenie = (int)(ostatok * stavka / 100/12);
                mes++;
                ostatok = ostatok + postuplenie - rashod;
                lbRashod.Items.Add("Поступление: " + postuplenie + ". Расход: " + rashod + ". Остаток: " + ostatok);
            }
            if (mes > 11)
            {
                god = mes / 12;
                mes = mes % 12;
                MessageBox.Show("Хватило на " + god + " г. и " + mes + " мес");
            }
            else MessageBox.Show("Хватило на " + mes + " мес");
        }
    }
}
