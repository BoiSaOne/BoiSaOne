using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace L1
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

        private void CreatePasswords_Click(object sender, RoutedEventArgs e)
        {

            List<char> listSymbols = new List<char>();
            
            if (IsNumber.IsChecked ?? true)
            {
                listSymbols = listSymbols.Union(GenerationSettings.arrNumber.ToList()).ToList();    
            }

            if (IsLowerCase.IsChecked ?? true)
            {
                listSymbols = listSymbols.Union(GenerationSettings.arrLowerCase.ToList()).ToList();    
            }

            if (IsUpperCase.IsChecked ?? true)
            {
                listSymbols = listSymbols.Union(GenerationSettings.arrUpperCase.ToList()).ToList();    
            }

            if (IsSymbol.IsChecked ?? true)
            {
                listSymbols = listSymbols.Union(GenerationSettings.arrSymbol.ToList()).ToList();    
            }

            if (listSymbols.Count == 0)
            {
                MessageBox.Show("Необходимо что-бы было выбран хотя бы один режим генерации пароля", "Ошибка");
                return;
            }
            
            try 
            {    
                GeneratorPassword newGenerator;  
                try
                {
                    int lengthPasswordTB = Convert.ToInt32(lengthPassword.Text);
                    newGenerator = new GeneratorPassword(listSymbols.ToArray<char>(), lengthPasswordTB);
                }
                catch (FormatException)
                {
                    newGenerator = new GeneratorPassword(listSymbols.ToArray<char>());
                    lengthPassword.Text = Convert.ToString(newGenerator.LengthPassword);
                }

                var passwordsArr = newGenerator.GetPasswords();

                if (passwordsArr.Length == 0)
                {
                    MessageBox.Show("Не удалось сгенерировать пароль", "Ошибка");
                    return;    
                }

                string text = "";
                int n = 1;
                foreach (var item in passwordsArr)
                {
                    if (text.Length / n >= 15)
                    {
                        text += item + "\n";
                        n++;
                    }
                    else
                    {
                        text += item + "\t";
                    }
                }

                listPasswords.Text = text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }   

    }
}
