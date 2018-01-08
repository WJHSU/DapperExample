using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Reppad
    {
        public long Reppad_Id { get; set; }
        public string Reppad_Code { get; set; }
        public bool Reppad_IsTrue { get; set; }
        public int Reppad_Integer { get; set; }
        public DateTime Reppad_CreateDateTime { get; set; }
        public DateTime Reppad_CreateDateTimeTwo { get; set; }
        public string Reppad_CreateUser { get; set; }
        public int? Reppad_NullableInteger { get; set; }
    }
}
