using Microsoft.AspNetCore.Identity;

namespace AracKiralamaPortali.Data;

public class TurkceIdentityHatalari : IdentityErrorDescriber
{
    public override IdentityError DuplicateEmail(string email) =>
        new() { Code = nameof(DuplicateEmail), Description = "Bu e-posta adresi zaten kayıtlı." };

    public override IdentityError DuplicateUserName(string userName) =>
        new() { Code = nameof(DuplicateUserName), Description = "Bu e-posta adresi zaten kayıtlı." };

    public override IdentityError InvalidEmail(string? email) =>
        new() { Code = nameof(InvalidEmail), Description = "Geçerli bir e-posta adresi girin." };

    public override IdentityError InvalidUserName(string? userName) =>
        new() { Code = nameof(InvalidUserName), Description = "E-posta adresi yalnızca İngilizce harf, rakam ve - . _ @ + karakterlerini içerebilir." };

    public override IdentityError PasswordTooShort(int length) =>
        new() { Code = nameof(PasswordTooShort), Description = $"Şifre en az {length} karakter olmalıdır." };

    public override IdentityError PasswordRequiresDigit() =>
        new() { Code = nameof(PasswordRequiresDigit), Description = "Şifre en az bir rakam içermelidir." };

    public override IdentityError PasswordRequiresLower() =>
        new() { Code = nameof(PasswordRequiresLower), Description = "Şifre en az bir küçük harf içermelidir." };

    public override IdentityError PasswordRequiresUpper() =>
        new() { Code = nameof(PasswordRequiresUpper), Description = "Şifre en az bir büyük harf içermelidir." };

    public override IdentityError PasswordRequiresNonAlphanumeric() =>
        new() { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Şifre en az bir özel karakter içermelidir (ör. ! ? * .)." };
}
