using System;
using Microsoft.AspNetCore.Identity;

namespace ElearningApp.Data.Entities
{
    public class BaseRole : IdentityRole<long>
    {
        public BaseRole()
        {
        }
    }
}
