using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_VIII
{
    internal class Treino
    {
        public string NomeTreino {  get; set; }
        public string Descricao { get; set; }
        public int IdObjetivo { get; set; }

        Conexao conexao = new Conexao();

        public DataTable BuscarTodos()
        {
            string sql = "SELECT * FROM treino";
            DataTable dt = conexao.RetornaTabela(sql);
            return dt;
        }

        public DataTable BuscarTreinosUsuario(int idTreino)
        {
            string query = $"MATCH (a:AtividadeFisica)-[r:INCLUSA_EM_TREINO]->(t:Treino) where t.id ={idTreino} RETURN a.nomeatividade AS Atividade, a.descricao AS Descrição ,a.dificuldade AS Dificuldade, a.repeticoes AS Repetições";
            DataTable dt = conexao.RetornaTabela(query);
            return dt;
        }
        
public class TreinoRepository : IDisposable
 {
     private readonly SqlConnection _connection;
     Conexao conexao = new Conexao();

     public TreinoRepository()
     {

         try
         {
             // Inicialize sua conexão com uma string de conexão válida
             conexao.Conectar();
             _connection = conexao.Conn;
         }
         catch (Exception ex)
         {
             throw new InvalidOperationException("Erro ao inicializar a conexão com o banco de dados. Verifique a string de conexão.", ex);
         }
     }

     public void AdicionarTreinoAoUsuario(int idUsuario, int idTreino)
     {
         try
         {
             var query = "INSERT INTO treino_usuario (id_usuario, id_treino) VALUES (@IdUsuario, @IdTreino)";
             using (var command = new SqlCommand(query, _connection))
             {
                 command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                 command.Parameters.AddWithValue("@IdTreino", idTreino);
                 command.ExecuteNonQuery();
             }
         }
         catch (Exception ex)
         {
             throw new InvalidOperationException("Erro ao adicionar treino ao usuário no banco de dados.", ex);
         }
     }

     public void RemoverTreinoDoUsuario(int idUsuario, int idTreino)
     {
         try
         {
             var query = "DELETE FROM treino_usuario WHERE id_usuario = @idUsuario AND id_treino = @IdTreino";
             using (var command = new SqlCommand(query, _connection))
             {
                 command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                 command.Parameters.AddWithValue("@IdTreino", idTreino);
                 command.ExecuteNonQuery();
             }
         }
         catch (Exception ex)
         {
             throw new InvalidOperationException("Erro ao remover treino do usuário no banco de dados.", ex);
         }
     }

     public void Dispose()
     {
         if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
         {
             _connection.Close();
         }
         _connection?.Dispose();
     }
 }
    }
}
