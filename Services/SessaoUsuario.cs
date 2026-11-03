using KappukeekiApp.Models;

namespace KappukeekiApp.Services {
    public static class SessaoUsuario {
        public static Pessoa? UsuarioAtual { get; private set; }
        public static bool IsFuncionario => UsuarioAtual?.Funcionario != null;
        public static bool IsCliente => UsuarioAtual?.Cliente != null;

        public static int NivelPermissao => UsuarioAtual?.Funcionario?.Setor?.NivelPermissao ?? 0;
        public static string NomeSetor => UsuarioAtual?.Funcionario?.Setor?.NomeSetor ?? "Nenhum";
        public static void IniciarSessao(Pessoa Pessoa) {
            UsuarioAtual = Pessoa;
        }
        public static void EncerrarSessao() {
            UsuarioAtual = null;
        }
        public static bool TemPermissaoMinima(int nivelRequerido) { 
            return NivelPermissao >= nivelRequerido;
        }
    }
}
