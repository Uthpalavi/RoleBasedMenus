using EFWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Serilog;

[Microsoft.AspNetCore.Mvc.Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public UserController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("{id}")]
    public JsonResult GetUserRoles(int id)
    {
        string query = @"select r.user_id,r.role_id,p.permission_id 
                        from  [EFRole].[dbo].[EF_Permission_Role] as p, [EFRole].[dbo].[EF_Role_User] as r
                        where p.role_id=r.role_id and r.user_id = " + id + @"";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("EFRoleDBCon");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader); ;

                myReader.Close();
                myCon.Close();
            }
        }

        return new JsonResult(table);
    }

    [HttpPost]
    public JsonResult Post([FromBody] User user)
    {
        string query = @"
                    SELECT [id]
                          ,[username]
                          ,[password]
                          ,[email]
                          ,[enabled]
                          ,[accountNonExpired]
                          ,[credentialsNonExpired]
                          ,[accountNonLocked]
                    FROM [EFRole].[dbo].[EF_User] 
                    where username  = '" + user.UserName + @"' and password = '" + user.Password + @"'";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("EFRoleDBCon");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader); ;

                myReader.Close();
                myCon.Close();
            }
        }
        //bool isverified = VerifyPassword(user.Password, new JsonResult(table), "1000");
        //if (isverified)
        //{
        //    return new JsonResult(table);
        //}
        //else
        //{
        //    return null;
        //}
        return new JsonResult(table);

    }
    
    //private  bool VerifyPassword(string enteredPassword, JsonResult dbuser, string storedSalt)
    //{
    //    string encriptedEnteredPW = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(enteredPassword));
    //    string encriptedDBbPassword = null;
    //    DataRow[] dr = table.Select("ID= 0");

    //    foreach (DataRow row in dr)
    //    {
    //        encriptedDBbPassword = row["password"].ToString();
    //    }

    //    if (encriptedEnteredPW == dbuser.Password)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //    return true;
    //}
}