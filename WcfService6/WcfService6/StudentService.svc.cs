using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService6.Model;
using System.ServiceModel.Description;

namespace WcfService6
{
    public class StudentService : IStudentService
    {
        StudentModelDBEntities ctx;
        public StudentService()
        {
            ctx = new StudentModelDBEntities();
        }

        public List<StudentContractClass> GetAllStudent()
        {
            var query = (from a in ctx.StudentInfoes
                         select a).Distinct();

            List<StudentContractClass> studentList = new List<StudentContractClass>();

            query.ToList().ForEach(rec =>
            {
                studentList.Add(new StudentContractClass
                {
                    ID = rec.ID,
                    Name = rec.Name,
                    Age = Convert.ToInt32(rec.Age),
                    City = rec.City  
                });
            });
            return studentList;
        }

        public StudentContractClass GetStudentDetails(string StudentId)
        {
            StudentContractClass student = new StudentContractClass();

            try
            {
                int Emp_ID = Convert.ToInt32(StudentId);
                var query = (from a in ctx.StudentInfoes
                             where a.ID.Equals(Emp_ID)
                             select a).Distinct().FirstOrDefault();

                student.ID = query.ID;
                student.Name = query.Name;
                student.Age = Convert.ToInt32(query.Age);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return student;
        }

        public bool AddNewStudent(StudentContractClass student)
        {
            try
            {
                StudentInfo std = ctx.StudentInfoes.CreateObject();
                std.ID = student.ID;
                std.Name = student.Name;
                std.Age = student.Age;
                std.City = student.City;
                ctx.StudentInfoes.AddObject(std);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }

        public void UpdateStudent(StudentContractClass student)
        {
            try
            {
                int Stud_Id = student.ID;
                StudentInfo std = ctx.StudentInfoes.Where(rec => rec.ID == Stud_Id).FirstOrDefault();
                std.Name = student.Name;
                std.Age = student.Age;
                std.City = student.City;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }

        public void DeleteStudent(string StudentId)
        {
            try
            {
                int Stud_Id = Convert.ToInt32(StudentId);
                StudentInfo std = ctx.StudentInfoes.Where(rec => rec.ID == Stud_Id).FirstOrDefault();
                ctx.StudentInfoes.DeleteObject(std);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }
    }
}
