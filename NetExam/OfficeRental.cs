namespace NetExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NetExam.Abstractions;
    using NetExam.Dto;

    public class OfficeRental : IOfficeRental
    {
        private Context Context;

        public OfficeRental(Context context)
        {
            Context = context;
        }

        public void AddLocation(LocationSpecs locationSpecs)
        {
            if (this.Context.locations.Exists(x => x.Name.Equals(locationSpecs.Name)))
            {
                throw new Exception();
            }
            Context.locations.Add(locationSpecs);
        }

        public void AddOffice(OfficeSpecs officeSpecs)
        {
            if (!this.Context.locations.Exists(x => x.Name.Equals(officeSpecs.LocationName)))
            {
                throw new Exception();
            }
            this.Context.offices.Add(officeSpecs);
        }

        public void BookOffice(BookingRequest bookingRequest)
        {
            if (this.Context.bookingRequests.Any(x => x.LocationName.Equals(bookingRequest.LocationName) && x.OfficeName.Equals(bookingRequest.OfficeName)))
            {
                throw new Exception();
            }
            this.Context.bookingRequests.Add(bookingRequest);
        }

        public IEnumerable<IBooking> GetBookings(string locationName, string officeName)
        {
            return Context.bookingRequests.ToList();
        }

        public IEnumerable<ILocation> GetLocations()
        {
            return Context.locations.ToList();
        }

        public IEnumerable<IOffice> GetOffices(string locationName)
        {
            return Context.offices.ToList();
        }

        public IEnumerable<IOffice> GetOfficeSuggestion(SuggestionRequest suggestionRequest)
        {
            var allOfices = (Context.offices.FindAll(x =>
            (x.MaxCapacity >= suggestionRequest.CapacityNeeded) &&
            (suggestionRequest.ResourcesNeeded.Count().Equals(0) || x.AvailableResources.Intersect(suggestionRequest.ResourcesNeeded).Count() == suggestionRequest.ResourcesNeeded.Count()))
            .ToList()).OrderBy(x => x.MaxCapacity);

            return allOfices.Join(
                             Context.locations,
                             office => office.LocationName,
                             location => location.Name,
                             (office, location) => new Office
                             {
                                 Name = office.Name,
                                 LocationName = office.LocationName
                             }).ToList();
        }
    }
}