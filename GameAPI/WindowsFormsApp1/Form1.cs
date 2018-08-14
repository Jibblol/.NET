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
            var response = await client.GetAsync("https://localhost:44377/api/todo");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            try {
                var item = JsonConvert.DeserializeObject<Item[]>(responseBody);

                dataGridView1.DataSource = item;
            }
            catch (Exception x) {
                throw;
            }

        }

        private void addGames_Click(object sender, EventArgs e)
        {
            using (var form2 = new Form2())
            {
                form2.ShowDialog();
            }
        }
    }

    public class Item
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
