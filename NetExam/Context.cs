using NetExam.Abstractions;
using NetExam.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam
{
    public sealed class Context
    {
        public List<LocationSpecs> locations { get; set; }
        public List<OfficeSpecs> offices { get; set; }
        public List<BookingRequest> bookingRequests { get; set; }
        public List<SuggestionRequest> suggestionRequests { get; set; }

        public Context()
        {
            this.locations = new List<LocationSpecs>();
            this.offices = new List<OfficeSpecs>();
            this.bookingRequests = new List<BookingRequest>();
            this.suggestionRequests = new List<SuggestionRequest>();
        }
    }
}
