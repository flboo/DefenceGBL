

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using TGCenterSdk.Api;
using TGCenterSdk.Common;
using TGCWeChat.Platforms;

namespace GameWish.Game
{
    public class WechatMgr : TSingleton<WechatMgr>
    {
        // 微信登录
        public void WechatLogin()
        {
            WeChatHelper.Instance.Login();
        }

        // 微信登录
        public void SetWechatLoginListener()
        {
            Debug.Log("WeChat LoginSuccess, code:  SetWechatLoginListener");
            WeChatHelper.Instance.SetLoginListener(new WeChatLoginListener());
        }
        private class WeChatLoginListener : WeChatHelper.LoginListener
        {
            // 登录成功
            public void LoginSuccess(string code)
            {
                Debug.Log("WeChat LoginSuccess, code: " + code);

                EventSystem.S.Send(OXEventID.OnWechatLoginSuccess, code);

                if (string.IsNullOrEmpty(RichOXSaveDataHandler.data.userId))
                {
                    RichOXMgr.S.RegisterWithWechat(SDKConfig.S.tGCenterConfig.wechatConfig.wechatAppId, code, (result) => { EventSystem.S.Send(OXEventID.OnWechatRegisterSuccess); });
                }
                else
                {
                    RichOXMgr.S.StartBindAccount("wechat", SDKConfig.S.tGCenterConfig.wechatConfig.wechatAppId, code, (result) => { EventSystem.S.Send(OXEventID.OnWechatBindSuccess); });
                }
            }

            // 登录失败
            public void LoginFailed(string result)
            {
                Debug.Log("WeChat LoginFailed, result: " + result);
            }

            // 取消登录
            public void LoginCancel(string result)
            {
                Debug.Log("WeChat LoginCancel, result: " + result);
            }

        }


        public class WechatTokenCallBack
        {
            public string access_token;
            public int expires_in;
            public string refresh_token;
            public string openid;
            public string scope;
        }


    }

}