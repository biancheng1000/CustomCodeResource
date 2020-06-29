using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashPrintHelper.Enum
{
    /// <summary>
    /// 打印纸张类型
    /// </summary>
    public enum PrintPaperType
    {
        None = 0,
        Label = 1,
        A4_Two,
        A4_Four,
        A4_Nine,
    };

    /// <summary>
    /// 字符解析状态
    /// </summary>
    public enum PraseStatus
    {
        None,
        Right,
        Wrong
    }

    /// <summary>
    /// 主界面显示的类型
    /// </summary>
    public enum MainViewType
    { 
        Print,
        History,
        Address
    }

    /// <summary>
    /// 打印机面板的四种状态
    /// </summary>
    public enum PrintStatus
    { 
        /// <summary>
        /// 没有打印机
        /// </summary>
        NoPrinter,

        /// <summary>
        /// 推荐打印机
        /// </summary>
        RecommendPrinter,

        /// <summary>
        /// 普通打印机
        /// </summary>
        CommonPrinter,

        /// <summary>
        /// 打印成功提示
        /// </summary>
        PrintSuccess,

    }
}
