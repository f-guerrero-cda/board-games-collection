using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BoardGamesCollection.DataRepository;
using BoardGamesCollection.Models;
using System.Threading.Tasks;

namespace BoardGamesCollection.Controllers
{
    public class BoardGamesController : ApiController
    {
        private BoardGameContext context = new BoardGameContext();
        private readonly IBoardGameRepository _boardGame;

        public BoardGamesController()
        {
            _boardGame = new BoardGameRepository(context);
        }
        
        public BoardGamesController(IBoardGameRepository boardGame)
        {
            _boardGame = boardGame;
        }

        // GET: api/BoardGames
        /// <summary>
        /// Gets all the Board games available.
        /// </summary>
        /// <returns>All Board Games elements in the Collection</returns>
        public HttpResponseMessage GetBoardGames()
        {
            var boardGames = _boardGame.GetBoardGames();
            if (boardGames != null)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, boardGames);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Board Games Collection not found");
        }

        // GET: api/BoardGames/5
        /// <summary>
        /// Gets the specified Board Game by id.
        /// </summary>
        /// <param name="id">Id of the element.</param>
        /// <returns>The selected Board Game record.</returns>
        [ResponseType(typeof(BoardGame))]
        public IHttpActionResult GetBoardGame(int id)
        {
            BoardGame boardGame = _boardGame.GetBoardGameByID(id);
            if (boardGame == null)
            {
                return NotFound();
            }

            return Ok(boardGame);
        }

        // PUT: api/BoardGames/5
        /// <summary>
        /// Updates the specified Board Game by Id.
        /// </summary>
        /// <param name="id">Id of the element to update.</param>
        /// <param name="boardGame">BoardGame object with new values to update.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoardGame(int id, BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardGame.Id)
            {
                return BadRequest();
            }

            _boardGame.UpdateBoardGame(boardGame);            

            try
            {
                _boardGame.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_boardGame.BoardGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BoardGames
        /// <summary>
        /// Inserts a new Board Game into the Collection.
        /// </summary>
        /// <param name="boardGame">New BoardGame object to insert into the collection.</param>
        /// <returns></returns>
        [ResponseType(typeof(BoardGame))]
        public IHttpActionResult PostBoardGame(BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _boardGame.InsertBoardGame(boardGame);
            _boardGame.Save();

            return CreatedAtRoute("DefaultApi", new { id = boardGame.Id }, boardGame);
        }

        // DELETE: api/BoardGames/5
        /// <summary>
        /// Deletes the selected Board Game by Id.
        /// </summary>
        /// <param name="id">Id of the element to delete.</param>
        /// <returns>Ok state if success.</returns>
        [ResponseType(typeof(BoardGame))]
        public IHttpActionResult DeleteBoardGame(int id)
        {
            BoardGame boardGame = _boardGame.GetBoardGameByID(id);
            if (boardGame == null)
            {
                return NotFound();
            }

            _boardGame.DeleteBoardGame(id);
            _boardGame.Save();

            return Ok(boardGame);
        }
    }
}