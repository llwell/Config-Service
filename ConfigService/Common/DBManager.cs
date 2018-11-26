using Com.ACBC.Framework.Database;
using System;

namespace ConfigService.Common
{
    public class DBManager : IType
    {
        private DBType dbt;
        private string str = "";

        public DBManager()
        {
            var url = System.Environment.GetEnvironmentVariable("CoreDBUrl");
            var uid = System.Environment.GetEnvironmentVariable("CoreDBUser");
            var port = System.Environment.GetEnvironmentVariable("CoreDBPort");
            var passd = System.Environment.GetEnvironmentVariable("CoreDBPassword");

            this.str = "Server=" + url
                     + ";Port=" + port
                     + ";Database=core;Uid=" + uid
                     + ";Pwd=" + passd
                     + ";CharSet=utf8; SslMode =none;";
            Console.Write(this.str);
            this.dbt = DBType.Mysql;
        }

        public DBManager(DBType d, string s)
        {
            this.dbt = d;
            this.str = s;
        }

        public DBType getDBType()
        {
            return dbt;
        }

        public string getConnString()
        {
            return str;
        }

        public void setConnString(string s)
        {
            this.str = s;
        }
    }
}
