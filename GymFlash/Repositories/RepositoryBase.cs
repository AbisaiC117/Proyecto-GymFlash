using System;
using System.Data.SqlClient;

namespace GymFlash.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly String _connectionString;

        public RepositoryBase()
        {
            _connectionString =
                "Server = DESKTOP-B68VNIO\\VSGESTION;" +
                "Database=GymFlashDB;" +
                "Integrated Security = true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
