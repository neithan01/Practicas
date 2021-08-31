namespace NetExam
{
    using System;

    internal class OfficeSpecsValidator
    {
        private Context _context;
        
        public OfficeSpecsValidator(Context context)
        {
            this._context = context;
        }

        public void ExistsLocation(string locationName)
        {
            if (!this._context.locations.Exists(x => x.Name.Equals(locationName)))
            {
                throw new Exception();
            }
        }
    }
}
