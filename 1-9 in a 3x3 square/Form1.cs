using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_9_in_a_3x3_square
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        ///Public variable
        public static Point MouseLocation = new Point();
        numbers a;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Function/events
        private void Form1_Load(object sender, EventArgs e)
        {
            //hidden Coloured1  
            Coloured1.Visible = false;
            Coloured2.Visible = false;
            Coloured3.Visible = false;
               
            a = new numbers(this);

            //get mouse location when the mouse is moving
            this.MouseMove += new MouseEventHandler(get_MouseLocation);
            foreach (Control c in a.value)
            {
                c.MouseMove += new MouseEventHandler(get_MouseLocation);
            }
            foreach (Control c in this.Controls)
            {
                c.MouseMove += new MouseEventHandler(get_MouseLocation);
            }
        }

        public void get_MouseLocation(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(MousePosition.X - this.Location.X - 8, MousePosition.Y - this.Location.Y - 31);
        }

        private void CheckCmd_Click(object sender, EventArgs e)
        {
            int h1_int = 0;
            int h2_int = 0;
            int h3_int = 0;

            int v1_int = 0;
            int v2_int = 0;
            int v3_int = 0;

            int d1_int = 0;
            int d2_int = 0;
            for (int i = 0; i < 3; i++)
            {
                //horizontal
                h1_int += a.value_pos[i];
                h2_int += a.value_pos[i + 3];
                h3_int += a.value_pos[i + 6];

                //vertical
                v1_int += a.value_pos[i * 3];
                v2_int += a.value_pos[(i * 3) + 1];
                v3_int += a.value_pos[(i * 3) + 2];

                //diagonal
                d1_int += a.value_pos[i * 4];
                d2_int += a.value_pos[(i + 1) * 2];
            }

            h1.Text = h1_int.ToString();
            h2.Text = h2_int.ToString();
            h3.Text = h3_int.ToString();

            v1.Text = v1_int.ToString();
            v2.Text = v2_int.ToString();
            v3.Text = v3_int.ToString();

            d1.Text = d1_int.ToString();
            d2.Text = d2_int.ToString();

            int count = 0;
            if (h1_int != 15)
            {
                h1.ForeColor = Color.Red;
                count++;
            }
            else
                h1.ForeColor = Color.Green;
            if (h2_int != 15)
            {
                h2.ForeColor = Color.Red;
                count++;
            }
            else
                h2.ForeColor = Color.Green;
            if (h3_int != 15)
            {
                h3.ForeColor = Color.Red;
                count++;
            }
            else
                h3.ForeColor = Color.Green;
            if (v1_int != 15)
            {
                v1.ForeColor = Color.Red;
                count++;

            }
            else
                v1.ForeColor = Color.Green;
            if (v2_int != 15)
            {
                v2.ForeColor = Color.Red;
                count++;
            }
            else
                v2.ForeColor = Color.Green;
            if (v3_int != 15)
            {
                v3.ForeColor = Color.Red;
                count++;
            }
            else
                v3.ForeColor = Color.Green;
            if (d1_int != 15)
            {
                d1.ForeColor = Color.Red;
                count++;

            }
            else
                d1.ForeColor = Color.Green;
            if (d2_int != 15)
            {
                d2.ForeColor = Color.Red;
                count++;
            }
            else
                d2.ForeColor = Color.Green;

            if (count == 0)
                MessageBox.Show("congratulations you solved the quiz");
        }

        private void labels_MouseLeave(object sender, EventArgs e)
        {
            Coloured1.Visible = false;
            Coloured2.Visible = false;
            Coloured3.Visible = false;
        }

        private void h1_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[0][0];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[0][1];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[0][2];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }

        private void h2_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[1][0];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[1][1];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[1][2];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }

        private void h3_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[2][0];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[2][1];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[2][2];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }

        private void v1_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[0][0];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[1][0];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[2][0];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }

        private void v2_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[0][1];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[1][1];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[2][1];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }

        private void v3_label_MouseEnter(object sender, EventArgs e)
        {
            Coloured1.Location = a.Correct_Location[0][2];
            Coloured1.Visible = true;
            Coloured1.BringToFront();
            Coloured2.Location = a.Correct_Location[1][2];
            Coloured2.Visible = true;
            Coloured2.BringToFront();
            Coloured3.Location = a.Correct_Location[2][2];
            Coloured3.Visible = true;
            Coloured3.BringToFront();
        }
    }
}
