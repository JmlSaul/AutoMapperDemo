using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;

namespace AutoMapperDemo
{
    /// <summary>
    /// 用于创建和初始化map映射。
    /// </summary>
    public class MapperHelper : MapperConfigurationExpression
    {
        #region 单例模式

        private static readonly object MapperHelperLock = new object();
        private static MapperHelper _instance = null;
        private MapperHelper()
        {
        }
        /// <summary>
        /// 用于创建Map映射的实例
        /// </summary>
        public static MapperHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (MapperHelperLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MapperHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion


        /// <summary>
        /// 注册所有Map映射到Mapper里（一般只需要程序启动执行一次）
        /// </summary>
        public static void Register()
        {
            Maps.CreateMaps();
            Mapper.Initialize(_instance);
        }
    }
}
