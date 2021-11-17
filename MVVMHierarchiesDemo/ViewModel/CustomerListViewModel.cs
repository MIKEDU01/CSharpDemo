using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHierarchiesDemo.ViewModel
{
    class CustomerListViewModel : BindableBase
    {
        private string text = string.Empty;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
