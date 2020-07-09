using System;
using System.Collections.Generic;
using System.Text;

namespace Common.JWT
{
    /// <summary>
    /// JWT 参数配置
    /// </summary>
    public class TokenManger
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 发行者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 订阅者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 访问过期秒数
        /// </summary>
        public int AccessExpiration { get; set; }
        /// <summary>
        ///  缓冲过期时间(总有效时间 = ClockSkewTime + AccessExpiration)
        /// </summary>
        public int ClockSkewTime { get; set; }
    }
}
