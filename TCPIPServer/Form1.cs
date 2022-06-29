using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;

namespace TCPIPServer
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(server.IsStarted)
            {
                server.Stop();
            }
        }

        void serverFunc(object sender, SimpleTCP.Message e)
        {
            this.richTextBox1.Invoke((MethodInvoker)delegate ()
            {
                richTextBox1.Text = e.MessageString;
                e.ReplyLine("I received your message" + e.MessageString);
                
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += serverFunc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "Staring...";
            string ip = this.textBox2.Text;
            IPAddress ipObj = IPAddress.Parse(ip);
            int port = Convert.ToInt32(this.textBox1.Text);
            server.Start(ipObj, port);
        }
    }
}
