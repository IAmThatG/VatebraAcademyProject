using System;
using System.Threading.Tasks;
using AutoMapper;
using ElearningApp.Data.Entities;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ELearnngApp.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;

        public AuthService(UserManager<BaseUser> userManager, IMapper mapper, 
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> SignUp(SignUpRequest signUpRequest)
        {
            var isCreated = false;
            var baseUser = _mapper.Map<SignUpRequest, BaseUser>(signUpRequest);
            var identityResult = await _userManager.CreateAsync(baseUser, signUpRequest.Password);
            if (identityResult.Succeeded)
            {
                _logger.LogInformation("User created successfully");
                isCreated = true;
            }
            return isCreated;
        }
    }
}
