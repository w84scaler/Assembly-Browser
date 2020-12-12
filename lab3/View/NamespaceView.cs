using AssemblyBrowserLib.Levels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class NamespaceView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private List<ClassView> classes;
        public List<ClassView> Classes
        {
            get { return classes; }
            set
            {
                classes = value;
                OnPropertyChanged("Classes");
            }
        }

        public NamespaceView(NamespaceLevel namespaceNode)
        {
            Name = namespaceNode.Name;
            Classes = namespaceNode.Classes.ConvertAll(_class => new ClassView(_class));
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
