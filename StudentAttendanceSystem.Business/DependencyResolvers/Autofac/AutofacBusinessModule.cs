using Autofac;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Business.Concrete;
using StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching.Microsoft;
using StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.DataAccess.Concrete.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Abstractions;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using StudentAttendanceSystem.Core.Utilities.Interceptors;
using InstructorAttendanceSystem.Business.Concrete;
using LectureHourAttendanceSystem.Business.Concrete;

namespace StudentAttendanceSystem.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfLectureDal>().As<ILectureDal>().SingleInstance();
            builder.RegisterType<EfLectureHourDal>().As<ILectureHourDal>().SingleInstance();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();
            builder.RegisterType<EfInstructorDal>().As<IInstructorDal>().SingleInstance();
            builder.RegisterType<EfStudentAttendanceDal>().As<IStudentAttendanceDal>().SingleInstance();
            builder.RegisterType<EfStudentSchoolCardDal>().As<IStudentSchoolCardDal>().SingleInstance();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();
            builder.RegisterType<EfFacultyDal>().As<IFacultyDal>().SingleInstance();

            builder.RegisterType<LectureManager>().As<ILectureService>().SingleInstance();
            builder.RegisterType<StudentAttendanceManager>().As<IStudentAttendanceService>().SingleInstance();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<InstructorManager>().As<IInstructorService>().SingleInstance();
            builder.RegisterType<LectureHourManager>().As<ILectureHourService>().SingleInstance();
            builder.RegisterType<StudentSchoolCardManager>().As<IStudentSchoolCardService>().SingleInstance();
            builder.RegisterType<FacultyManager>().As<IFacultyService>().SingleInstance();

            // Register all aspects to interfaces that registered previously 

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
