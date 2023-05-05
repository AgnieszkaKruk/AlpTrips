using AlpTrips.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Queries.GetAllCommentsQuery
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery,IEnumerable<Domain.Entities.Comment>>
    {
        private ICommentRepository _commentRepository;

        public GetAllCommentsQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;   
        }

        public async Task<IEnumerable<Domain.Entities.Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var allComments =  await _commentRepository.GetAll();
            return allComments;
        }
    }
}
