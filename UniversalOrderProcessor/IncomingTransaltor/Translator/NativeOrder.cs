namespace Translator
{
    public class NativeOrder : INativeFormat
    {
        private const string Header = "<header>ABC corp</header>";
        private const string Footer = "<footer>summary</footer>";
        private string fileContent;

        public string FileContent()
        {
            return $"{Header}{fileContent}{Footer}";
        }

        public void LoadContentFrom(string fileContent)
        {
            this.fileContent = fileContent;
        }
    }
}