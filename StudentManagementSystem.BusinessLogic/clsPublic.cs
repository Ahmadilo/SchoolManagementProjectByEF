using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net.Http.Headers;

namespace StudentManagementSystem.BusinessLogic
{
    internal static class clsPublic
    {
        public static string BusinessLogicLogName = "LogicLog.txt";
        public readonly static bool GenretAuto = true;
        public static T GetInstansOfID<T>(int ID, T obj) where T : class
        {
            if (ID < 1)
                return null;

            if (obj != null)
                return obj;

            MethodInfo Method = typeof(T).GetMethod("Find", BindingFlags.Static | BindingFlags.Public);

            try
            {
                obj = (T)Method.Invoke(null, new object[] {ID});
            }
            catch (Exception e)
            {
                Helper.Logger.LogExption(e, BusinessLogicLogName);
                return null;
            }

            return obj;
        }
    }
}
