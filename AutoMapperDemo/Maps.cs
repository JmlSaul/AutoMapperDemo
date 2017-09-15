using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    /// <summary>
    /// 所有Map映射
    /// </summary>
    class Maps
    {
        /// <summary>
        /// 所有Map映射
        /// </summary>
        public static void CreateMaps()
        {
            MapperHelper.Instance.CreateMap<UserInfo, UserInfoDto>()
                    .ForMember(ud => ud.OrderContent, a => a.MapFrom(ui => ui.OrderInfo.Content))
                    .ForMember(ud => ud.OrderCount, a => a.MapFrom(ui => ui.OrderInfo.Count))
                    .ForMember(ud => ud.OrderItemName, a => a.MapFrom(ui => ui.OrderInfo.ItemName));

            MapperHelper.Instance.CreateMap<MyClass, MyClassDto>()
                 .ForMember(md => md.ddd, a => a.MapFrom(mc => mc.bbb + "100"))
                 .ForMember(md => md.eee, a => a.UseValue(DateTime.Now.ToString()));
        }
    }

}
