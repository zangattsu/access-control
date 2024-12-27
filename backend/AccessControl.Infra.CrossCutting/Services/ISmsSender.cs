using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
