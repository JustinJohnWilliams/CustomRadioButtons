using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RadioButtons
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public HomeViewModel()
        {
            _testRadioButtonList = new Dictionary<int, string>();

            _numberOfTests = -1;

            for (int i = 0; i < 5; i++)
            {
                TestRadiobuttonList.Add(i, String.Format("{0}", i));
            }

            TestRadiobuttonList.Add(5, "5+");
        }

        private int _numberOfTests;
        public int NumberOfTests
        {
            get
            {
                return _numberOfTests;
            }
            set
            {
                if (_numberOfTests != value)
                {
                    _numberOfTests = value;
                    RaisePropertyChanged();

                }
            }
        }

        private Dictionary<int, string> _testRadioButtonList;
        public Dictionary<int, string> TestRadiobuttonList
        {
            get { return _testRadioButtonList; }
            set
            {
                if (_testRadioButtonList != value)
                {
                    _testRadioButtonList = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrEmpty(propName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
