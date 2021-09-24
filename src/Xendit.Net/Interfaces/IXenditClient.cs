using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Xendit.Net
{
    public interface IXenditClient
    {
        Task<T> MakeRequestAsync<T>(string path, HttpMethod method, BaseRequestOptions baseOptions, CancellationToken cancellationToken) where T : class;
    }
}
