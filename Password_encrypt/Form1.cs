using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Password_encrypt
{
    public partial class Password_Encrypt : Form
    {
        public Password_Encrypt()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.btnEncrypt.Click += btnEncrypt_Click;
            this.btnreset.Click += Btnreset_Click;
        }

        private void Btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        static string Encrypt(string value)
        {
            //Using MD5 to encrypt a string
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //Hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtresult.Text = Encrypt(txtpassword.Text);
        }

        private void Reset()
        {
            this.txtpassword.Text = string.Empty;
            this.txtresult.Text = string.Empty;
        }
    }
}
 