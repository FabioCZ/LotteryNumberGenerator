using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LotteryNumberGenerator
{

    public class App : Application
    {
        private Stepper numberCountStepper;
        private Stepper minValueStepper;
        private Stepper maxValueStepper;
        private Label numberCountLabel;
        private Label minValueLabel;
        private Label maxValueLabel;
        private Button generateButton;
        private Label resultLabel;
        private NumberGen numberGen;

        public App()
        {
            numberCountStepper = new Stepper(0.0,100.0,10.0,1.0);
            minValueStepper = new Stepper(0.0, 200.0, 0.0, 1.0);
            maxValueStepper = new Stepper(0.0, 200.0, 60.0, 1.0);
            numberCountStepper.ValueChanged += UpdateLabels;
            minValueStepper.ValueChanged += UpdateLabels;
            maxValueStepper.ValueChanged += UpdateLabels;

            numberCountLabel = new Label();
            minValueLabel = new Label();
            maxValueLabel = new Label();
            generateButton = new Button() {Text = "Generate my lucky numbers!"};
            generateButton.Clicked += GenerateButtonOnClicked;
            resultLabel = new Label();
            UpdateLabels(null,null);


            // The root page of your application
            MainPage = new ContentPage
            {
                Title = "Lottery Number Generator",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        numberCountLabel,
                        numberCountStepper,
                        minValueLabel,
                        minValueStepper,
                        maxValueLabel,
                        maxValueStepper,
                        generateButton,
                        resultLabel
                    }
                }
            };
        }

        private void GenerateButtonOnClicked(object sender, EventArgs eventArgs)
        {
            var constraint = new LotteryTicketConstraint(minValueStepper.Value.ToInt32(),
                maxValueStepper.Value.ToInt32(), numberCountStepper.Value.ToInt32());
            numberGen = new NumberGen(constraint);
            var result = numberGen.Generate();
            result = result.OrderBy(e => e).ToList();
            var resStr = string.Join(",", result);
            resultLabel.Text = resStr;
        }

        private void UpdateLabels(object sender, ValueChangedEventArgs valueChangedEventArgs)
        {
            numberCountLabel.Text = $"Number Count on Ticket: {Convert.ToInt32(numberCountStepper.Value)}";
            minValueLabel.Text = $"Minimum Number: {Convert.ToInt32(minValueStepper.Value)}";
            maxValueLabel.Text = $"Maximum Number: {Convert.ToInt32(maxValueStepper.Value)}";

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public static class DoubleHelper
    {
        public static int ToInt32(this double num)
        {
            return Convert.ToInt32(num);
        }
    }
}
