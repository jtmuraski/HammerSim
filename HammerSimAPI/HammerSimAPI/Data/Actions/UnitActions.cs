using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using HammerSimAPI.Models.Units;

namespace HammerSimAPI.Data.Actions
{
    public class UnitActions : IUnitActions
    {
        private IConfiguration _config;
        private readonly string? _conn;

        public UnitActions(IConfiguration config, string connectionStringName = "Default")
        {
            _config = config;
            _conn = _config.GetConnectionString(connectionStringName);

        }

        /// <summary>
        /// Save the data for a new unit to the database
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task AddUnit(Unit unit)
        {
            using (IDbConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                await conn.ExecuteAsync("spCreateNewUnit", unit, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
