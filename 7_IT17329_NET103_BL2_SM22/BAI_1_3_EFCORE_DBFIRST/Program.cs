using System;
using System.Linq;
using System.Reflection.Emit;
using BAI_1_3_EFCORE_DBFIRST.Context;
using BAI_1_3_EFCORE_DBFIRST.DomainClass;

namespace BAI_1_3_EFCORE_DBFIRST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FpolyDBContext db = new FpolyDBContext();

            ChucVu cv = new ChucVu() { Ma = "aaaaaaaa", Ten = "a" };
            db.ChucVus.Add(cv);
            db.SaveChanges();

            foreach (var x in db.ChucVus.ToList())
            {
                Console.WriteLine(x.Ma + " " + x.Ten);
            }
        }
    }
}