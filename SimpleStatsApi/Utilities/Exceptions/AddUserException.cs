using System;

namespace SimpleStatsApi.Utilities.Exceptions
{
    public class AddUserException : Exception
    {
        public AddUserException()
            :base("Error adding user to db.")
            {}
    }
}