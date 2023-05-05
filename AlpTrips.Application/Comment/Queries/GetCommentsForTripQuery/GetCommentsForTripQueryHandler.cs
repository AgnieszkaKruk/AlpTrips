using AlpTrips.Domain.Interfaces;
using MediatR;

namespace AlpTrips.Application.Comment.Queries.GetCommentsForTripQuery
{
    public class GetCommentsForTripQueryHandler : IRequestHandler<GetCommentsForTripQuery, IEnumerable<Domain.Entities.Comment>>
    {
        private ICommentRepository _commentRepository;
        public GetCommentsForTripQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Comment>> Handle(GetCommentsForTripQuery request, CancellationToken cancellationToken)
        {
           var comments = await _commentRepository.GetByEncodedName(request.EncodedName);
            return comments;
        }
    }
}
