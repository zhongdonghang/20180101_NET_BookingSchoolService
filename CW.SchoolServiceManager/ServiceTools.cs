using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CW.SchoolServiceManager
{
   public class ServiceTools
    {
        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="message"></param>
        public delegate void EventHandleSync(string message);

        /// <summary>
        /// 消息事件
        /// </summary>
        public event EventHandleSync ServiceMsg;

        public static string CurrentTime()
        {

            return DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒 ");
        }

        public void StartService()
        {
            if (ServiceMsg != null)
            {
                ServiceMsg("服务启动中...");
            }

            List<IService.IService> hosts = IService.ServiceFactory.CreateServiceAssemblys();
            if (hosts.Count == 0)
            {
                ServiceMsg("没有需要启动的服务");
               
                return;
            }
            foreach (IService.IService host in hosts)
            {
                try
                {
                    host.Start();
                    ServiceMsg(string.Format("服务{0}已启动", host.ToString()));
                }
                catch (Exception ex)
                {
                    ServiceMsg(string.Format("服务{0}启动遇到异常：{1}", host.ToString(), ex.Message));
                }
            }
            ServiceMsg("服务正常运行中");

        }
    }
}
