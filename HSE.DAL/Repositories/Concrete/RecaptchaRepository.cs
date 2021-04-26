using System.Net.Http;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.Settings;
using HSE.Domain.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HSE.DAL.Repositories.Concrete
{
    public class RecaptchaRepository:BaseRepository<GoogleRespond>,IRecaptchaRepository
    {
        private readonly RecaptchaSettings _settings;
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public RecaptchaRepository(HseDbContext context,IOptions<RecaptchaSettings> settings) : base(context)
        {
            _context = context;
            _settings = settings.Value;
        }

        public async Task<GoogleRespond> Verification(string token, string action = "")
        {
            RecaptchaData recaptchaData = new RecaptchaData
            {
                Response = token,
                Secret = _settings.SecretKey
            };

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync($@"https://www.google.com/recaptcha/api/siteverify?secret={recaptchaData.Secret}&response={recaptchaData.Response}");
            GoogleRespond capResponse = JsonConvert.DeserializeObject<GoogleRespond>(response);
            return capResponse;
        }
    }
}
