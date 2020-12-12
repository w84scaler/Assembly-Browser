using AssemblyBrowserLib.Levels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3.View
{
    public class MemberView
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public MemberView(FieldLevel field)
        {
            FullName = field.GetFullName();
        }

        public MemberView(PropertyLevel prop)
        {
            FullName = prop.GetFullName();
        }

        public MemberView(MethodLevel method)
        {
            FullName = method.GetFullName();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
