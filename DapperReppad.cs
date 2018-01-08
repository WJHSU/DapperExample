using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class DapperReppad
    {
        public long Reppad_Id { get; set; }
        public string Reppad_Code { get; set; }
        public bool Reppad_IsTrue { get; set; }
        public int Reppad_Integer { get; set; }
        public DateTime Reppad_CreateDateTime { get; set; }
        public DateTime Reppad_CreateDateTimeTwo { get; set; }
        public string Reppad_CreateUser { get; set; }
        public int? Reppad_NullableInteger { get; set; }
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
