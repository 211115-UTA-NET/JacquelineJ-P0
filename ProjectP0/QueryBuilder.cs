using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class QueryBuilder
    { 
        private string? _query;
        public string query()
        {
            Console.WriteLine("Enter Query tobe executed :");
            _query = Console.ReadLine();
            StringBuilder stringbuilderObject = new StringBuilder();
            //stringbuilderObject.Append("Select * from Customer");
            stringbuilderObject.Append(_query);
            string sqlQuery = stringbuilderObject.ToString();

            return sqlQuery;

        }

    }
}
