using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Macrobo.Utils
{
    /// <summary>
    /// 非同期処理を同期処理に変換する
    /// </summary>
    public static class AsyncUtil
    {
        private static readonly TaskFactory factory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return AsyncUtil.factory.StartNew<Task<TResult>>(func).Unwrap<TResult>().GetAwaiter().GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            AsyncUtil.factory.StartNew<Task>(func).Unwrap().GetAwaiter().GetResult();
        }
    }
}
