using AutoMapper;
using Nxm.Conan.Users.Core.Entities.V1;
using Nxm.Conan.Users.Application.Requests;
using Nxm.Conan.Users.Application.Requests.Queries;
using Nxm.Conan.Users.Application.Responses;
using Nxm.Conan.Users.Core.Repositories.V1;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nxm.Conan.Users.Core.Repositories.V1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Nxm.Conan.Users.Core.Helpers;

namespace Nxm.Conan.Users.Core.Services.V1;
public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IOptions<AppSettings> appSettings, IUserRepository userRepository)
    {
        _appSettings = appSettings.Value;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public PagedResponse<UserResponse> GetAll(UsersParameters userParameters)
    {

        //if (!String.IsNullOrEmpty(userParameters.FirstName) || !String.IsNullOrEmpty(userParameters.LastName))
        //{

        //    return PagedList<UserResponse>.ToPagedList(
        //            _mapper.Map<IEnumerable<UserResponse>>(_userRepository.FilterBy(u => u.FirstName.ToString().ToLower() == userParameters.FirstName.ToLower() || u.LastName.ToLower() == userParameters.LastName.ToLower())),
        //                    userParameters.PageNumber,
        //                    userParameters.PageSize);
        //}

        var result = _userRepository.FindAll();

        if (!string.IsNullOrEmpty(userParameters.FirstName))
        {
            result = _userRepository.FilterBy(u => u.FirstName.Contains(userParameters.FirstName));
        }
        return PagedList<UserResponse>.ToPagedList(
                    _mapper.Map<IEnumerable<UserResponse>>(result),
                            userParameters.PageNumber,
                            userParameters.PageSize);
    }


    public Response<UserResponse> GetById(string id)
    {
        var user = _userRepository.FindOne(x => x.Id.Equals(id));
        return new Response<UserResponse>(_mapper.Map<UserResponse>(user));
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public UserResponse UpdateUser(string id, UpdateUserRequest updateUserRequest)
    {
        var user = _userRepository.FindById(id);

        _mapper.Map(updateUserRequest, user);
        user.UpdatedAt = DateTime.UtcNow;

        _userRepository.ReplaceOne(user);

        var updatedUser = new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ImageUrl = user.ImageUrl,
            Description = user.Description,
            Email = user.Email,
            Address = user.Address,
            Phone = user.Phone,
            Gender = user.Gender,
            Language = user.Language,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,

        };
        return _mapper.Map<UserResponse>(updatedUser);
    }
    public void DeleteUser(string id)
    {
        _userRepository.DeleteById(id);
    }

    public UserResponse createUser(CreateUserRequest userRequest)
    {
        var user = _mapper.Map<User>(userRequest);
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        user.Id = Guid.NewGuid().ToString();

        _userRepository.InsertOne(user);

        var createdUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            //Location = user.Location,
            //ContractDetails = user.ContractDetails,
            //Salary = user.Salary,

        };
        return _mapper.Map<UserResponse>(createdUser);
    }
}
