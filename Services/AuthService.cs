using System.Linq;
using Microsoft.EntityFrameworkCore;
using KappukeekiApp.Data;
using KappukeekiApp.Models;

namespace KappukeekiApp.Services {
    public class AuthService {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context) {
            _context = context;
        }
        public (bool sucesso, string mensagem) Login(string email, string senha) {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return (false, "Preencha todos os campos.");
            var usuario = _context.Pessoas
        .Include(p => p.Funcionario)
            .ThenInclude(f => f.Setor)
        .Include(p => p.Cliente)
        .FirstOrDefault(p => p.EmailPessoa == email.Trim());

            if (usuario == null)
                return (false, "E-mail ou senha incorretos.");
            
            // 2. Regra de negócio do UML: Funcionário demitido não pode logar
            if (usuario.Funcionario != null && usuario.Funcionario.Demitido)
                return (false, "Acesso bloqueado: colaborador desativado da empresa.");

            // 3. Validação da Senha via Hash e Salt
            bool senhaValida = PasswordHelper.VerificarSenha(senha, usuario.SenhaHash, usuario.SenhaSalt);
            if (!senhaValida)
                return (false, "E-mail ou senha incorretos.");
            // 4. Inicia a sessão global
            SessaoUsuario.IniciarSessao(usuario);
            return (true, "Login realizado com sucesso!");
        
        }
    }
}
