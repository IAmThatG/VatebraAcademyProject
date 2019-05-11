using System;
using Microsoft.AspNetCore.Identity;

namespace ElearningApp.Data.Entities
{
    public class BaseUser : IdentityUser<long>
    {
        public BaseUser()
        {
        }
    }
}
