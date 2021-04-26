using HSE.Domain.Entities;

namespace HSE.DAL.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public string Token { get; set; }

        //maping static methods
        public static implicit operator LoginDomainModel(LoginViewModel model)
        {
            return new LoginDomainModel
            {
                Username = model.Username.Contains("@") ?
                    model.Username : model.Username + "@ady.az",
                Password = model.Password
            };
        }
    }
}
