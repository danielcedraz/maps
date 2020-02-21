using Maps.DBO;
using Microsoft.EntityFrameworkCore;

namespace Maps.Models
{
    public class DBContextModel : DbContext
    {
        //Utilizei SQLite pelo fato de o Driver do MySql não ser compatível ainda com a versão 3.1 do .Net Core
        //e não ter tido tempo hábil para implantar o postgres. De qualquer forma, pode-se utilizar qualquer banco
        //utilizando o migrations.
        public DBContextModel() : base(new DbContextOptionsBuilder<DBContextModel>().UseSqlite("Filename=../base.db").Options)
        {

        }

        //Tabela que armazena os pontos (Waipoints) utilizados pelo usuário.
        public DbSet<Ponto> Pontos { get; set; }

        //Tabela que armazena as rotas feitas pelo usuário.
        public DbSet<Rota> Rotas { get; set; }

        //Tabela que armazena as paradas contidas em cada rota.
        public DbSet<Parada> Paradas { get; set; }
    }
}
