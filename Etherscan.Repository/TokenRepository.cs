using Etherscan.Model.Entity;
using Etherscan.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etherscan.Repository
{
    public class TokenRepository: ITokenRepository
    {
        private string connStr;

        public TokenRepository(string connectionString) { 
            connStr = connectionString;
        }
        public int Create(TokenEntity model)
        {
            int result = 0;
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "INSERT INTO [dbo].[token]  ([symbol], [name], [total_supply], [contract_address], [total_holders]) VALUES (@symbol, @name, @total_supply, @contract_address, @total_holders)";
                conn.Open();    
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@symbol", model.Symbol);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@total_holders", model.Total_Holders);
                cmd.Parameters.AddWithValue("@total_supply", model.Total_Supply);
                cmd.Parameters.AddWithValue("@contract_address", model.Contract_Address);

                result = cmd.ExecuteNonQuery();
            }
            return result;        
        }

        public DataTable GetListToken()
        {
            DataTable result = new DataTable();
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "SELECT * ,ROUND( CAST(t.total_supply as FLOAT) * 100 / (select sum(total_supply) from token b),2) as total_supply_percent from token t ORDER BY t.total_supply DESC";
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
            }
            return result;

        }

        public int Update(int tokenId, TokenEntity model)
        {
            int result = 0;
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "UPDATE [dbo].[token] SET [symbol] = @symbol, [name]=@name, [total_supply] = @total_supply, [contract_address] = @contract_address, [total_holders] = @total_holders WHERE [id] = @id";
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", tokenId);
                cmd.Parameters.AddWithValue("@symbol", model.Symbol);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@total_holders", model.Total_Holders);
                cmd.Parameters.AddWithValue("@total_supply", model.Total_Supply);
                cmd.Parameters.AddWithValue("@contract_address", model.Contract_Address);

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
    }
}
