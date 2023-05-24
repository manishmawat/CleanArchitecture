namespace Domain.Exceptions;

    public class CityDoesNotExistException : Exception
    {
        public CityDoesNotExistException(string cityCode) : base($"City with code:{cityCode} does not exist")
        {
        }
    }
