using System.Threading.Tasks;

namespace PaciakGeo.Hangfire.Jobs
{
    public interface IJob
    {
        Task Run();
    }
}