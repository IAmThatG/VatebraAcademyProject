using System;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;
using ELearnngApp.Domain.ApiRequestModels;

namespace ELearnngApp.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignUp(SignUpRequest signUpRequest);
    }
}
