//@DomainCode
//MdStart
using System;
using TravelCount.Contracts.Client;

namespace TravelCount.Logic
{
    public static class Factory
    {
        public enum PersistenceType
        {
            Db,
            //Csv,
            //Ser,
        }
        public static PersistenceType Persistence { get; set; } = Factory.PersistenceType.Db;
        internal static DataContext.IContext CreateContext()
        {
            DataContext.IContext result = null;

            if (Persistence == PersistenceType.Db)
            {
                result = new DataContext.Db.DbTravelCountContext();
            }
            return result;
        }

        public static IControllerAccess<T> Create<T>() where T : Contracts.IIdentifiable
        {
            IControllerAccess<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.ITravel))
            {
                result = (IControllerAccess<T>)CreateTravelController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IExpense))
            {
                result = (IControllerAccess<T>)CreateExpenseController();
            }
            else if (typeof(T) == typeof(Contracts.Business.ITravelExpense))
            {
                result = (IControllerAccess<T>)CreateTravelExpenseController();
            }
            return result;
        }
        public static IControllerAccess<T> Create<T>(object sharedController) where T : Contracts.IIdentifiable
        {
            IControllerAccess<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.ITravel))
            {
                result = (IControllerAccess<T>)CreateTravelController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IExpense))
            {
                result = (IControllerAccess<T>)CreateExpenseController(sharedController);
            }
            else if (typeof(T) == typeof(Contracts.Business.ITravelExpense))
            {
                result = (IControllerAccess<T>)CreateTravelExpenseController(sharedController);
            }
            return result;
        }
        public static IControllerAccess<Contracts.Persistence.ITravel> CreateTravelController()
        {
            return new Controllers.Persistence.TravelController(CreateContext());
        }
        public static IControllerAccess<Contracts.Persistence.ITravel> CreateTravelController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.TravelController(controller);
        }
        public static IControllerAccess<Contracts.Persistence.IExpense> CreateExpenseController()
        {
            return new Controllers.Persistence.ExpenseController(CreateContext());
        }
        public static IControllerAccess<Contracts.Persistence.IExpense> CreateExpenseController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Persistence.ExpenseController(controller);
        }

        public static IControllerAccess<Contracts.Business.ITravelExpense> CreateTravelExpenseController()
        {
            return new Controllers.Business.TravelExpenseController(CreateContext());
        }
        public static IControllerAccess<Contracts.Business.ITravelExpense> CreateTravelExpenseController(object sharedController)
        {
            if (sharedController == null)
                throw new ArgumentNullException(nameof(sharedController));

            Controllers.ControllerObject controller = (Controllers.ControllerObject)sharedController;

            return new Controllers.Business.TravelExpenseController(controller);
        }
    }
}
//MdEnd