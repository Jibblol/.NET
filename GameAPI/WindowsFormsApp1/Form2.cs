using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private static readonly HttpClient Client = new HttpClient();
        public Form2()
        {
            InitializeComponent();
        }

        private async void btnSaveInput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) {
                MessageBox.Show("Please enter a title");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text)) {
                MessageBox.Show("Please enter a description");
            }
            else {
                await AddGame();
            }
        }

        private async Task AddGame()
        {
            var values = new Item {
                Title = textBox1.Text,
                Description = textBox2.Text
            };

            //var content = new FormUrlEncodedContent(values);
            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("https://localhost:44377/api/todo", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnSaveInput.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            btnSaveInput.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }
    }
}
