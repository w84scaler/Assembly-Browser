using AssemblyBrowserLib.Levels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class ClassView : INotifyPropertyChanged
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

        private List<MemberView> members;
        public List<MemberView> Members
        {
            get { return members; }
            set
            {
                members = value;
                OnPropertyChanged("Members");
            }
        }

        public ClassView(ClassLevel _class)
        {
            Name = _class.GetFullName();
            List<MemberView> prop = _class.Properties.ConvertAll(p => new MemberView(p));
            List<MemberView> methods = _class.Methods.ConvertAll(m => new MemberView(m));
            List<MemberView> fields = _class.Fields.ConvertAll(f => new MemberView(f));
            fields.AddRange(prop);
            fields.AddRange(methods);
            Members = fields.ConvertAll(m => m);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
