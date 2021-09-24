namespace Xendit.Net.Tests
{
    public static class XenditNetTestFixtures
    {
        public static IXenditClient GetXenditClient()
        {
            return new XenditClient(new XenditOptions { ApiKey = "xnd_development_O46JfOtygef9kMNsK+ZPGT+ZZ9b3ooF4w3Dn+R1k+2fT/7GlCAN3jg==" });
        }
    }
}
