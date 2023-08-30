using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab2

{

    internal class MyClass : INotifyPropertyChanged
    {
        private string name = "Строка";
        public string Name
        {
            get => name; set { name = value; OnPropertyChanged(); }
        }
public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

       
    }
}

