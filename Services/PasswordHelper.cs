using System;
using System.Security.Cryptography;

namespace KappukeekiApp.Services {
    public static class PasswordHelper {
        public static (string hash, string salt) GerarHashESalt(string senha) {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            string salt = Convert.ToBase64String(saltBytes);

            using var pbkdf2 = new Rfc2898DeriveBytes(senha, saltBytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            string hash = Convert.ToBase64String(hashBytes);

            return (hash, salt);

        }
        public static bool VerificarSenha(string senhaDigitada, string hashArmazenado, string saltArmazenado) {
            byte[] saltbytes = Convert.FromBase64String(saltArmazenado);

            using var pbkdf2 = new Rfc2898DeriveBytes(senhaDigitada, saltbytes, 100_000, HashAlgorithmName.SHA256);
            byte[] hashCalculado = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hashCalculado, Convert.FromBase64String(hashArmazenado));
        }

    }
}
