using KappukeekiApp.Data;
using KappukeekiApp.Models;
using KappukeekiApp.Services;
using Microsoft.EntityFrameworkCore;

namespace KappukeekiApp {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            
            ApplicationConfiguration.Initialize();

            using (var context = new AppDbContext()) {
                context.Database.Migrate();
                if (!context.Pessoas.Any()) {
                    var setorAdmin = new Setor { NomeSetor = "Administração", NivelPermissao = 3 };
                    context.Setores.Add(setorAdmin);
                    context.SaveChanges();

                    var (hash, salt) = PasswordHelper.GerarHashESalt("admin123");

                    var admin = new Pessoa {
                        NomePessoa = "Administrador",
                        EmailPessoa = "admin@kappukeeki.com" +
                        "",
                        IdadePessoa = 30,
                        SenhaHash = hash,
                        SenhaSalt = salt,
                        Funcionario = new Funcionario {
                            IdSetor = setorAdmin.IdSetor,
                            Demitido = false,
                            DataContrato = DateTime.Now
                        }


                    };
                    context.Pessoas.Add(admin);
                    context.SaveChanges();
                }
            }




            using (var login = new LoginForm()) {
                if (login.ShowDialog() == DialogResult.OK) {
                    Application.Run(new Form1());
                }
            }
            
        }
    }
}