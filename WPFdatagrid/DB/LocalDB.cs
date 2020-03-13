using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFdatagrid.Model;

namespace WPFdatagrid.DB
{
    public class LocalDB
    {
        public LocalDB()
        {
            Students = new List<Student> { 
                new Student{ID=1, Name="范冰冰"},
                new Student{ID=2, Name="蒋勤勤"},
                new Student{ID=3, Name="杨幂"}
            };
        }

        private List<Student> Students { get; set; }

        public List<Student> GetStudents(string name) //根据name参数查找
        {
            return Students.Where(x => x.Name.Contains(name)).ToList();
        }

        public void AddStudent(Student stu)
        {
            if (stu!=null)
            {
                Students.Add(stu);
            }
        }

        public void DelStudent(int id)
        {
            var stu = Students.FirstOrDefault(x => x.ID == id);
            if (stu!= null)
            {
                Students.Remove(stu);
            }
        }

        public void EditStudent(Student student) //修改部分涉及弹窗
        {
            var stu = Students.FirstOrDefault(x => x.ID == student.ID);
            if (stu != null)
            {
                var tempStudent = new Student { ID = student.ID, Name = student.Name };
                //为什么要做一个新的student呢, 因为如果直接对查出来的student做修改, 那么用户即便不点保存, 也会修改成功...

                //后面的涉及弹窗什么判断的, 后续再写

            }
        }


    }
}
