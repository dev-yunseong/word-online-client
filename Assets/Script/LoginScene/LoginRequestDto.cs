
using System;

[Serializable]
public class LoginRequestDto
{
    public string email;
    public string passwordPlain;

    public LoginRequestDto(string email, string password)
    {
        this.email = email;
        this.passwordPlain = password;
    }
}
