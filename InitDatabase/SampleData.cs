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
            context.Specialtys.Add(new Specialty { SpecialtyName = "陶瓷设计与工艺", Period = "五年制大专", Tuition = 4100 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "雕刻艺术设计", Period = "五年制大专", Tuition = 4100 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "艺术设计", Period = "五年制大专", Tuition = 4100 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "动漫制作与技术", Period = "五年制大专", Tuition = 4100 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "陶瓷制造工艺", Period = "五年制大专", Tuition = 3600 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "汽车检测与维修技术", Period = "五年制大专", Tuition = 3600 });
            context.Specialtys.Add(new Specialty { SpecialtyName = "电子商务", Period = "五年制大专", Tuition = 3100 });
            context.Period_Categorys.Add(new Period_Category { CategoryName = "五年制大专" });
            context.Period_Categorys.Add(new Period_Category { CategoryName = "单独招生" });
            context.Nations.Add(new Nation { NationName = "汉族" });
            context.Nations.Add(new Nation { NationName = "蒙古族" });
            context.Nations.Add(new Nation { NationName = "回族" });
            context.Nations.Add(new Nation { NationName = "藏族" });
            context.Nations.Add(new Nation { NationName = "维吾尔族" });
            context.Nations.Add(new Nation { NationName = "苗族" });
            context.Nations.Add(new Nation { NationName = "彝族" });
            context.Nations.Add(new Nation { NationName = "壮族" });
            context.Nations.Add(new Nation { NationName = "布依族" });
            context.Nations.Add(new Nation { NationName = "朝鲜族" });
            context.Nations.Add(new Nation { NationName = "满族" });
            context.Nations.Add(new Nation { NationName = "侗族" });
            context.Nations.Add(new Nation { NationName = "瑶族" });
            context.Nations.Add(new Nation { NationName = "白族" });
            context.Nations.Add(new Nation { NationName = "土家族" });
            context.Nations.Add(new Nation { NationName = "哈尼族" });
            context.Nations.Add(new Nation { NationName = "哈萨克族" });
            context.Nations.Add(new Nation { NationName = "傣族" });
            context.Nations.Add(new Nation { NationName = "黎族" });
            context.Nations.Add(new Nation { NationName = "傈僳族" });
            context.Nations.Add(new Nation { NationName = "佤族" });
            context.Nations.Add(new Nation { NationName = "畲族" });
            context.Nations.Add(new Nation { NationName = "高山族" });
            context.Nations.Add(new Nation { NationName = "拉祜族" });
            context.Nations.Add(new Nation { NationName = "水族" });
            context.Nations.Add(new Nation { NationName = "东乡族" });
            context.Nations.Add(new Nation { NationName = "纳西族" });
            context.Nations.Add(new Nation { NationName = "景颇族" });
            context.Nations.Add(new Nation { NationName = "柯尔克孜族" });
            context.Nations.Add(new Nation { NationName = "土族" });
            context.Nations.Add(new Nation { NationName = "达斡尔族" });
            context.Nations.Add(new Nation { NationName = "仫佬族" });
            context.Nations.Add(new Nation { NationName = "布朗族" });
            context.Nations.Add(new Nation { NationName = "撒拉族" });
            context.Nations.Add(new Nation { NationName = "毛南族" });
            context.Nations.Add(new Nation { NationName = "仡佬族" });
            context.Nations.Add(new Nation { NationName = "羌族" });
            context.Nations.Add(new Nation { NationName = "锡伯族" });
            context.Nations.Add(new Nation { NationName = "阿昌族" });
            context.Nations.Add(new Nation { NationName = "普米族" });
            context.Nations.Add(new Nation { NationName = "塔吉克族" });
            context.Nations.Add(new Nation { NationName = "怒族" });
            context.Nations.Add(new Nation { NationName = "乌孜别克族" });
            context.Nations.Add(new Nation { NationName = "俄罗斯族" });
            context.Nations.Add(new Nation { NationName = "鄂温克族" });
            context.Nations.Add(new Nation { NationName = "德昂族" });
            context.Nations.Add(new Nation { NationName = "保安族" });
            context.Nations.Add(new Nation { NationName = "裕固族" });
            context.Nations.Add(new Nation { NationName = "京族" });
            context.Nations.Add(new Nation { NationName = "塔塔尔族" });
            context.Nations.Add(new Nation { NationName = "独龙族" });
            context.Nations.Add(new Nation { NationName = "鄂伦春族" });
            context.Nations.Add(new Nation { NationName = "赫哲族" });
            context.Nations.Add(new Nation { NationName = "门巴族" });
            context.Nations.Add(new Nation { NationName = "珞巴族" });           
            context.Nations.Add(new Nation { NationName = "基诺族" });

            base.Seed(context);
        }
    }
}
