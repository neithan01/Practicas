namespace NetExam
{
    using System;

    internal class LocationSpecsValidator
    {
        private Context _context;
        
        public LocationSpecsValidator(Context context)
        {
            this._context = context;
        }

        public void ExistsLocation(string locationName)
        {
            if (this._context.locations.Exists(x => x.Name.Equals(locationName)))
            {
                throw new Exception();
            }
        }
    }
}
