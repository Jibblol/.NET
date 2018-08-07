using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void getGames_Click(object sender, EventArgs e)
        {
            getAllGames();
        }

        private async Task getAllGames()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:44377/api/todo");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            try {
                Item[] item = JsonConvert.DeserializeObject<Item[]>(responseBody);

                dataGridView1.DataSource = item;
            }
            catch (Exception x) {
                throw;
            }

        }

        private void addGames_Click(object sender, EventArgs e)
        {
            addGame();
        }

        private async Task addGame()
        {
            var values = new Dictionary<string, string>
            {
                //{ "thing1", "hello" },
                //{ "thing2", "world" },
                { "title", "pinmandeluxe" }
            };

            //var content = new FormUrlEncodedContent(values);
            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44377/api/todo", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        
    }

    public class Item
    {
        public string title { get; set; }
        public int? year { get; set; }
        public string description { get; set; }
        public bool isComplete { get; set; }
    }
}
