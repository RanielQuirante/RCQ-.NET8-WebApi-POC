using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WebApiNet8POC.Models.Dtos.Request;
using WebApiNet8POC.Models.Dtos.Response;
using WebApiNet8POC.Models.Entities;
using WebApiNet8POC.Repositories.Interfaces;
using WebApiNet8POC.Services.Interfaces;

namespace WebApiNet8POC.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRequestDto> _userRequestValidator;
        private readonly IMemoryCacheService _memoryCacheService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, IValidator<UserRequestDto> userRequestValidator, IMemoryCacheService memoryCacheService, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userRequestValidator = userRequestValidator;
            _memoryCacheService = memoryCacheService;
            _logger = logger;
        }

        public async Task<List<UserResponseDto>> GetUsersAsync()
        {
            if (_memoryCacheService.GetCache<List<UserResponseDto>>("get-users-async") != null)
            {
                _logger.LogInformation("Retrieved users from cache.");
                return _memoryCacheService.GetCache<List<UserResponseDto>>("get-users-async");
            }

            var users = await _userRepository.GetUsersAsync();
            if (users == null || users.Count == 0)
            {
                _logger.LogInformation("No users found in the database.");
                return new List<UserResponseDto>();
            }

            _logger.LogInformation("Set cache for users for one day.");
            var mapResult = _mapper.Map<List<UserResponseDto>>(users);
            _memoryCacheService.SetCacheOneDay("get-users-async", mapResult);

            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<int> CreateUserAsync(UserRequestDto userDto)
        {
            var validationResult = await _userRequestValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = _mapper.Map<UserEntity>(userDto);
            return await _userRepository.CreateAddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserRequestDto userDto)
        {
            var validationResult = await _userRequestValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            _mapper.Map(userDto, existingUser);
            await _userRepository.UpdateUserAsync(existingUser);
        }
    }
}