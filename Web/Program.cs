using Web.Persistence;
using Web.Core.Interfaces;
using Web.Persistence.Repositories;
using System;

namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            IDragonRepository _Idragon = (IDragonRepository)new DragonRepository("Dragon");
            try {

                var retval = _Idragon.Spawn();
                var dragons = _Idragon.GetAll();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

            /*
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // Example1
                var course = unitOfWork.Courses.Get(1);

                // Example2
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example3
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                unitOfWork.Courses.RemoveRange(author.Courses);
                unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
            }
            */
        }
    }
}
