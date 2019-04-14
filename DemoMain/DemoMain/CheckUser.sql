SELECT u.Nickname AS Nickname,
       u.Password AS PASSWORD
FROM Users AS u
WHERE u.Nickname = @UserNickname AND u.Password = @UserPassword;