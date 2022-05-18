﻿namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户-【别名】批量解绑别名输入参数
    /// </summary>
    public class ApiUserAliasBatchUnBoundInDto : ApiInDto
    {
        /// <summary>
        /// 别名数据列表，数组长度不大于1000
        /// </summary>
        public data_listDto[] data_list { get; set; }
    }
}
