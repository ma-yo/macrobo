using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// コピーユーティリティー
    /// Author : M.Yoshida
    /// </summary>
    public static class CopyUtil
    {
        /// <summary>
        /// ディープコピーを実行する
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T target)
        {
            T result;
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            try
            {
                b.Serialize(mem, target);
                mem.Position = 0;
                result = (T)b.Deserialize(mem);
            }
            catch (Exception ex)
            {
                throw Program.ThrowException(ex);
            }
            finally
            {
                mem.Close();
            }
            return result;
        }
    }
}
