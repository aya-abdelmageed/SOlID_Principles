//using System;

///// <summary>
///// UserServices Class for Register Users
///// </summary>
//public class Class1
//{
//    public void Register(string email, string password)
//    {
//        if (!ValidateEmail(email))
//            throw new ValidationException("Email is not an email");

//        var user = new User(email, password);

//        SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo foo" });
//    }
//}

//interface for email validation
public interface IValidateEmail
{
    public bool ValidateEmail(string email);
}

/// <summary>
/// class that implement IvalidateEmail to check email validation and 
/// 
/// it may implement another validation Interface 
/// </summary>

public class validEmail:IValidateEmail
{
    public bool ValidateEmail(string email)
    {
        return email.Contains("@");
    }
}


///Interface to send email
///send email using MailMessage
public interface ISendMail
{
    public bool SendEmail(MailMessage message);
}


///class that implement Email message Interface
///
public class SendEmail:ISendMail
{
    private SmtpClient _smtpClient { set; }
    public SendEmail(SmtpClient smtpClient)
    {
        this._smtpClient = smtpClient;
    }
    public bool SendEmail(MailMessage message)
    {
        _smtpClient.Send(message);
    }
}

//new user
public class NewUser
{
    public void NewUser(string email, string password)
    {
        //create user
        var user = new User(email, password);
        //add user to database
    }
}

/// <summary>
/// userservices class
/// </summary>
public class UserService
{
    validEmail valid = new validEmail();
    SendEmail send = new SendEmail();

    NewUser user = new NewUser();

    string email = "";
    string password = "";
    string message = "";


    public void Register(string email, string password)
    {
        if (!valid.ValidateEmail(email))
            throw new ValidationException("Email is not an email");
        
        NewUser user = new NewUser(email, password);
        

        send.SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo foo" });
    }
}
