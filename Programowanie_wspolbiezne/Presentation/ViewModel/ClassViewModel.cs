using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Presentation.Model;

namespace Presentation.ViewModel
{
    internal class ClassViewModel : INotifyPropertyChanged
    {
        ClassModel model;
        private string helloString;

        public event PropertyChangedEventHandler PropertyChanged;

        public string HelloString
        {
            get
            {
                return model.ImportantInfo;
            }
            set
            {
                helloString = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Raises OnPropertychangedEvent when property changes
        /// </summary>
        /// <param name="name">String representing the property name</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ClassViewModel()
        {
            model = new ClassModel();
            helloString = model.ImportantInfo;
        }

    }
}
