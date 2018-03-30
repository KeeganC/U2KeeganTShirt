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

            if (intInput % 2 == 0)
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

            //create stripe colour
            SolidColorBrush myStripeColour = new SolidColorBrush();
            myStripeColour.Color = Color.FromArgb(255, 160, 160, 160);

            /* NIU //add stripes
            Rectangle rctStripe = addStripe(myStripeColour, 10, 64);

            myCanvas.Children.Add(rctStripe);
            */

            //assure the stripes aren't too thin
            if(intInput < 15)
            {
                intInput = intInput + 15;
            }

            //add stripes until shirt is full
            int intLimit = 0, counter = 0, intStripeWidth = intInput / 10, intStripeHeight = 64;
            while(intLimit < 286)
            {
                counter++;

                myCanvas.Children.Add(addStripe(myStripeColour, intStripeWidth, intStripeHeight));

                intStripeHeight = intStripeHeight + intStripeWidth * 2;
                intLimit = intStripeHeight;
            }

            //add sleeve stripes
            Rectangle rctArmStripe1 = new Rectangle();
            rctArmStripe1.Height = 59;
            rctArmStripe1.Width = intStripeWidth;
            Canvas.SetTop(rctArmStripe1, 64);
            Canvas.SetRight(rctArmStripe1, 350);
            rctArmStripe1.Fill = myStripeColour;
            rctArmStripe1.Stroke = myStripeColour;

            myCanvas.Children.Add(rctArmStripe1);

            Rectangle rctArmStripe2 = new Rectangle();
            rctArmStripe2.Height = 59;
            rctArmStripe2.Width = intStripeWidth;
            Canvas.SetTop(rctArmStripe2, 64);
            Canvas.SetLeft(rctArmStripe2, 350);
            rctArmStripe2.Fill = myStripeColour;
            rctArmStripe2.Stroke = myStripeColour;

            myCanvas.Children.Add(rctArmStripe2);

            //ensure nothing ovelaps the neck or bottom holes
            myCanvas.Children.Remove(neckHole);
            myCanvas.Children.Add(neckHole);
            myCanvas.Children.Remove(bottomHole);
            myCanvas.Children.Add(bottomHole);
        }

        private static Rectangle addStripe(SolidColorBrush myStripeColour, int height, int top)
        {
            Rectangle rctStripe = new Rectangle();

            rctStripe.Height = height;
            rctStripe.Width = 167;
            Canvas.SetTop(rctStripe, top);
            Canvas.SetLeft(rctStripe, 171);
            rctStripe.Fill = myStripeColour;
            rctStripe.Stroke = myStripeColour;
            return rctStripe;
        }
    }
}
