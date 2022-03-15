using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _1_9_in_a_3x3_square
{
    class numbers
    {
        public Label[] value = new Label[9];
        public int[] value_pos = Enumerable.Repeat(0, 9).ToArray();
        public Point[][] Correct_Location;
        private bool value_hold = false;
        private Point diff_mouse_value;


        //init
        public numbers(Form f)
        {
            //init value
            for (int i = 0; i < 9; i++)
            {
                value[i] = new Label();
                value[i].Text = (i + 1).ToString();
                value[i].Font = new Font("Microsoft Sans", 28);
                value[i].Location = new Point(i * 40, 291);
                value[i].Size = new Size(45, 45);
                value[i].BackColor = SystemColors.ActiveCaption;
                value[i].MouseDown += new MouseEventHandler(this.value_mouseDown);
                value[i].MouseUp += new MouseEventHandler(this.value_mouseUp);
                value[i].MouseMove += new MouseEventHandler(this.value_mouseMove);
                f.Controls.Add(value[i]);
                value[i].BringToFront();
            }

            int[] x = new int[] { 13, 59, 106 };
            int[] y = new int[] { 114, 160, 206 };

            Correct_Location = new Point[3][];
            //Correct_Location grid
            // 0 | 1 | 2
            // 3 | 4 | 5
            // 6 | 7 | 8
            //     x  y
            //0 = (0, 0) 
            //1 = (1, 0) 
            //2 = (2, 0) 
            //3 = (1, 1) 

            //init Correct_Location
            for (int i = 0; i < 3; i++)
            {
                Correct_Location[i] = new Point[3];
                for (int j = 0; j < 3; j++)
                {
                    Correct_Location[i][j] = new Point(x[j], y[i]);
                }
            }

        }
        private void value_mouseDown(object sender, MouseEventArgs e)
        {
            Label Sender = (Label)sender;
            Sender.BackColor = Color.Gray;
            diff_mouse_value = new Point(Form1.MouseLocation.X - Sender.Location.X, Form1.MouseLocation.Y - Sender.Location.Y);
            value_hold = true;
        }

        private void value_mouseMove(object sender, MouseEventArgs e)
        {
            Label Sender = (Label)sender;
            if (value_hold == true)
            {
                Point new_location = new Point(Form1.MouseLocation.X - diff_mouse_value.X, Form1.MouseLocation.Y - diff_mouse_value.Y);
                Sender.Location = new_location;
            }
        }


        private void value_mouseUp(object sender, MouseEventArgs e)
        {
            Label Sender = (Label)sender;
            Sender.BackColor = SystemColors.ActiveCaption;
            value_hold = false;
            value_location_autoCorrect(Sender,Form1.MouseLocation);
        }
           
        private void value_location_autoCorrect(Label Sender,Point location)
        {
            for (int i = 0; i < 9; i++)
                if (value_pos[i] == Int32.Parse(Sender.Text))
                    value_pos[i] = 0;

            int x = (location.X - 13) / 45;
            int y = (location.Y - 114) / 45;
            if (x > 2 || x < 0 || y > 2 || y < 0)
                Sender.Location = new Point((Int32.Parse(Sender.Text) - 1) * 40, 291);
            else if (value_pos[x + y * 3] != 0 && value_pos[x + y * 3] != Int32.Parse(Sender.Text))
            {
                value[value_pos[x + y * 3] - 1].Location = new Point((Int32.Parse(value[value_pos[x + y * 3] - 1].Text) - 1) * 40, 291);

                Sender.Location = Correct_Location[y][x];
                value_pos[x + y * 3] = Int32.Parse(Sender.Text);
            }
            else
            {
                Sender.Location = Correct_Location[y][x];
                value_pos[x + y * 3] = Int32.Parse(Sender.Text);
            }
        }
    }

}
