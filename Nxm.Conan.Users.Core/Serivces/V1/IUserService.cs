using Conan_1.Models;
using Conan_1.Models.Requests;
using Conan_1.Models.Requests.Queries;
using Conan_1.Models.Responses;


namespace Conan_1.Services.V1
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
