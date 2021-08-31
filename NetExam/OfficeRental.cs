namespace NetExam
{
    using NetExam.Abstractions;
    using NetExam.Dao.Dto;
    using NetExam.Validations;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeRental : IOfficeRental
    {
        private Context _context;
        private OfficeSpecsValidator _officeRentalValidation;
        private LocationSpecsValidator _locationSpecsValidation;
        private BookOfficeValidator _bookOfficeValidation;

        public OfficeRental(Context context)
        {
            this._context = context;
            this._officeRentalValidation = new OfficeSpecsValidator(context);
            this._locationSpecsValidation = new LocationSpecsValidator(context);
            this._bookOfficeValidation = new BookOfficeValidator(context);
        }

        public void AddLocation(LocationSpecs locationSpecs)
        {
            this._locationSpecsValidation.ExistsLocation(locationSpecs.Name);
            this._context.locations.Add(locationSpecs);
        }

        public void AddOffice(OfficeSpecs officeSpecs)
        {
            this._officeRentalValidation.ExistsLocation(officeSpecs.LocationName);
            this._context.offices.Add(officeSpecs);
        }

        public void BookOffice(BookingRequest bookingRequest)
        {
            this._bookOfficeValidation.BookOfficeCheck(bookingRequest.LocationName, bookingRequest.OfficeName);
            this._context.bookingRequests.Add(bookingRequest);
        }

        public IEnumerable<IBooking> GetBookings(string locationName, string officeName)
        {
            return this._context.bookingRequests.ToList();
        }

        public IEnumerable<ILocation> GetLocations()
        {
            return this._context.locations.ToList();
        }

        public IEnumerable<IOffice> GetOffices(string locationName)
        {
            return this._context.offices.ToList();
        }

        public IEnumerable<IOffice> GetOfficeSuggestion(SuggestionRequest suggestionRequest)
        {
            var allOfices = (this._context.offices.FindAll(x =>
            (x.MaxCapacity >= suggestionRequest.CapacityNeeded) &&
            (suggestionRequest.ResourcesNeeded.Count().Equals(0) || x.AvailableResources.Intersect(suggestionRequest.ResourcesNeeded).Count() == suggestionRequest.ResourcesNeeded.Count()))
            .ToList()).OrderBy(x => x.MaxCapacity);

            return allOfices.Join(
                             this._context.locations,
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