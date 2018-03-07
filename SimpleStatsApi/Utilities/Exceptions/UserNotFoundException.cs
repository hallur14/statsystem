using System;

namespace SimpleStatsApi.Utilites.Exceptions
{
    public class  UserNotFoundException: Exception
    {
        public UserNotFoundException()
            :base("User could not be found.")
            {}
    }
}