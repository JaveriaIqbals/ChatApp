using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        
        SimpleTcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        void clientFunc(object sender, SimpleTCP.Message e)
        {
            this.richTextBox2.Invoke((MethodInvoker)delegate ()
            {
                this.richTextBox2.Text += e.MessageString; 
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += clientFunc;
            client.Connect("127.0.0.1", 8911);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(this.richTextBox1.Text, TimeSpan.FromSeconds(4));
        }
    }
}
