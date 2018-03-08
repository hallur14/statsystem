using System;

namespace SimpleStatsApi.Utilities.Exceptions
{
    public class  UserNotFoundException: Exception
    {
        public UserNotFoundException()
            :base("User could not be found.")
            {}
    }
}