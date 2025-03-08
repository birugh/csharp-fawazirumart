using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace csharp_lksmart
{
    public class DBHelpers
    {
        public async Task<int> ExecuteAsyncSP(string connString, string sql, DynamicParameters p)
        {
            var conn = new SqlConnection(connString);
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var a = await conn.ExecuteAsync(sql, p, null, null, CommandType.StoredProcedure);
                return a;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
        public async Task<int> ExecuteAsyncText(string connString, string sql)
        {
            var conn = new SqlConnection(connString);
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var a = await conn.ExecuteAsync(sql, null, null, null, CommandType.Text);
                return a;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
        public async Task<T> ToSingleModel<T>(string connString, string sql, DynamicParameters p = null)
        {
            var conn = new SqlConnection(connString);
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var a = await conn.QueryFirstAsync<T>(sql, p, null, null, CommandType.StoredProcedure);
                return a;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
        public async Task<IEnumerable<T>> ToModel<T>(string connString, string sql, DynamicParameters p = null)
        {
            var conn = new SqlConnection(connString);
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var a = await conn.QueryAsync<T>(sql, p, null, null, CommandType.StoredProcedure);
                return a;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
    }
}
