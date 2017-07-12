using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using TonquishCreek.CQRS.Commands;
using TonquishCreek.CQRS.Events;
using TonquishCreek.CQRS.Queries;
using TonquishCreek.TeamManagement.CommandHandlers;
using TonquishCreek.TeamManagement.Commands;
using TonquishCreek.TeamManagement.Data;

namespace TonquishCreek.TeamManagement.Web
{
    public static class ContainerConfig
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Configure()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterTypes(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterTypes(Container container)
        {
            // CQRS Plumbing
            container.RegisterSingleton<ICommandDispatcher, CommandDispatcher>();
            container.RegisterSingleton(typeof(ICommandHandlerFactory), () => new CommandHandlerFactory(container));

            container.RegisterSingleton<IEventBroker, EventBroker>();
            container.RegisterSingleton(typeof(IEventHandlerFactory), () => new EventHandlerFactory(container));

            container.RegisterSingleton<IQueryProcessor, QueryProcessor>();
            container.RegisterSingleton(typeof(IQueryHandlerFactory), () => new QueryHandlerFactory(container));

            // Application Stuff
            container.Register<ICommandHandler<CreatePlayerCommand>, CreatePlayerCommandHandler>(Lifestyle.Scoped);

            container.Register<IPlayerRepository, DummyPlayerRepository>(Lifestyle.Scoped);
        }

        private class CommandHandlerFactory : ICommandHandlerFactory
        {
            private Container _container;

            public CommandHandlerFactory(Container container)
            {
                _container = container;
            }

            public ICommandHandler<T> CreateHandlerFor<T>()
                where T : ICommand
            {
                return _container.GetInstance<ICommandHandler<T>>();
            }

            public void Dispose()
            {
            }

            public void Release<T>(ICommandHandler<T> handler)
                where T : ICommand
            {
            }
        }

        private class EventHandlerFactory : IEventHandlerFactory
        {
            private Container _container;

            public EventHandlerFactory(Container container)
            {
                _container = container;
            }

            public IEnumerable<IEventHandler<T>> CreateHandlersFor<T>()
                where T : IEvent
            {
                return _container.GetAllInstances<IEventHandler<T>>();
            }

            public void Dispose()
            {
            }

            public void Release<T>(IEventHandler<T> handler)
                where T : IEvent
            {
            }
        }

        private class QueryHandlerFactory : IQueryHandlerFactory
        {
            private Container _container;

            public QueryHandlerFactory(Container container)
            {
                _container = container;
            }

            public IQueryHandler<TResult> CreateHandlerFor<TResult>(IQuery<TResult> query)
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

                var handler = _container.GetInstance(handlerType);

                return handler as IQueryHandler<TResult>;
            }

            public void Dispose()
            {
            }

            public void Release<TResult>(IQueryHandler<TResult> handler)
            {
            }
        }
    }
}