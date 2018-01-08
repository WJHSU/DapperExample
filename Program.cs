using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Z.Dapper.Plus;
using System.Transactions;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SqlConnection("Data Source = {your data source}; Initial Catalog = {your database name}; User ID = {your user id}; Password = {your pwd}"))
            {
                ////Dapper

                //Query (StoredProcedure)
                var querySPStr = "csp_GetAllDapperRecord";

                var SPeffectRows = conn.Query<Dapper>(querySPStr, new { code = "123", user = "joelhsu" }, null, false, null, System.Data.CommandType.StoredProcedure);

                var queryStr = "Select * From Dapper Where Dapper_Code = @code AND Dapper_CreateUser = @user";

                //Query(Strong Type)
                var effectRows = conn.Query<Dapper>(queryStr, new { code = "123", user = "joelhsu" });

                //Query(Anonymous)
                var AnonymousEffectRows = conn.Query(queryStr, new { code = "123", user = "joelhsu" });

                //Query(Join Anonymous)
                var joinQueryStr = "SELECT * FROM Dapper D INNER JOIN Reppad R ON D.Dapper_Id = R.Reppad_Id WHERE Dapper_Id=@sqlParams";

                var joinEffectRows = conn.Query(joinQueryStr, new { sqlParams = 1 });

                //Query(Join StrongType)
                var joinAnonymousQueryStr = "SELECT * FROM Dapper D INNER JOIN Reppad R ON D.Dapper_Id = R.Reppad_Id WHERE Dapper_Id=@sqlParams";

                var joinAnonymousEffectRows = conn.Query<DapperReppad>(joinQueryStr, new { sqlParams = 1 });

                //AsyncQuery
                var asyncResult = conn.QueryAsync(joinQueryStr, new { sqlParams = 1 });

                var result = asyncResult.Result;

                //Insert
                var insertStr = "INSERT INTO Dapper Values (@Dapper_Code,@Dapper_IsTrue,@Dapper_Integer,@Dapper_CreateDateTime,@Dapper_CreateDateTimeTwo,@Dapper_CreateUser,@Dapper_NullableInteger)";

                var insertEntity = new Dapper
                {
                    Dapper_Code = "12345",
                    Dapper_IsTrue = true,
                    Dapper_Integer = 1,
                    Dapper_CreateDateTime = DateTime.Now,
                    Dapper_CreateDateTimeTwo = DateTime.Now,
                    Dapper_CreateUser = "J",
                    Dapper_NullableInteger = null
                };

                conn.Execute(insertStr, insertEntity);

                //Insert multiple record
                var insertEntityList = new List<Dapper>();

                for (int i = 0; i < 100; i++)
                {
                    insertEntityList.Add(new Dapper
                    {
                        Dapper_Code = "12345",
                        Dapper_IsTrue = true,
                        Dapper_Integer = i,
                        Dapper_CreateDateTime = DateTime.Now,
                        Dapper_CreateDateTimeTwo = DateTime.Now,
                        Dapper_CreateUser = "J",
                        Dapper_NullableInteger = null
                    });
                }

                conn.Execute(insertStr, insertEntityList);

                //Update
                var updateStr = "UPDATE Dapper SET Dapper_Code = @code WHERE Dapper_Id = @id";

                conn.Execute(updateStr, new { code = "LetsUpdate", id = 889002 });

                //Update Multiple Record
                conn.Execute(updateStr, new[] { new { code = "LetsUpdate1", id = 889002 }, new { code = "LetsUpdate2", id = 889001 } });

                //DELETE
                var deleteStr = "DELETE FROM Dapper WHERE Dapper_Id = @id";

                conn.Execute(deleteStr, new { id = 889001 });

                ////Dapper Plus

                //BulkInsert 1000萬筆48秒
                var bulkInsertEntityList = new List<Dapper>();

                for (int i = 0; i < 9999999; i++)
                {
                    bulkInsertEntityList.Add(new Dapper
                    {
                        Dapper_Code = "12345",
                        Dapper_IsTrue = true,
                        Dapper_Integer = i,
                        Dapper_CreateDateTime = DateTime.Now,
                        Dapper_CreateDateTimeTwo = DateTime.Now,
                        Dapper_CreateUser = "J",
                        Dapper_NullableInteger = null
                    });
                }

                conn.BulkInsert(bulkInsertEntityList);

                //BulkUpdate
                var bulkUpdateEntityList = new List<Dapper>();

                for (int i = 0; i < 9999; i++)
                {
                    bulkUpdateEntityList.Add(new Dapper
                    {
                        Dapper_Id = i,
                        Dapper_Code = "54321",
                        Dapper_IsTrue = true,
                        Dapper_Integer = i,
                        Dapper_CreateDateTime = DateTime.Now,
                        Dapper_CreateDateTimeTwo = DateTime.Now,
                        Dapper_CreateUser = "J",
                        Dapper_NullableInteger = null
                    });
                }

                conn.BulkUpdate(bulkUpdateEntityList);

                //Transaction
                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        conn.Execute("INSERT INTO DAPPER Values(@Dapper_Code,@Dapper_IsTrue,@Dapper_Integer,@Dapper_CreateDateTime,@Dapper_CreateDateTimeTwo,@Dapper_CreateUser,@Dapper_NullableInteger)", new Dapper
                        {
                            Dapper_Code = "媽惹發可",
                            Dapper_IsTrue = true,
                            Dapper_Integer = 1,
                            Dapper_CreateDateTime = DateTime.Now,
                            Dapper_CreateDateTimeTwo = DateTime.Now,
                            Dapper_CreateUser = "J",
                            Dapper_NullableInteger = null
                        });

                        conn.Execute("UPDATE DAPPER SET Dapper_Code = @code WHERE Dapper_Id =@id", new { code = "QQQ", id = "asda" });

                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        transaction.Dispose();
                    }
                }

                Console.ReadLine();
            }





        }

    }
}