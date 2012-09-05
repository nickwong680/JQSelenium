namespace JQSelenium
{
    public class JQueryTag : IJQueryTag
    {
        public string Name { get; set; }

        #region IJQueryTag Members

        public string GetTagName()
        {
            return Name;
        }

        #endregion
    }
}