using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.View
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool Open();
    }
}
