using AccessControl.Infra.CrossCutting.Interfaces.Repository;
using AccessControl.Infra.CrossCutting.Interfaces.Services;
using AccessControl.Infra.CrossCutting.Models;
using AccessControl.Infra.CrossCutting.Models.Authentication;
using AutoMapper;

namespace AccessControl.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioModel>> ObterTodosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuariosModel = _mapper.Map<IList<UsuarioModel>>(usuarios);

            return usuariosModel.ToList();
        }

        public async Task<List<UsuarioModel>> ObterUsuariosAsync(BuscarUsuario usuario)
        {
            var usuarios = await _usuarioRepository.ObterUsuario(usuario);
            var usuariosModel = _mapper.Map<IList<UsuarioModel>>(usuarios);

            return usuariosModel.ToList();
        }
    }
}