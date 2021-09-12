using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public interface IXenditHttpClient
    {
        Task<XenditResponse> SendAsync(XenditRequest request, CancellationToken cancellationToken);
    }
}
