using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Presentation.Model;
using Presentation.Commands;
using System.Windows;

namespace Presentation.ViewModel
{
    internal class ClassViewModel : ViewModelBase
    {
        ClassModel model;
        private string helloString;

        public ClassViewModel()
        {
            model = new ClassModel();
            helloString = model.ImportantInfo;
            SpawnEllipsesButtonClick = new RelayCommand(() => ClickHandler());
        }

        public ICommand SpawnEllipsesButtonClick { get; set; }

        private void ClickHandler()
        {
            MessageBox.Show("click");
        }


        public string HelloString
        {
            get
            {
                return model.ImportantInfo;
            }
            set
            {
                helloString = value;
                RaisePropertyChanged("HelloString");
            }
        }
    }
}
