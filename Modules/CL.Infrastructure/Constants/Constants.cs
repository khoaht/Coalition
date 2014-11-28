﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Infrastructure.Constants
{
    public class Constants    
    {
        public const string AppConnection = "AppConnection";

        public const string Message_LoginSuccessful = "Login successful.";

        public const string Message_LoginUnsuccessful = "Login unsuccessful.";

        public const string Message_InvalidLogin = "Invalid UserName or Password.";

        public const string GoogleAPIKey = "AIzaSyB1oRJrd_IJAhXhZoICLTuxEf23hrVBh4I";
    }

    public struct UserRoles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
    }
}
