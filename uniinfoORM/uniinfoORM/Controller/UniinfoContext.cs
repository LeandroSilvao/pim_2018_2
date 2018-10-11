using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using uniinfoORM.Controller.Configurations;
using uniinfoORM.Model;

namespace uniinfoORM.Controller
{
    public class UniinfoContext : DbContext
    {
        private SqlConnection conexao;

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Loginn> Logins { get; set; }
        public DbSet<tipoProblema> tiposDeProblema { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<ChamadoAtendimento> ChamadosAtendimento {get ; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.conexao = new SqlConnection());
            this.conexao.ConnectionString = (@"Data Source = JORGE\SQLEXPRESS;
                                            Initial Catalog = UniinfoDB;
                                            User Id = gestor; Password = gestor;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new LoginnConfiguration());
            modelBuilder.ApplyConfiguration(new tipoProblemaConfiguration());
            modelBuilder.ApplyConfiguration(new ChamadoConfiguration());
            modelBuilder.ApplyConfiguration(new ChamadoAtendimentoConfiguration());
        }
    }
}
