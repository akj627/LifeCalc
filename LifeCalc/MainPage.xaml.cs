using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LifeCalc.Resources;

namespace LifeCalc
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

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double loanAmt = Convert.ToDouble(txtLoanAmt.Text);                   // price of total mortgage before down payment
            //double taxesPerYear = (double)txtPropertyTax.CurrentValue;                    // this will divided by 12 and added to the monthly payment
            //double downPayment = (double)txtDownPayment.CurrentValue;            // down payment will be subtracted from the loan
            double intRate = (Convert.ToDouble(txtIntRate.Text)) / 100;                               // calculate interest from 100%
            double loanDuration = 120;                        // monthly term
            if (radTerm10.IsChecked.HasValue && radTerm10.IsChecked.Value)
                loanDuration = 120;
            if (radTerm15.IsChecked.HasValue && radTerm15.IsChecked.Value)
                loanDuration = 180;
            if (radTerm20.IsChecked.HasValue && radTerm20.IsChecked.Value)
                loanDuration = 240;
            if (radTerm30.IsChecked.HasValue && radTerm30.IsChecked.Value)
                loanDuration = 360;

            //double propertyTax = (double)txtPropertyTax.CurrentValue;
            //double insurance = (double)txtInsurance.CurrentValue;

            // plug the values from the input into the mortgage formula

            double payment = (loanAmt) * (Math.Pow((1 + intRate / 12), loanDuration) * intRate) / (12 * (Math.Pow((1 + intRate / 12), loanDuration) - 1));
            var mortgage = Math.Round(payment, 2, MidpointRounding.AwayFromZero);
            tblMortgage.Text = mortgage.ToString();

            //pieSliceInterest.Value = mortgage * loanDuration - loanAmt;
            //pieSlicePrincipal.Value = loanAmt;
            pieChart.Series[0].DataPoints[0].Value = mortgage * loanDuration - loanAmt;
            pieChart.Series[0].DataPoints[1].Value = loanAmt;
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