using AlpTrips.Application.Comment.Commands.DeleteComment;
using AlpTrips.Application.Comment.Commands.EditComment;
using AlpTrips.Application.Comment.Queries.GetAllCommentsQuery;
using AlpTrips.Application.Comment.Queries.GetCommentByIdQuery;
using AlpTrips.Application.Comment.Queries.GetCommentsForTripQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlpsTrips.MVC.Controllers
{
    public class CommentController : Controller
    {

        private IWebHostEnvironment _webHostEnviroment;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommentController(IWebHostEnvironment webHostEnviroment, IMediator mediator, IMapper mapper)
        {
            _webHostEnviroment = webHostEnviroment;
            _mediator = mediator;
            _mapper = mapper;
        }


        // GET: Comments
        public async Task<IActionResult> Index()

        {


            var allComments = await _mediator.Send(new GetAllCommentsQuery());
            return View(allComments);
        }




        // GET: Trip/encodedName/Comments

        [Route("Trip/{encodedName}/Comments")]
        public async Task<IActionResult> CommentsForTrip(string encodedName)
        {
            var commentsForTrip = await _mediator.Send(new GetCommentsForTripQuery(encodedName));
            return View(commentsForTrip);
        }

        // GET: Comment/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }




        // GET: Comments/id/Edit
        [HttpGet]
        [Route("Comments/{id}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery(id));
            EditCommentCommand model = _mapper.Map<EditCommentCommand>(comment);
            return View(model);
        }



        // POST: Comments/id/Edit
        [HttpPost]
        [Route("Comments/{id}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditCommentCommand editCommentCommand)
        {
            await _mediator.Send(editCommentCommand);
            return RedirectToAction(nameof(Index));

        }

        //GET: Comments/id/Delete
        [Route("Comments/{id}/Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, DeleteCommentCommand deleteCommentCommand)
        {
            var comment = await _mediator.Send(deleteCommentCommand);
            return RedirectToAction(nameof(Index));

        }


        //POST: Comments/id/Delete
        [HttpPost]
        [Route("Comments/{id}/Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirm(int id, DeleteCommentCommand deleteCommentCommand)
        {
            var comment = await _mediator.Send(deleteCommentCommand);
            return RedirectToAction(nameof(Index));

        }


    }
}
