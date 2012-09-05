namespace JQSelenium
{
    public class IjQuerySelectorSelector : IJQuerySelector
    {
        #region IJQuerySelector Members

        public IJQueryTag Get()
        {
            return new JQueryTag();
        }

        #endregion
    }
}