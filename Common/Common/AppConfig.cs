using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Common.Common
{
    public class AppConfig
    {
        /// <summary>
        /// Redis 连接字符串
        /// </summary>
        public string RedisStrings { get; set; }
        private static IConfiguration Configuration { get; set; }
        static AppConfig appConfig = new AppConfig();
        /// <summary>
        /// 读取配置数据
        /// </summary>
        static public AppConfig Data
        {
            get
            {
                return appConfig;
            }
        }
        /// <summary>
        /// 初始化环境配置
        /// </summary>
        /// <param name="environmentName"></param>
        public static void Init(string environmentName = "")
        {
            var path = string.IsNullOrWhiteSpace(environmentName) ? "appsettings.json" : $"appsettings.{environmentName}.json";

            Configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource
            {
                Path = path,
                ReloadOnChange = true
            }).Build();
            Configuration.GetSection("AppConfig").Bind(appConfig);
        }
    }
}
