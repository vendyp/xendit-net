namespace Xendit.Net
{
    public abstract class Service
    {
        public abstract string BasePath { get; }

        public BaseRequestOptions GetBaseRequestOptions()
        {
            return new BaseRequestOptions();
        }
    }
}
