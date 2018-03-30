/*Keegan Chan
 * 29 3 2018
 * U2KeeganTShirt
 * a design for a T Shirt modified by input
 */
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

namespace U2KeeganTShirt
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

        private void btnMake_Click(object sender, RoutedEventArgs e)
        {
            //turn Input into int
            string strInput = txbInput.Text;
            int.TryParse(strInput, out int intInput);

            //assure input works as a colour
            if (intInput >= 255)
            {
                intInput = 255;
            }

            // manipulate input and convert to byte
            int intInput2;
            Byte bytInput, bytInput2, bytInput3;

            intInput2 = intInput;
            
            bytInput2 = Convert.ToByte(intInput2);

            if(intInput % 2 == 0)
            {
                bytInput = 125;
                bytInput3 = 0;
            }
            else
            {
                bytInput = 0;
                bytInput3 = 125;
            }

            //create new colour from bytes made from input
            SolidColorBrush myColour = new SolidColorBrush();
            myColour.Color = Color.FromArgb(255, bytInput, bytInput2, bytInput3);

            //add new colour to the shirt
            rctBody.Fill = myColour;
            rctBody.Stroke = myColour;
            rctArms.Fill = myColour;
            rctArms.Stroke = myColour;


        }
    }
}
