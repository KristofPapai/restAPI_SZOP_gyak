using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using bntet0_szop_winform.Classes;
using RestSharp.Serialization.Json;
using bntet0_szop_winform.Forms;

namespace bntet0_szop_winform
{
    public partial class Form1 : Form
    {
        RestClient client = null;
        public static User LoginSucces = null;

        public Form1()
        {

            InitializeComponent();

            string server = ConfigurationSettings.AppSettings["server"];
            string port = ConfigurationSettings.AppSettings["port"];
            client = new RestClient(string.Format("http://{0}:{1}/PHP/login.php", server, port));
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.seriesProfilePicture_a33f8b4a_2b22_41ce_8e7d_0aea08f0e176;
        }

        private void login_Click(object sender, EventArgs e)
        {
            var loginRequest = new RestRequest(Method.GET);
            loginRequest.RequestFormat = RestSharp.DataFormat.Json;
            loginRequest.AddObject(new
            {
                username = username.Text,
                password = password.Text 
            });
            var loginResponse = client.Execute(loginRequest);
            if (loginResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("MY Failed login "+ loginResponse.StatusDescription);
                return;
            }
            else
            {
                MessageBox.Show("Succesfull login" + loginResponse.Content);
               
            }
            try
            {
                LoginSucces = new JsonSerializer().Deserialize<User>(loginResponse);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong login credentials");
                return;
            }
            if (LoginSucces != null)
            {
                this.Hide();
                myMenu main = new myMenu();
                main.ShowDialog();

            }
        }
    }
}
