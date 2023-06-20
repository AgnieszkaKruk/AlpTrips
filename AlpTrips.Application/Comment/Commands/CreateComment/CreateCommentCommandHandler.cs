using AlpTrips.Application.ApplicationUser;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        
        private readonly IUserContext _userContext;
       

        public CreateCommentCommandHandler(ICommentRepository repository, IUserContext context)
        {
            _commentRepository = repository;
            _userContext = context;

          

        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {

            request.CreatedById= _userContext.GetCurrentUser().Id;
            request.CreatedDate = DateTime.Now;
            request.User = new Domain.Entities.User();
            request.User.Email = _userContext.GetCurrentUser().Email;
            request.User.Name = _userContext.GetCurrentUser().Name;

            await _commentRepository.Create(request);

            return Unit.Value;
        }
    }
}
