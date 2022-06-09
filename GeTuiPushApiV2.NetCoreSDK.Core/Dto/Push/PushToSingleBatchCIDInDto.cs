﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toSingle】执行cid批量单推输入参数
    /// </summary>
    public class PushToSingleBatchCIDInDto : PushMessageInDto
    {
        /// <summary>
        /// 消息内容，数组长度不大于 200
        /// </summary>
        public ApiPushToSingleCIDInDto[] msg_list { get; set; }
    }
}
