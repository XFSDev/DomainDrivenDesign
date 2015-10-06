using CodeTest.Domain;
using CodeTest.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeTest.Controllers
{
    public class ClassController : ApiController
    {
        [HttpGet]
        public IEnumerable<Class> Get()
        {
            ClassRepository repository = new ClassRepository();

            return repository.GetAll();
        }
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            
            ClassRepository repo = new ClassRepository();
            repo.Delete(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage Put(Class classInfo)
        {
            bool status = false;
            ClassRepository repository = new ClassRepository();

            IEnumerable<string> brokenRules;

            if (classInfo.ValidatePersistence(new ClassValidator(), out brokenRules))
            {
                bool isNew = classInfo.ClassID.Equals(0);

                if (isNew)
                {

                    status = repository.Insert(classInfo);
                }
                else
                {
                    status = repository.Save(classInfo);
                }
            }

            return this.Request.CreateResponse<bool>(HttpStatusCode.OK, status);


        }

        [HttpGet]
        public IEnumerable<Student> GetStudentsByClassID(int id)
        {
            ClassRepository repository = new ClassRepository();

            return repository.GetStudentsByClassID(id);
        }


        [HttpPost]
        public HttpResponseMessage SaveStudent(Student classInfo)
        {
            bool status = false;
            ClassRepository repository = new ClassRepository();

            IEnumerable<string> brokenRules;

            if (classInfo.ValidatePersistence(new StudentValidator(repository), out brokenRules))
            {
                bool isNew = classInfo.StudentID.Equals(0);

                if (isNew)
                {

                    status = repository.Insert(classInfo);
                }
                else
                {
                    status = repository.Save(classInfo);
                }
            }

            return this.Request.CreateResponse<bool>(HttpStatusCode.OK, status);


        }
    }
}
