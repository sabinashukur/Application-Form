using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex r = new(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            if (!r.IsMatch(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider1.SetError(textBox6, "Invalid phone number format!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox6, "");
            }
        }


        List<User> Users = new List<User>();

        private string GetSelectedRadioButtonText(GroupBox grb)
        {
            return grb.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            User user = new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,
                textBox6.Text, dateTimePicker1.Text, GetSelectedRadioButtonText(groupBox1));
            Users.Add(user);
            var jsonString = JsonConvert.SerializeObject(Users, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText($"{textBox1.Text}.json", jsonString);
            MessageBox.Show("Saved successfully");
            label2.Text = textBox1.Text;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Value = DateTime.Today;


        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            var stringData = File.ReadAllText($"{label2.Text}.json");
            var data = JsonConvert.DeserializeObject<List<User>>(stringData);

            foreach (var user in data)
            {
                textBox1.Text = user.Name;
                textBox2.Text = user.Surname;
                textBox3.Text = user.FName;
                textBox4.Text = user.Country;
                textBox5.Text = user.City;
                textBox6.Text = user.PhoneNumber;

                dateTimePicker1.CustomFormat = user.Birthdate;


                if (GetSelectedRadioButtonText(groupBox1) == radioButton1.Text)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                
            }

        }
    }
}
