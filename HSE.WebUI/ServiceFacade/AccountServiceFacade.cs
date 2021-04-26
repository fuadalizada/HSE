using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.DAL.ViewModels;

namespace HSE.WebUI.ServiceFacade
{
    public class AccountServiceFacade
    {
        private readonly ILoginLogService _loginLogService;
        private readonly IMapper _mapper;
        public AccountServiceFacade(ILoginLogService loginLogService, IMapper mapper)
        {
            _loginLogService = loginLogService;
            _mapper = mapper;
        }

        public async Task AddLoginLog(LoginViewModel model, string browserInfo, IPAddress remoteIpAddress, bool value)
        {
            LoginLogDto log = new LoginLogDto
            {
                Email = model.Username,
                BrowserInfo = browserInfo,
                RemoteIpAddress = remoteIpAddress.ToString(),
                Success = value
            };
            await _loginLogService.AddLog(log);
        }
    }
}
