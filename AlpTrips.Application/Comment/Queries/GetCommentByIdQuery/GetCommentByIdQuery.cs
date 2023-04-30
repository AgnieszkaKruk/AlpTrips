using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Queries.GetCommentByIdQuery
{
    public class GetCommentByIdQuery : IRequest<Domain.Entities.Comment>
    {
        public int Id { get; set; }
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
