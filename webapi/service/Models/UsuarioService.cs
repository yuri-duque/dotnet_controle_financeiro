using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Repository.ModelsRepository;
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

        public IList<Usuario> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public Usuario GetById(long id)
        {
            return _userRepository.Find(id);
        }

        public void Save(UsuarioCadastroDTO userDTO)
        {
            var user = _mapper.Map<Usuario>(userDTO);

            _userRepository.Save(user);
        }

        public void Update(Usuario usuario)
        {
            _userRepository.Save(usuario);
        }

        public void Delete(long Id)
        {
            _userRepository.Delete(x => x.Id == Id);
        }

        public Usuario Login(UsuarioLoginDTO usuarioDTO)
        {
            var user = GetAll().FirstOrDefault(x => x.Username.ToLower().Equals(usuarioDTO.Username.ToLower()) && x.Password.Equals(usuarioDTO.Password));

            return user;
        }

        public bool CheckUsername(string username)
        {
            return _userRepository.CheckUsername(username);
        }
    }
}
