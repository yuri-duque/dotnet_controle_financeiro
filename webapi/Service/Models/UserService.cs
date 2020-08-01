using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.Models;
using Service.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Service.Models
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<User>> GetAll()
        {
            var users = _userRepository.GetAll().ToList();

            return ServiceResponse<IList<User>>.SetSuccess(users);
        }

        public ServiceResponse<User> GetById(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
                return ServiceResponse<User>.SetError("Usuário não encontrado");

            return ServiceResponse<User>.SetSuccess(user);
        }

        public ServiceResponse<User> Save(UserRegisterDTO userDTO)
        {
            var usernameExisting = CheckUsername(userDTO.Username);

            if (usernameExisting)
                return ServiceResponse<User>.SetError("Username indisponível");

            var user = _mapper.Map<User>(userDTO);

            user.Role = "admin";

            _userRepository.Save(user);

            return ServiceResponse<User>.SetSuccess(null);
        }

        public void Update(User usuario)
        {
            _userRepository.Save(usuario);
        }

        public void Delete(long Id)
        {
            _userRepository.Delete(x => x.Id == Id);
        }

        public ServiceResponse<UserDTO> Login(UserLoginDTO usuarioDTO)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Username.ToLower().Equals(usuarioDTO.Username.ToLower()) && x.Password.Equals(usuarioDTO.Password));

            if (user == null)
                return ServiceResponse<UserDTO>.SetError("Usuário não encontrado");

            user.Password = "";

            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Token = TokenService.GenerateToken(user);

            return ServiceResponse<UserDTO>.SetSuccess(userDTO);
        }

        public ServiceResponse<UserDTO> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return ServiceResponse<UserDTO>.SetError("Usuário não encontrado");

            var user = _userRepository.FindUserByEmail(email);

            if (user == null)
                return ServiceResponse<UserDTO>.SetError("Usuário não encontrado");

            user.EmailVerifyCode = GenerateEmailCode();

            _userRepository.Update(user);

            // send email

            return ServiceResponse<UserDTO>.SetSuccess(null);
        }

        public ServiceResponse<UserDTO> NewPassword(string verifyCode)
        {
            if (string.IsNullOrEmpty(verifyCode))
                return ServiceResponse<UserDTO>.SetError("Usuário não encontrado");

            var user = _userRepository.FindUserByVerifyCode(verifyCode.ToUpper());

            if (user == null)
                return ServiceResponse<UserDTO>.SetError("Usuário não encontrado");

            user.EmailVerifyCode = null;

            _userRepository.Update(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            return ServiceResponse<UserDTO>.SetSuccess(userDTO);
        }

        private bool CheckUsername(string username)
        {
            return _userRepository.CheckUsername(username);
        }

        private string GenerateEmailCode()
        {
            var code = GenerateCode.EmailCode();

            var user = _userRepository.FindUserByVerifyCode(code);

            if (user == null)
                return code;

            return GenerateEmailCode();
        }
    }
}
