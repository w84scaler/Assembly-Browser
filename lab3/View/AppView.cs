using AssemblyBrowserLib.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace lab3.View
{
    public class AppView : INotifyPropertyChanged
    {
        private List<NamespaceView> namespaces;
        public List<NamespaceView> Namespaces
        {
            get { return namespaces; }
            set
            {
                namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }

        private Command openFile;
        public Command OpenFile
        {
            get
            {
                return openFile ??
                  (openFile = new Command(obj =>
                  {
                      IDialogService dialogService = new DialogService();
                      if (dialogService.Open())
                      {
                          try
                          {
                              Namespaces = new AssemblyLevel(dialogService.FilePath).Namespaces.ConvertAll(assemblyNamespace => new NamespaceView(assemblyNamespace));
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.Message);
                          }
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
