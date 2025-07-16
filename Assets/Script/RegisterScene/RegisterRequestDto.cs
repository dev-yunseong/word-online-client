namespace Script.RegisterScene
{
    public class RegisterRequestDto
    {
        public string email;
        public string passwordPlain;
        public string name;

        public RegisterRequestDto(string email, string password, string nickname)
        {
            this.email = email;
            this.passwordPlain = password;
            this.name = nickname;
        }
    }
}