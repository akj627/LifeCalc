using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LifeCalc
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public PivotPage1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double loanAmount = Convert.ToDouble(txtLoanAmt.Text);                   // price of total mortgage before down payment
            //double taxesPerYear = (double)txtPropertyTax.CurrentValue;                    // this will divided by 12 and added to the monthly payment
            //double downPayment = (double)txtDownPayment.CurrentValue;            // down payment will be subtracted from the loan
            double interestRate = (Convert.ToDouble(txtIntRate.Text)) / 100;                               // calculate interest from 100%
            double termOfLoan = 120;                        // monthly term
            if (radTerm10.IsChecked.HasValue && radTerm10.IsChecked.Value)
                termOfLoan = 120;
            if (radTerm15.IsChecked.HasValue && radTerm15.IsChecked.Value)
                termOfLoan = 180;
            if (radTerm20.IsChecked.HasValue && radTerm20.IsChecked.Value)
                termOfLoan = 240;
            if (radTerm30.IsChecked.HasValue && radTerm30.IsChecked.Value)
                termOfLoan = 360;

            //double propertyTax = (double)txtPropertyTax.CurrentValue;
            //double insurance = (double)txtInsurance.CurrentValue;

            // plug the values from the input into the mortgage formula

            double payment = (loanAmount) * (Math.Pow((1 + interestRate / 12), termOfLoan) * interestRate) / (12 * (Math.Pow((1 + interestRate / 12), termOfLoan) - 1));
            var mortgage = Math.Round(payment, 2, MidpointRounding.AwayFromZero);
            tblMortgage.Text = mortgage.ToString();

            //pieSliceInterest.Value = mortgage * termOfLoan - loanAmount;
            //pieSlicePrincipal.Value = loanAmount;
            pieChart.Series[0].DataPoints[0].Value = mortgage * termOfLoan - loanAmount;
            pieChart.Series[0].DataPoints[1].Value = loanAmount;
        }

    }
}