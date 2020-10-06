using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

namespace _2_Dynamic_Assemblies
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /* На основі додатку WPF створити додаток, що матиме наступний функціонал:
          - прочитати перелік бібліотек в каталозі виконуваного об'єкту або через діалог вибрати потрібну папку
          - вивести на екран всі доступнні класи і публічні методи які можна викликати. Методи можуть бути статичними
          - при виборі користувачем певного методу показати відповідний функціонал для введення необхідних параметрів
          - результат роботи метода вивести на вікно
          - бібліотека, метод якої був обраний для виконання повинна завантажуватися в окремий домен. Після виконання домен має вивантажитися
         */


        AppDomain domain;    //Створюємо домен
        Assembly assembly; // Для загрузки зборок (бібліотек)
        MethodInfo selectedMethod; //вибраний метод зі списку
        string assemblyName; //імя збірки
        object obj;

        public MainWindow()
        {
            InitializeComponent();

            domain = AppDomain.CreateDomain("Domain");

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                int deleteIndex = openFileDialog.SafeFileName.IndexOf('.'); // Вираховуємо кількість символів до крапки
                assemblyName = openFileDialog.SafeFileName.Remove(deleteIndex); // Ім'я бібліотеки без розширення .dll
                lb_library.Content = assemblyName; // Виводимо назву бібліотеки
                assembly = domain.Load(assemblyName); //додаємо бібліотеку в домен
                var classes = assembly.GetTypes(); //Витягуємо класи з бібліотеки
                lb_Assemblies.ItemsSource = classes.Select(x => x.Name); // Прив'язуємо лістбокс до класів
            }

        }

        private void Lb_Assemblies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lb_Methods.SelectionChanged -= lb_Methods_SelectionChanged;
            lb_Methods.Items.Clear();
            spParameters.Children.Clear();
            var selectedClass = lb_Assemblies.SelectedItem.ToString();
            lb_Method.Content = selectedClass;
            string path = $"{assemblyName}.{selectedClass}";
            var clas = assembly.GetType(path);
            obj = Activator.CreateInstance(clas);
            lb_Method.Content = obj.ToString();
            var methods = clas.GetMethods();
            foreach (var item in methods)
            {
                lb_Methods.Items.Add(item);
            }

            lb_Methods.SelectionChanged += lb_Methods_SelectionChanged;
        }

        private void lb_Methods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spParameters.Children.Clear(); 
            selectedMethod = lb_Methods.SelectedItem as MethodInfo;
            var parametersCount = selectedMethod.GetParameters().Count();
           // lb_Method.Content = "";

            if (selectedMethod.ReturnType == typeof(void) && parametersCount == 0)
                return;

            var parametersTypes = selectedMethod.GetParameters().Select(x => x.ParameterType.Name).ToList();
            var parametersNames = selectedMethod.GetParameters().Select(x => x.Name).ToList();

            Label label = new Label();
            label.VerticalAlignment = VerticalAlignment.Center;
            TextBox textBox = new TextBox();
            textBox.Height = 30;
            textBox.Width = 120;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;

            for (int i = 0; i < parametersCount; i++)
            {
                label.Content = $"({parametersTypes[i]} { parametersNames[i]})";
                spParameters.Children.Add(label);
                spParameters.Children.Add(textBox);
            }
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            var parametersCount = selectedMethod.GetParameters().Count();
            if (parametersCount == 0 && selectedMethod.ReturnType == typeof(void))
            {
                selectedMethod.Invoke(obj, null);
                return;
            }
            else if (parametersCount == 0 && selectedMethod.ReturnType != typeof(void))
            {
                object result = selectedMethod.Invoke(obj, null);
                if (result == null)
                {
                    lblResult.Content += "null";
                    return;
                }
                lblResult.Content += $"{result.ToString()}";
                return;
            }
            else
            {
                var panelUiElements = spParameters.Children;
                var textBoxes = GetTextBoxes(panelUiElements);
                foreach (var item in textBoxes)
                {
                    if (item.Text == "")
                    {
                        return;
                    }
                }
                var inputParameters = GetParameters(textBoxes);

                if (selectedMethod.ReturnType == typeof(void) && inputParameters != null)
                {
                    selectedMethod.Invoke(obj, inputParameters);

                    lblResult.Content = $"{selectedMethod.Name} (";
                    foreach (var item in inputParameters)
                    {
                        if (inputParameters.Length > 1)
                        {
                            lblResult.Content += $"{item.ToString()}, ";
                        }
                        else if (item == inputParameters[inputParameters.Length - 1])
                        {
                            lblResult.Content += $"{item.ToString()})";
                        }
                    }
                    return;
                }

                object result = selectedMethod.Invoke(obj, inputParameters);
                if (result == null)
                {
                    lblResult.Content += ":Null";
                    return;
                }

                lblResult.Content = result.ToString();
            }
        }

        private object[] GetParameters(TextBox[] textBoxes)
        {
            var methodParameters = selectedMethod.GetParameters().ToArray();
            var inputValues = new List<object>();
            for (int i = 0; i < methodParameters.Length; i++)
            {
                if (methodParameters[i].ParameterType == typeof(int))
                {
                    if (int.TryParse(textBoxes[i].Text, out int temp))
                        inputValues.Add(temp);
                    else
                        inputValues.Add(0);
                }
                else
                {
                    inputValues.Add(textBoxes[i].Text);
                }
            }

            return inputValues.ToArray();
        }

        private TextBox[] GetTextBoxes(UIElementCollection panelElements)
        {
            var textBoxes = new List<TextBox>();

            foreach (var item in panelElements)
            {
                if (item is TextBox)
                    textBoxes.Add(item as TextBox);
            }

            return textBoxes.ToArray();
        }
    }
}
