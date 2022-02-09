using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        // 存储注册用户
        private static IList<UserDTO> _userDTOs = new List<UserDTO>();

        /// <summary>
        /// 注册方法实现
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<CommonResult> Register(UserDTO userDTO, ServerCallContext context)
        {
            _userDTOs.Add(userDTO);
            return Task.FromResult(new CommonResult
            {
                Code = "2000",
                Message = "注册成功。"
            });
        }

        /// <summary>
        /// 登陆方法实现
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<LoginResult> Login(LoginDTO userDTO, ServerCallContext context)
        {
            // TODO...

            return Task.FromResult(new LoginResult
            {
                Token = "TestToken"
            });
        }

        /// <summary>
        /// 退出方法实现
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<CommonResult> Logout(LogoutDTO userDTO, ServerCallContext context)
        {
            // TODO...

            return Task.FromResult(new CommonResult
            {
                Code = "2000",
                Message = "退出成功。"
            });
        }

        /// <summary>
        /// 获取所有用户实现
        /// </summary>
        /// <param name="empty"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<AllUser> GetAllUser(Empty empty, ServerCallContext context)
        {
            var allUser = new AllUser();
            allUser.UserList.Add(_userDTOs);

            return Task.FromResult(allUser);
        }
    }
}
