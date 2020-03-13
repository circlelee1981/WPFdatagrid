using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFdatagrid.Model
{
    public class Student : ViewModelBase //要继承这个, 后续才能成功绑定
    {
        private int id;
        private string name;

        public int ID
        {
            get => id;
            set
            {
                id = value;
                RaisePropertyChanged(); //实现通知, 从而实现后台到前台的自动绑定
            }
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }
    }
}
