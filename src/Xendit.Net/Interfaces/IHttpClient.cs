using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public interface IHttpClient
    {
        Task<XenditResponse> SendAsync(XenditRequest request, CancellationToken cancellationToken);
    }
}
