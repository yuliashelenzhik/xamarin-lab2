using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

    internal class VM_MyClass


    {
        public ICommand Add { get; set; }
        public ICommand Del { get; set; }
        public ObservableCollection<MyClass> List { get; set; }
        public MyClass SelectedItem { get; set; }

        public VM_MyClass()
        {
            List = new ObservableCollection<MyClass>();
            Ini();
            Add = new CreateCommand(this);
            Del = new DeleteCommand(this);
        }
        private void Ini()
        {
            List.Add(new MyClass { Name = "Строка 1" });
            List.Add(new MyClass { Name = "Строка 2" });
            List.Add(new MyClass { Name = "Строка 3" });
        }
    }

    abstract class VM_MyClassCommand : ICommand
    {
        protected VM_MyClass VM_MyClass;
        public VM_MyClassCommand(VM_MyClass vM_MyClass)
        {
            VM_MyClass = vM_MyClass;
        }
        public event EventHandler CanExecuteChanged; public abstract bool CanExecute(object parameter); public abstract void Execute(object parameter);
    }

    internal class CreateCommand : VM_MyClassCommand
    {
        public CreateCommand(VM_MyClass vM_MyClass) : base(vM_MyClass)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            var n = VM_MyClass.List.Count;
            var s = string.Format("Строка {0}", ++n);
            VM_MyClass.List.Add(new MyClass { Name = s });
        }
    }
    internal class DeleteCommand : VM_MyClassCommand
    {
        public DeleteCommand(VM_MyClass vM_MyClass) : base(vM_MyClass)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            var t = parameter as MyClass;
            VM_MyClass.List.Remove(VM_MyClass.SelectedItem);
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

