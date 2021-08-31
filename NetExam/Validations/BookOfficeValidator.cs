namespace NetExam.Validations
{
    using System;
    using System.Linq;

    internal class BookOfficeValidator
    {
        private Context _context;

        public BookOfficeValidator(Context context)
        {
            this._context = context;
        }

        public void BookOfficeCheck(string locationName, string officeName)
        {
            if (this._context.bookingRequests.Any(x => x.LocationName.Equals(locationName) && x.OfficeName.Equals(officeName)))
            {
                throw new Exception();
            }
        }
    }
}
