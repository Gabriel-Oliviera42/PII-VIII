using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;


namespace PII_VIII
{
    internal class ConexaoNeo4J : IDisposable
    {
        private IDriver _driver;
        public void Conectar()
        {
            string uri = "neo4j+s://46c7c773.databases.neo4j.io";
            string user = "neo4j";
            string password = "wUXyRtpIoBERwTKY635vObjnLuXJzGWvrVBWTPM1oFc";           
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }
        public async Task ExecutarComandoAsync(string query)
        {
            Conectar();
            var session = _driver.AsyncSession();            
            await session.RunAsync(query);            
            await session.CloseAsync();
            Dispose();
        }
        public async Task<IResultCursor> ExecutarConsultaAsync(string query)
        {
            Conectar();
            var session = _driver.AsyncSession();            
            var result = await session.RunAsync(query);
            return result; 
        }

        public async Task<DataTable> DTConsulta(string query)
        {
            var dt = new DataTable();
            var result = await ExecutarConsultaAsync(query); 

            var records = await result.ToListAsync();

            if (records == null || records.Count == 0)
            {
                // Retorna o DataTable vazio
                return dt;
            }

            foreach (var key in records[0].Keys)
            {
                dt.Columns.Add(key);
            }

            // Adiciona as linhas ao DataTable
            foreach (var record in records)
            {
                var row = dt.NewRow();
                foreach (var key in record.Keys)
                {
                    row[key] = record[key].ToString();
                }
                dt.Rows.Add(row);
            }          
            return dt;
        }

        public async Task<DataSet> DSConsulta(string query)
        {
            var ds = new DataSet();
            var result = await ExecutarConsultaAsync(query);

            var records = await result.ToListAsync();

            var dt = new DataTable();

            // Cria as colunas no DataTable
            foreach (var key in records[0].Keys)
            {
                dt.Columns.Add(key);
            }

            // Adiciona as linhas ao DataTable
            foreach (var record in records)
            {
                var row = dt.NewRow();
                foreach (var key in record.Keys)
                {
                    row[key] = record[key].ToString();
                }
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt); // Adiciona o DataTable ao DataSet  
            return ds;
        }

        public async Task<bool> TestarConexaoAsync()
        {
            try
            {
                var session = _driver.AsyncSession();
                await session.RunAsync("RETURN 1"); 
                await session.CloseAsync();
                return true; // Se a execução chegar até aqui, a conexão foi bem-sucedida
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
