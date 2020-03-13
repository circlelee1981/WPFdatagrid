using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
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
    public class MainViewModel : ViewModelBase //����Ҫ�̳�Ŷ, Ϊ�˰�֪ͨʵ��
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
            studentGridList = new ObservableCollection<Student>(); //���������

            //Query("");
            SearchCommand = new RelayCommand<string>(Query);
            SearchCommand.Execute(string.Empty); //��һ�ν������ʱֱ�Ӳ�ѯ, �����ַ�ʽ������

            ResetCommand = new RelayCommand<string>(Reset);
        }

        private LocalDB localDB;
        private ObservableCollection<Student> studentGridList;
        public ObservableCollection<Student> StudentGridList //ObservableCollection �Ǹ��¶���
        {
            get => studentGridList; set
            {
                studentGridList = value;
                RaisePropertyChanged();
            }
        }


        //private string searchStr = string.Empty; //ע�������ʼֵ, ����Ҫ��
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