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
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IList<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll().ToList();
        }

        public Usuario GetById(long id)
        {
            return _usuarioRepository.Find(id);
        }

        public void Save(Usuario usuario)
        {
            _usuarioRepository.Save(usuario);
        }

        public void Update(Usuario usuario)
        {
            _usuarioRepository.Save(usuario);
        }

        public void Delete(long Id)
        {
            _usuarioRepository.Delete(x => x.Id == Id);
        }

        public Usuario Login(UsuarioLoginDTO usuarioDTO)
        {
            var user = GetAll().FirstOrDefault(x => x.Username.ToLower().Equals(usuarioDTO.Username.ToLower()) && x.Password.Equals(usuarioDTO.Password));

            return user;
        }

        public bool VerificarDisponibilidadeUsername(string username)
        {
            return _usuarioRepository.VerificarExistencia(username);
        }
    }
}
