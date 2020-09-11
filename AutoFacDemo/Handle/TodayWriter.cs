using AutoFacDemo.IHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.Handle
{
    public class TodayWriter : IDateWriter
    {
        public string writeDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
