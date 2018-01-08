using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Dapper
    {
        public long Dapper_Id { get; set; }
        public string Dapper_Code { get; set; }
        public bool Dapper_IsTrue { get; set; }
        public int Dapper_Integer { get; set; }
        public DateTime Dapper_CreateDateTime { get; set; }
        public DateTime Dapper_CreateDateTimeTwo { get; set; }
        public string Dapper_CreateUser { get; set; }
        public int? Dapper_NullableInteger { get; set; }
    }
}
