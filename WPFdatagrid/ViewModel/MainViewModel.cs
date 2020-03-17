using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using WPFdatagrid.DB;
using WPFdatagrid.Model;

namespace WPFdatagrid.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase //这里要继承哦, 为了绑定通知实现
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///

            localDB = new LocalDB();
            studentGridList = new ObservableCollection<Student>(); //这个不能少

            //Query("");
            SearchCommand = new RelayCommand<string>(Query);
            SearchCommand.Execute(string.Empty); //第一次进入界面时直接查询, 用这种方式来调用

            ResetCommand = new RelayCommand<string>(Reset);

        }



        private LocalDB localDB;
        private ObservableCollection<Student> studentGridList;
        public ObservableCollection<Student> StudentGridList //ObservableCollection 是个新东西
        {
            get => studentGridList; set
            {
                studentGridList = value;
                RaisePropertyChanged();
            }
        }

        public CollectionView CV { get; set; }
        public BindingSource BS;
        public CollectionViewSource CVS;
        public BindingListCollectionView BLCV;
        public ICommand Command1
        {
            get
            {
                return new DelegateCommand<string>((str) => {
                    MessageBox.Show("Command1 with parameter:" + str);
                });
            }
        }

        //private string searchStr = string.Empty; //注意这个初始值, 还是要有
        //public string SearchStr
        //{
        //    get => searchStr; set
        //    {
        //        searchStr = value;
        //        RaisePropertyChanged();
        //    }
        //}


        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand<string> ResetCommand { get; set; }


        public void Query(string name)
        {
            //name = this.SearchStr;
            var stus = localDB.GetStudents(name);
            StudentGridList = new ObservableCollection<Student>();
            foreach (var stuEnum in stus)
            {
                StudentGridList.Add(stuEnum);
            }

            //CV = new CollectionView(studentGridList);
            CVS = new CollectionViewSource();
            CVS.Source = studentGridList;
            //BLCV = new BindingListCollectionView(StudentGridList);
            

        }

        public void Reset(string name)
        {
            var stus = localDB.GetStudents(name);
            StudentGridList = new ObservableCollection<Student>();
            foreach (var stuEnum in stus)
            {
                StudentGridList.Add(stuEnum);
            }
        }




    }
}