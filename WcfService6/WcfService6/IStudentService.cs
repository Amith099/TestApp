using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService6.Model;
using System.ServiceModel.Description;
using WcfService6;
using System.ServiceModel.Web;

namespace WcfService6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetAllStudent")]
        List<StudentContractClass> GetAllStudent();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetStudentDetails/{StudentId}")]
        StudentContractClass GetStudentDetails(string StudentId);


        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/AddNewStudent")]
        bool AddNewStudent(StudentContractClass student);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/UpdateStudent")]
        void UpdateStudent(StudentContractClass contact);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,   
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/DeleteStudent/{StudentId}")]
        void DeleteStudent(string StudentId);

    }
}
