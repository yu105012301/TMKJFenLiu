using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMKJ.FenLiu.Common
{
    public static class GuidExtension
    {
        /// <summary>
        /// 生成有序的Guid类型字符串
        /// </summary>
        /// <returns>组合类型 Guid 数据</returns>
        public static string ToComb(this Guid guid)
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();
            DateTime dtBase = new DateTime(1900, 1, 1);
            DateTime dtNow = DateTime.Now;
            //获取用于生成byte字符串的天数与毫秒数
            TimeSpan days = new TimeSpan(dtNow.Ticks - dtBase.Ticks);
            TimeSpan msecs = new TimeSpan(dtNow.Ticks - (new DateTime(dtNow.Year, dtNow.Month, dtNow.Day).Ticks));
            //转换成byte数组
            //注意SqlServer的时间计数只能精确到1/300秒
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            //反转字节以符合SqlServer的排序
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            //把字节复制到Guid中
            //Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            //Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);
            //return new Guid(guidArray).ToString();
            byte[] targetBytes = MergeArray(daysArray.Skip(2).ToArray(), msecsArray.Skip(4).ToArray());
            guidArray = ReverseArrary(guidArray, targetBytes, 10);
            return new Guid(guidArray).ToString();
        }

        /// <summary>
        /// 把数组中后几位移到最前面
        /// </summary>
        /// <param name="sourceBytes"></param>
        /// <param name="targetBytes"></param>
        /// <param name="index">开始移动的数组位置的索引</param>
        /// <returns></returns>
        private static byte[] ReverseArrary(byte[] sourceBytes, byte[] targetBytes, int index)
        {
            byte[] destinationArray = new byte[sourceBytes.Length];
            int length = sourceBytes.Length - index;
            Array.Copy(targetBytes, 0, destinationArray, 0, length);
            Array.Copy(sourceBytes, 0, destinationArray, targetBytes.Length, sourceBytes.Length - length);
            return destinationArray;
        }

        private static byte[] MergeArray(byte[] sourceBytes1, byte[] sourceBytes2)
        {
            ArrayList al = new ArrayList(sourceBytes1);
            al.AddRange(sourceBytes2);
            return al.ToArray(typeof(byte)) as byte[];
        }
    }
}
