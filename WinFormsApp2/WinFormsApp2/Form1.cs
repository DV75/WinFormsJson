using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace WinFormsApp2
{
    public partial class frmMainForm : Form    {
        
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            //List<data> _data = new List<data>();            
            string _path = @"C:\Users\lenovo\source\repos\WinFormsJSON\WinFormsApp2\example.json";
            string jsonString = File.ReadAllText(_path);
            //List<data> _data = JsonConvert.DeserializeObject<List<data>>(jsonfile);
            List<data> _data = JsonSerializer.Deserialize<List<data>>(jsonString);
            _data.Add(new data()
            {
                ID = Int32.Parse(txtBox_ID.Text),
                Name = txtBox_Name.Text,
                Title = txtBox_Title.Text
            });
            string json = JsonSerializer.Serialize(_data);
            File.WriteAllText(_path, json);
            txtBox_ID.Clear();
            txtBox_Name.Clear();
            txtBox_Title.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jsonfile = @"C:\Users\lenovo\source\repos\WinFormsJSON\WinFormsApp2\example.json";
            string jsonString = File.ReadAllText(jsonfile);
            List<data> _data = JsonSerializer.Deserialize<List<data>>(jsonString);
            lstBox_Results.Items.Clear();
            foreach (var item in _data)
            {
                if (Convert.ToString(item.ID) == txtBox_Search.Text && radBut_ID.Checked)
                {
                    lstBox_Results.Items.Add(item.Name + ", " + item.Title);
                }
                if (item.Name == txtBox_Search.Text && radBut_Name.Checked)
                {
                    lstBox_Results.Items.Add(item.ID + ", " + item.Title);
                }
                if (item.Title == txtBox_Search.Text && radBut_Title.Checked)
                {
                    lstBox_Results.Items.Add(item.ID + ", " + item.Name);
                }
            }
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtBox_User.Text == "d.van" && txtBox_Pwd.Text == "admin")
            {
                MessageBox.Show("Now you can Add or Search", "Login succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Add.Enabled = true;
                btn_Search.Enabled = true;
            }
            else
            {
                MessageBox.Show("User name or password unmatched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Add.Enabled = false;
                btn_Search.Enabled = false;
            }
               
        }
    }

    public class data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

    }

    public class cd : data 
    {
        public int nbTrack { set; get; }
        public string type { get; set; }
    }

    public class book : data
    {
        public int nbPages { set; get; }
        public string editor { get; set; }
        public string category { get; set; }
    }
}
