using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Web.Script.Serialization;
using AutoMapper.Configuration;

namespace AutoMapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //注册所有Map映射到Mapper里（一般只需要程序启动执行一次）
            MapperHelper.Register();

            var userInfo = new UserInfo()
            {
                Id = 1,
                Age = 12,
                Name = "aa",
                OrderInfo = new OrderInfo()
                {
                    Id = 1,
                    Content = "aaaaaaaaaaaa",
                    Count = 2,
                    ItemName = "bb"
                }
            };

            #region 基本用法

            //初始化map规则
            //Mapper.Initialize(x => x.CreateMap<UserInfo, UserInfoDto>()
            //.ForMember(ud => ud.OrderContent, a => a.MapFrom(ui => ui.OrderInfo.Content))
            //.ForMember(ud => ud.OrderCount, a => a.MapFrom(ui => ui.OrderInfo.Count))
            //.ForMember(ud => ud.OrderItemName, a => a.MapFrom(ui => ui.OrderInfo.ItemName))
            //);

            #endregion


            var userInfoDto = Mapper.Map<UserInfo, UserInfoDto>(userInfo);

            var myc = new MyClass() { aaa = 111, bbb = "asdsa", ccc = 123.223m };

            var mycDto = Mapper.Map<MyClass, MyClassDto>(myc);

            Console.WriteLine(Json(userInfoDto));
            Console.WriteLine(Json(mycDto));
            Console.ReadKey();
        }

        private static string Json(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }

    class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public OrderInfo OrderInfo { get; set; }
    }

    class OrderInfo
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Content { get; set; }
        public int Count { get; set; }
    }

    class UserInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string OrderItemName { get; set; }
        public string OrderContent { get; set; }
        public int OrderCount { get; set; }
    }



    

    class MyClass
    {
        public int aaa { get; set; }
        public string bbb { get; set; }
        public decimal ccc { get; set; }
    }

    class MyClassDto
    {
        public int aaa { get; set; }
        public string bbb { get; set; }
        public string ccc { get; set; }
        public string ddd { get; set; }
        public string eee { get; set; }

    }

    
}
