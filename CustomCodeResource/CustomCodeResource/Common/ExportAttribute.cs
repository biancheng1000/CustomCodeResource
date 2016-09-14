using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCode
{
    /// <summary>
    /// 自定义描述属性
    /// </summary>
    public class ExportAttribute:Attribute
    {
        public ExportAttribute(string description="",bool isIgnore=false,bool isCollapsed=false)
        {
            Description = description;
            IsIgnor = isIgnore;
            IsCollapsed = isCollapsed;
        }

        /// <summary>
        /// 属性的描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否忽略该字段
        /// </summary>
        public bool IsIgnor { get; set; }

        /// <summary>
        /// 是否需要隐藏
        /// </summary>
        public bool IsCollapsed { get; set; }
    }
}
