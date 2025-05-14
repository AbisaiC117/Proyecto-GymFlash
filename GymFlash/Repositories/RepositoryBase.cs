using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GymFlash.Model;

namespace GymFlash.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly String _connectionString;

        public RepositoryBase()
        {
            _connectionString =
                "Server = DESKTOP-9MTK8SF\\UAGESTION;" +
                "Database=GymFlashDB; " +
                "Integrated Security = true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
