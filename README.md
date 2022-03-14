# RestaurantSystem
if you want that this program run you have to change several files

in FilePath.cs
Path = $@"\RestaurantSystem\RestaurantSystem{FileName}"

in mail.dat 
enter yours gmail address and password

string sendingEmailAddress = "yours@mail"

string emailaddressPassword = "Password"

3.Note.

Here we have used Gmail's SMTP server to send emails (From Mail Address) so we have to enable the Less Secure Apps in our from mail address account by enabling Allow less secure apps else we will get the error from Gmail's SMTP server (The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.7.0 Authentication Required.)
