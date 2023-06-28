﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Entities
{
   
        public class Event
        {
            public int Id { get; set; }

            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Text { get; set; }
            public string Color { get; set; }
            public User User { get; set; }
            public int UserId { get; set; }

          //  public EventStatus Status { get; set; }

            public bool CanBeAddedToList;

            //public void SetColor()
            //{

            //    switch (Status)
            //    {
            //        case EventStatus.Free:
            //            Color = "Green";
            //            break;
            //        case EventStatus.Booked:
            //            Color = "Orange";
            //            break;
            //        case EventStatus.Rejected:
            //            Color = "Red";
            //            break;
            //        case EventStatus.Accepted:
            //            Color = "Blue";
            //            break;
            //    }
            //}

            //public void SetBookedStatus()
            //{
            //    Status = EventStatus.Booked;
            //}
            //public void SetRejectedStatus()
            //{
            //    Status = EventStatus.Rejected;
            //}
            //public void SetAcceptedStatus()
            //{
            //    Status = EventStatus.Accepted;
            //}

        }
    }
