using System;
using System.Collections.Generic;

namespace Notifications_Channel_Parser
{
    class Program
    {

        static void Main(string[] args)
        {
            MyNotification_Channel Channels;
            string _Titles = "";
            Notification_Title notifTitle = new Notification_Title();
            List<MyNotification_Channel> ChannelList = new List<MyNotification_Channel>();
            notifTitle.Input();
            ChannelList = AssignNotification(notifTitle.Title);
            int i = 1;
            foreach (MyNotification_Channel mynotifCha in ChannelList)
            {
                if (i < ChannelList.Count)
                {
                    _Titles += mynotifCha.Channel + ", ";
                }
                else
                {
                    _Titles += mynotifCha.Channel;
                }
                i++;
            }
            Channels = new MyNotification_Channel(_Titles);
            Channels.Output();
            Console.ReadLine();

        }
        public class Notification_Title
        {
            string Titles;
            public Notification_Title()
            {
                this.Titles = "[BE][FE][Urgent] there is error";
            }
            public Notification_Title(string titles)
            {
                this.Titles = titles;
            }
            public string Title
            {
                get
                {
                    return Titles;
                }
                set 
                { 
                    Titles = value; 
                }                
            }
            public void Input()
            {
                Console.Write("Please Input the Notification Title Here: ");
                Titles = Console.ReadLine();
            }
            public void Output()
            {
                Console.WriteLine(Titles);
            }
        }
        public class MyNotification_Channel
        {
            string Channels;
            public MyNotification_Channel()
            {
                this.Channels = "[BE][QA][HAHA][Urgent] there is error";
            }
            public MyNotification_Channel(string channel)
            {
                Channels = channel;
            }
            public string Channel
            {
                get 
                {
                    return Channels; 
                }
                set 
                { 
                    Channels = value; 
                }
               
            }
            public void Output()
            {
                Console.WriteLine("\nReceive channels: " + Channels);
            }
        }
        public static System.Collections.Generic.List<MyNotification_Channel> AssignNotification(string NotifTitle)
        {
            List<MyNotification_Channel> ChannelList = new List<MyNotification_Channel>();
            string[] TitleLst = NotifTitle.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in TitleLst)
            {
                if (str == "BE" || str == "FE" || str == "QA" || str == "Urgent")
                {
                    ChannelList.Add(new MyNotification_Channel(str));
                }
            }
            return ChannelList;
        }
    }
}
