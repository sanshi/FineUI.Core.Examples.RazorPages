using Microsoft.AspNetCore.Mvc.Filters;

namespace FineUI.Core.Examples.RazorPages
{
    /// <summary>
    /// 第三方编辑器仍需要内联事件或动态脚本；仅实际加载编辑器的页面使用兼容策略。
    /// 首屏和 POST 都设置相同策略，打开编辑窗口的外层页面仍使用全局严格 CSP。
    /// </summary>
    public abstract class ThirdPartyEditorPageBase : PageBase
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);
            PageManager.Instance.CspScripts = false;
        }
    }
}
