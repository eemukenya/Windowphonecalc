using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Phonecalc.Resources;

namespace Phonecalc
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        Double sNumber = 0.0;
        String sOperand = "";
        String Accumulator = "";
        Double sResult = 0.0;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String digit = b.Content.ToString();
            if (txtAnalysis.Text.Contains("="))
            {
                //    Accumulator = "";
                txtAnalysis.Text = "";
                txtDisplay.Text = "0";
            }
            if ((txtDisplay.Text == "0") || (txtDisplay.Text == ""))
           
                txtDisplay.Text = digit;
                
           
            else
            if ((digit == ".") && txtDisplay.Text.Contains("."))
            { }
            else
                txtDisplay.Text += digit;

            Accumulator += digit;
        }

       
        private void Operand_Click(object sender, RoutedEventArgs e)
        {
           

            Button op = (Button)sender;

            if (op.Content.ToString() == "Cos")
            {
                sNumber = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Cos(sNumber).ToString();
                txtAnalysis.Text = "Cos" + Accumulator + "=" + txtDisplay.Text;
            }
            else
            if (op.Content.ToString() == "Sin")
            {
                sNumber = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Sin(sNumber).ToString();
                txtAnalysis.Text = "Sin" + Accumulator + "=" + txtDisplay.Text;
            }
            else if (op.Content.ToString() == "Tan")
            {
                sNumber = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Tan(sNumber).ToString();
                txtAnalysis.Text = "Tan" + Accumulator +"="+ txtDisplay.Text;
            }
            else if(op.Content.ToString() == "%")
            {
                sNumber = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = (sNumber/100).ToString();
                txtAnalysis.Text =  Accumulator + "%" + "=" + txtDisplay.Text;
            }
            else if (op.Content.ToString() == "PI")
            {
                txtDisplay.Text = Math.PI.ToString();
                Accumulator += "PI";
            }
            else if (op.Content.ToString() == "=")
            {
                sNumber = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = result(sNumber, sOperand).ToString();
                Accumulator += "=" + txtDisplay.Text;
                txtAnalysis.Text = Accumulator;
                Accumulator = "";
                sOperand = "";
            }
            else
            {
                if (txtAnalysis.Text.Contains("="))
                    Accumulator = txtDisplay.Text;
                sNumber = Double.Parse(txtDisplay.Text);
                result(sNumber, sOperand);
                sOperand = op.Content.ToString();
                Accumulator += sOperand;
                txtDisplay.Text = "0";
            }
        }

        private Double result(Double xx, String opp) 
        {
            switch(opp)
            {
                case "+":
                    sResult += xx;
                    break;
                case "-":
                    sResult -= xx;
                    break;
                case "/":
                    sResult /= xx;
                    break;
                case "*":
                    sResult *= xx;
                    break;
                case "Exp":
                    sResult =Math.Pow(sResult, xx);
                    break;
                default:
                    sResult = xx;
                    break;
            }
            return sResult;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
            sOperand = "";
            Accumulator = "";
        }

       




        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}