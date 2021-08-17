using Dapper;
using Microsoft.Extensions.Configuration;
using Mutantes.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Mutantes.Repository
{
    public class DnaRepository
    {
        string connection = "Data Source=mutantdb.database.windows.net;Initial Catalog=mutantdb;User ID=admindb;Password=Password@1";
        public DnaRepository()
        {   
        }

        public void save(Dna dna)
        {
            using(var db = new SqlConnection(connection))
            {
                var sql = "INSERT INTO DNA (dna, isMutant) VALUES(@dna,@isMutant)";
                db.Execute(sql, new { dna= dna.dna, isMutant= dna.isMutant });
            }
        }

        public Dna findByDna(string dna)
        {
            using (var db = new SqlConnection(connection))
            {
                string sql = "select * from DNA where dna = @dna";
                return db.Query<Dna>(sql, new { dna = dna }).FirstOrDefault();
            }
        }

        public List<Dna> findAll()
        {
            using (var db = new SqlConnection(connection))
            {
                return db.Query<Dna>("select * from dna").ToList();
            }
        }


        
    }
}
