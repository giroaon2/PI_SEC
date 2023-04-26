Step to run C# .Net core 6 and sql server

1. Install sql server management studio 18. 
server: localhost
user: sa
pass: 12345678

2. Connection string database sql server.
"Server=localhost;Database=PI_SEC;Trusted_Connection=False;TrustServerCertificate=Yes;User ID=sa;Password=12345678"

3. Create database and table users. 
run script file "CreateDBandTableUser.sql"

4. Install .Net core 6.0

if I have more times will be add those below
1. JWT for authentication and authorization.
2. Jenkins for deploying the branch after commit to the Server.
3. Gateway with Nginx do the load balance this API.