using Microsoft.EntityFrameworkCore;
using SqlComputeExercise.Compute;
using SqlComputeExercise.Compute.Interface;
using SqlComputeExercise.ConsoleTools;
using SqlComputeExercise.ConsoleTools.Interface;
using SqlComputeExercise.Data;
using SqlComputeExercise.Data.Interface;
using SqlComputeExercise.Menu;
using SqlComputeExercise.Menu.Interface;
using System;
using Unity;

namespace SqlComputeExercise
{
    class Program
    {
        static UnityContainer iocContainer;
        static void Main(string[] args)
        {
            try
            {
                Init();
                Start();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
        }
        static void Init() 
        {
            iocContainer = new UnityContainer();
            iocContainer.RegisterType<IMenuComponent, MenuComponent>();
            iocContainer.RegisterType<IReader, Reader>();
            iocContainer.RegisterType<IWriter, Writer>();
            iocContainer.RegisterType<IInputInterpretor, InputInterpretor>();
            iocContainer.RegisterType<IDataBaseContext, DataBaseContext>();
            iocContainer.RegisterType<DbContext, DataBaseContext>();
            iocContainer.RegisterType<ICompute, LinqCompute>("Linq");
            iocContainer.RegisterType<ICompute, LambdaCompute>("Lambda");
            iocContainer.RegisterType<ICompute, SqlCompute>("Sql");
            iocContainer.RegisterType<ICompute, FiboCompute>("Fibo");
            iocContainer.RegisterType<ICompute, PreviousCompute>("P");
            iocContainer.RegisterInstance<UnityContainer>(iocContainer);
        }
        static void Start()
        {
            try
            {
                iocContainer.Resolve<IMenuComponent>().ManageWelcomeMenu();
            }
            catch(Exception e) {
                Console.WriteLine(e.InnerException);
            }
        }
    }
}
