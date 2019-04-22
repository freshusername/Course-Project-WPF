SELECT u.Login AS Login,
       u.Password AS Password
FROM Accounts AS u
WHERE u.Login = @UserNickname AND u.Password = @UserPassword;