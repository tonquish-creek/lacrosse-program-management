using System;
using System.Web.Mvc;
using TonquishCreek.CQRS.Commands;
using TonquishCreek.CQRS.Queries;
using TonquishCreek.TeamManagement.Commands;
using TonquishCreek.TeamManagement.Data;
using TonquishCreek.TeamManagement.Entities;

namespace TonquishCreek.TeamManagement.Web.Controllers
{
    public class PlayersController : Controller
    {
        #region Private Field(s)
        private ICommandDispatcher _commandDispatcher;
        private IPlayerRepository _players;
        private IQueryProcessor _queryProcessor;
        #endregion

        #region Constructor(s)
        public PlayersController(IPlayerRepository players, ICommandDispatcher commandDispatcher, IQueryProcessor queryProcessor)
        {
            if (commandDispatcher == null)
            {
                throw new ArgumentNullException(nameof(commandDispatcher));
            }

            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            if (queryProcessor == null)
            {
                throw new ArgumentNullException(nameof(queryProcessor));
            }

            _commandDispatcher = commandDispatcher;
            _players = players;
            _queryProcessor = queryProcessor;
        }
        #endregion

        #region Public Method(s)
        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player model)
        {
            try
            {
                var command = new CreatePlayerCommand(model.FirstName, model.LastName);

                _commandDispatcher.Execute(command);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(Int32 id)
        {
            //var command = new DeletePlayerCommand(id);

            //_commandDispatcher.Execute(command);

            return View();
        }

        // GET: Players/Details/5
        public ActionResult Details(Int32 id)
        {
            //var query = new GetPlayerQuery(id);

            //var player = _queryProcessor.Execute(query);
            var model = _players.WithId(id);

            return View(model);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(Int32 id)
        {
            //var query = new GetPlayerQuery(id);

            //var player = _queryProcessor.Execute(query);
            var model = _players.WithId(id);

            return View(model);
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(Int32 id, Player model)
        {
            try
            {
                //var command = new UpdatePlayerCommand(model.FirstName, model.LastName);

                //_commandDispatcher.Execute(query);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players
        public ActionResult Index()
        {
            //var query = new ListPlayersQuery();

            //var list = _queryProcessor.Execute(query);
            var model = _players;

            return View(model);
        }
        #endregion
    }
}