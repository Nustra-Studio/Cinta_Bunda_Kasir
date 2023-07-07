using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace KasirApp.Model
{
    public partial class TestAPI : Form
    {
        public TestAPI()
        {
            InitializeComponent();
        }

        private void TestAPI_Load(object sender, EventArgs e)
        {
            using (var client = new RestClient("https://jsonplaceholder.typicode.com/posts"))
            {
                var request = new RestRequest();

            }
        }
    }
}
