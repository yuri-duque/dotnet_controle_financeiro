using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.ModelsRepository;
using service.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Service.Models
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _userRepository;
        private readonly IMapper _mapper;

        public UsuarioService(UsuarioRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceResponse<IList<Usuario>> GetAll()
        {
            var users = _userRepository.GetAll().ToList();

            return ServiceResponse<IList<Usuario>>.SetSuccess(users);
        }

        public ServiceResponse<Usuario> GetById(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
                return ServiceResponse<Usuario>.SetError("Usuário não encontrado");

            return ServiceResponse<Usuario>.SetSuccess(user);
        }

        public ServiceResponse<Usuario> Save(UserRegisterDTO userDTO)
        {
            var usernameExisting = CheckUsername(userDTO.Username);

            if (usernameExisting)
                return ServiceResponse<Usuario>.SetError("Username indisponível");

            var user = _mapper.Map<Usuario>(userDTO);

            _userRepository.Save(user);

            return ServiceResponse<Usuario>.SetSuccess(null);
        }

        public void Update(Usuario usuario)
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

        private bool CheckUsername(string username)
        {
            return _userRepository.CheckUsername(username);
        }
    }
}
