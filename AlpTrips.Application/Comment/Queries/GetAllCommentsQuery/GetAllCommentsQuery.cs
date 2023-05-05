using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Queries.GetAllCommentsQuery
{
    public class GetAllCommentsQuery: IRequest<IEnumerable<Domain.Entities.Comment>>
    {
    

    }
}
