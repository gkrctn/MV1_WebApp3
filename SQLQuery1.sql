select users.UserName, roles.Name from AspNetUsers users
join AspNetUserRoles userroles on users.Id = userroles.UserId
join AspNetRoles roles on userroles.RoleId = roles.Id