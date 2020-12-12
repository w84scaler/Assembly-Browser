using AssemblyBrowserLib.Levels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class AssemblyView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private List<NamespaceView> namespaces;
        private List<NamespaceView> Namespaces
        {
            get { return namespaces; }
            set
            {
                namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }

        public AssemblyView(AssemblyLevel assembly)
        {
            Namespaces = assembly.Namespaces.ConvertAll(assemblyNamespace => new NamespaceView((NamespaceLevel)assemblyNamespace));
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
