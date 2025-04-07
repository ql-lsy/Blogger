﻿using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class ApiZCYController : ApiController
    {
        public object Get(string zcsjh)
        {
            var yanzm = "";
            //string ActText = Request["phone"].ToString();
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
                                        //String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";
            String accessKeyId = "LTAI5tJefwmJQGTPVZ3ZsoPZ";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "bsoSxUURhauBAdatBVNW6idFdvkJdT";//你的accessKeySecret，参考本文档步骤2

            IClientProfile profile = Aliyun.Acs.Core.Profile.DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = zcsjh;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "只因微博";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = "SMS_273795545";
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                //request.TemplateParam = "{\"name\":\"Tom\"， \"code\":\"123\"}";
                //request.TemplateParam = "{\"code\":\"123\"}";
                Random rd = new Random();
                //这里生成一个 6 位数的全数字验证码
                int AuthCodeNumber = rd.Next(100000, 1000000);
                yanzm = AuthCodeNumber.ToString();
                request.TemplateParam = "{\"code\":\"" + yanzm + "\"}";
                //request.TemplateParam = "您正在申请注册，验证码为：${code}，5分钟内有效！";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "123";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                //System.Console.WriteLine(sendSmsResponse.Message);
            }
            catch (System.Runtime.Remoting.ServerException q)
            {
                string result = q.Message;
                //System.Console.WriteLine("Hello World!");
            }
            catch (ClientException q)
            {
                string result = q.Message;
                //System.Console.WriteLine("Hello World!");
            }
            return yanzm;
        }

        //[HttpPost]
        public object Post([FromBody] UserInfo u)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                db.UserInfo.Add(u);
                return db.SaveChanges() > 0;
            }
        }
    }
}
