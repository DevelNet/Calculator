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
using Calculator.Domain;

namespace Calculator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comCalc = new Complecs();
            floatCalc = new Real<double>(0);
            intCalc = new Real<int>(0);
            state = new CalcChangeState();
            State.SelectedIndex = 2;
            Display();
        }
        private CalcChangeState state;
        private Icalculaible<Complecs> comCalc;
        private Icalculaible<Real<double>> floatCalc;
        private Icalculaible<Real<int>> intCalc; 
        private void AddButtonEventHandler(object sender, RoutedEventArgs e)
        {
            ChangeValue(GetCalc(), Operations.Add);
            Display();
        }
        private  void RemoveButtonEventHandler(object sender, RoutedEventArgs e)
        {
            ChangeValue(GetCalc(), Operations.Remove);
            Display();
        }
        private void DivideButtonEventHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                ChangeValue(GetCalc(), Operations.Divide);
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MultiplyButtonEventHandler(object sender, RoutedEventArgs e)
        {
            ChangeValue(GetCalc(), Operations.Multiply);
            Display();
        }
        private void ClearButtonEventHandler(object sender, RoutedEventArgs e)
        {
            ChangeValue(GetCalc(), Operations.Clear);
            Display();
        }
        private void FirstClearButtonEventHandler(object sender, RoutedEventArgs e)
        {
            CurrentVal.Text = "";
        }
        private void SqrtButtonEventHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                ChangeValue(GetCalc(), Operations.Sqrt);
            }
            catch (Exception )
            {
                MessageBox.Show("Eror: Root from 0");
            }
            Display();
        }
        private void ModulButtonEventHandler(object sender, RoutedEventArgs e)
        {
            ChangeValue(GetCalc(),Operations.Modul);
            Display();
        }
        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ComboBoxItem)State.SelectedItem).Content.ToString())
            {
                case "Integer": state.Change(true, false, false); break; 
                case "Double" : state.Change(false, true, false); break;
                case  "Complecs" : state.Change(false, false, true); break;
            }
            Display();
        }
        private void Display()
        {
            if (state.CalcEnum == CalcEnum.IntCalc)
            {
                ValueNow.Content = intCalc.ToString();
            }
            if (state.CalcEnum == CalcEnum.FloatCalc)
            {
                ValueNow.Content = floatCalc.ToString();
            }
            if (state.CalcEnum == CalcEnum.ComCalc)
            {
                ValueNow.Content = comCalc.ToString();
            }
            
        }
        private dynamic GetCalc()
        {
            if (state.CalcEnum == CalcEnum.IntCalc)
            {
                return intCalc;
            }
            if (state.CalcEnum == CalcEnum.FloatCalc)
            {
                return floatCalc;
            }
            if (state.CalcEnum == CalcEnum.ComCalc)
            {
                return comCalc;
            }
            return null;
        }
        private void ChangeValue(dynamic calculator, Operations operation)
        {
            dynamic addvalue = null;
            if (CurrentVal.Text != "Write your Value:")
            {
                if (state.CalcEnum == CalcEnum.IntCalc)
                {
                    addvalue = new Real<int>(int.Parse(CurrentVal.Text));
                }
                if (state.CalcEnum == CalcEnum.FloatCalc)
                {
                    addvalue = new Real<double>(double.Parse(CurrentVal.Text));
                }
                if (state.CalcEnum == CalcEnum.ComCalc)
                {
                    addvalue = new Complecs(CurrentVal.Text);
                }
                switch (operation)
                {
                    case Operations.Add:
                        calculator.Add(addvalue);
                        break;
                    case Operations.Remove:
                        calculator.Remove(addvalue);
                        break;
                    case Operations.Divide:
                        calculator.Divide(addvalue);
                        break;
                    case Operations.Multiply:
                        calculator.Multiply(addvalue);
                        break;
                    case Operations.Clear:
                        calculator.Clear(addvalue);
                        break;
                    case Operations.Sqrt:
                        try
                        {
                            calculator.Sqrt(addvalue);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Eror: Divide at 0");
                        }
                        break;
                    case Operations.Modul:
                        calculator.Modul(addvalue);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Write Value!!!!");
            }
        }
    }
}
