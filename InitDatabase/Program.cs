using MyTools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数据库初始化！");
            Database.SetInitializer(new SampleData());

            string admin = "admin-zsb";
            string pwd = Tools.MD5Encrypt32("admin@123");

            StudentRegContext stuDB = new StudentRegContext();

            try
            {
                var list = stuDB.SysAdmins.Where(u => u.AdminName == admin && u.Password == pwd).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine("用戶名：" + item.AdminName.ToString());

                }
                Console.WriteLine("数据库初始化成功！");
            }
            catch (Exception e)
            {



                Console.WriteLine("数据库初始化失败！原因：" + e.Message.ToString());
            }


            Console.ReadKey();
        }
    }
}
