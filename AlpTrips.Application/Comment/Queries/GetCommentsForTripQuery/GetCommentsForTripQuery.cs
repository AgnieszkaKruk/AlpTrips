using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Queries.GetCommentsForTripQuery
{
    public class GetCommentsForTripQuery: IRequest<IEnumerable<Domain.Entities.Comment>>
    {

        public string EncodedName { get; set; }
        public GetCommentsForTripQuery(string encodedName)
        {
            EncodedName = encodedName;
                
        }

        
    }
}
