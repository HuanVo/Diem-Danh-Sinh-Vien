using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Project_Diem_Danh
{
    public partial class Deltail_Imagecs : DevExpress.XtraEditors.XtraForm
    {
        private Image im;
        private String name;
        public Deltail_Imagecs(Image img, String Name)
        {
            InitializeComponent();
            this.im = img;
            this.name = Name;

        }

        private void Deltail_Imagecs_Load(object sender, EventArgs e)
        {
            picture.Image = im;
            this.Text = name;
        }
    }
}