using AutoMapper;
using RegisterLogin.Api.Data.Entities;
using RegisterLogin.Api.Data.Repositories;
using RegisterLogin.Api.Domain.Models.Request;
using RegisterLogin.Api.Domain.Models.Response;
using Signa.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegisterLogin.Api.Busines
{
    public class LoginBL
    {
        private readonly IMapper _mapper;
        private readonly LoginRepository _loginRepository;

        public LoginBL(LoginRepository loginRepository, IMapper mapper)
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
        }

        public int Insert(LoginRequest loginRequest)
        {
            var loginEntity = _mapper.Map<LoginEntity>(loginRequest);
            var idLogin = _loginRepository.Insert(loginEntity);

            return idLogin;
        }
        public int Update(LoginUpdateRequest loginUpdateRequest)
        {
            var login = _loginRepository.GetLoginById(loginUpdateRequest.IdLogin); //para saber qual é o Id do login

            if (login == null) //if (string.IsNullOrWhiteSpace(nome)
            {
                throw new SignaRegraNegocioException("Nenhum login foi encontrado");
            }

            var loginEntity = _mapper.Map<LoginEntity>(loginUpdateRequest);
            var usuario = _loginRepository.Update(loginEntity);

            return usuario;
        }
        public LoginResponse GetLoginById(int id)
        {
            var loginEntity = _loginRepository.GetLogin(id);
            var loginResponse = _mapper.Map<LoginResponse>(loginEntity);

            return loginResponse;
        }
        public IEnumerable<LoginResponse> GetAllLogin()
        {
            var loginEntities = _loginRepository.GetAllLogin();
            var loginResponse = loginEntities.Select(x => _mapper.Map<LoginResponse>(x));

            return loginResponse;
        }
        public int Delete(int id)
        {
            var loginEntity = _loginRepository.GetLoginById(id);

            if (loginEntity != null) //if(idAluno != null) 
            {
                var linhasAfetadas = _loginRepository.Delete(id); //retrun _alunoRepository.Delete (id);

                return linhasAfetadas;
            }
            else
            {
                throw new SignaRegraNegocioException("Erro ao excluir o aluno, contate o administrador");
            }
        }
    }
}
