using Nxm.Conan.Users.Application.Requests;
using Nxm.Conan.Users.Application.Requests.Queries;
using Nxm.Conan.Users.Application.Responses;


namespace Nxm.Conan.Users.Core.Services.V1
{
    public interface IUserService
    {
        UserResponse createUser(CreateUserRequest userRequest);

        PagedResponse<UserResponse> GetAll(UsersParameters userParameters);
        Response<UserResponse> GetById(string id);
        UserResponse UpdateUser(string id, UpdateUserRequest updateUserRequest);
        void DeleteUser(string id);
    }
}
