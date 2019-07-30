using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormImageDetail : Form
    {
        private Image image;
        public FormImageDetail(Image image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void FormImageDetail_Load(object sender, EventArgs e)
        {
            pictureBoxImage.Image = image;
        }
    }
}
