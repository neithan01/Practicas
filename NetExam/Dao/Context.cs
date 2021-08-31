namespace NetExam
{
    using NetExam.Dao.Dto;
    using System.Collections.Generic;

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
