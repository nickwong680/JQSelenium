using System.Collections.Generic;

namespace JQSelenium
{
    public interface IJQuerySelector : IEnumerable<JQueryTag>
    {
        JQueryTag Get();
    }
}