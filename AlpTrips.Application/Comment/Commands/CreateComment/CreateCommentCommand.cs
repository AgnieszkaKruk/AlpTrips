﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Comment.Commands.CreateComment
{
    public class CreateCommentCommand : Domain.Entities.Comment, IRequest
    {
    }
}
