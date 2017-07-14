using System.Data.Entity;
using DataModels;
using MyTools;

namespace InitDatabase
{
    public class SampleData : DropCreateDatabaseAlways<StudentRegContext>
    {
        protected override void Seed(StudentRegContext context)
        {
            context.SysAdmins.Add(new SysAdmin { AdminName="admin-zsb", Password=Tools.MD5Encrypt32("admin@123") });
            base.Seed(context);
        }
    }
}
