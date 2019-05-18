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
        private readonly SignInManager<BaseUser> _signInManager;
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;

        public AuthService(UserManager<BaseUser> userManager,
            SignInManager<BaseUser> signInManager,
            IMapper mapper, 
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> SignIn(SignInRequest signInRequest)
        {
            //fetch user from db
            var baseUser = await _userManager.FindByNameAsync(signInRequest.Username);

            //checked if user can sign-in
            var canSignIn =  _signInManager.CanSignInAsync(baseUser).Result;

            if (canSignIn)
            {
                //attempt to sign-in user
                _logger.LogInformation("Attempting to sign user in");
                var signInResult = await _signInManager.PasswordSignInAsync(baseUser, signInRequest.Password, false, false);
                if (!signInResult.Succeeded) return false;
            }
            return true;
        }

        public async Task<bool> SignUp(SignUpRequest signUpRequest)
        {
            var isCreated = false;
            //check if usrer exists
            var findUserByNameTask = _userManager.FindByNameAsync(signUpRequest.Username);
            if (!(findUserByNameTask.Result == null)) return isCreated;

            var baseUser = _mapper.Map<SignUpRequest, BaseUser>(signUpRequest);
            var identityResult = await _userManager.CreateAsync(baseUser, signUpRequest.Password);
            if (identityResult.Succeeded)
            {
                _logger.LogInformation("User created successfully");
                isCreated = true;
            }
            return isCreated;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
