using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.Models;
using EFUI.Utils;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;

            Task.Run(() => MainAsync(user));
        }

        private static async Task MainAsync(User user)
        {
            try 
            { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/"); 
                    string jsonObject = JsonConvert.SerializeObject(user).ToString();
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    //var content = new FormUrlEncodedContent(new[]
                    //{
                    //new KeyValuePair<string, string>("", "login")
                    //});
                    var result = await client.PostAsJsonAsync("/api/user", content);
                    if (result != null)
                    {
                            var jsonString = await result.Content.ReadAsStringAsync();
                            JsonConvert.DeserializeObject<object>(jsonString);
                    }
                    //string resultContent = await result.Content.ReadAsStringAsync();
                    //Console.WriteLine(resultContent);                
                }
            }
            catch (Exception ex)
            {
                //myCustomLogger.LogException(ex);
            }
        }        
    }
}
