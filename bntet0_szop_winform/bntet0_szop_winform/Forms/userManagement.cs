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

namespace bntet0_szop_winform.Forms
{
    public partial class userManagement : Form
    {
        RestClient client = null;
        public userManagement()
        {
            InitializeComponent();
            string server = ConfigurationSettings.AppSettings["server"];
            string port = ConfigurationSettings.AppSettings["port"];
            client = new RestClient(string.Format("http://{0}:{1}/PHP/login.php", server, port));
            showDatagrid();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = RestSharp.DataFormat.Json;

            if (Form1.LoginSucces == null)
            {
                MessageBox.Show("You cant use this feature without loging in.");
                return;
            }
        }


        private void showDatagrid()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }
            List<User> users = new JsonSerializer().Deserialize<List<User>>(response);
            dataGridView1.DataSource = users;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;

            if (Form1.LoginSucces == null)
            {
                MessageBox.Show("You cant use this feature without loging in.");
                return;
            }
            int checkboxstatus = 0;
            if (checkBox1.Checked)
            {
                checkboxstatus = 1;
            }
            else
            {
                checkboxstatus = 0;
            }
            MessageBox.Show(Form1.LoginSucces.Password);

            request.AddJsonBody(new
            {
                Addusername = nameTB.Text,
                Addpassword = passwordTB.Text,
                AddAdmin = checkboxstatus,
                username = Form1.LoginSucces.Username,
                password = Form1.LoginSucces.Password
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }
            showDatagrid();
        }
    }
}
