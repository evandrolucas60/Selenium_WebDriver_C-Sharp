
namespace SampleFramework1
{
    internal class SampleApplicationPage
    {
        private object driver;

        public SampleApplicationPage(object driver)
        {
            this.driver = driver;
        }

        public bool IsVisible { get; internal set; }

        internal void GoTo()
        {
            throw new NotImplementedException();
        }
        internal UltimateQAHomePage FillOutFormAndSubmit(string v)
        {
            throw new NotImplementedException();
        }
    }
}