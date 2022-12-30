using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Adam_asmaca_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        string buluncakKelime = "";
        int resimSayisi = 0;
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);

        

        public string[] kelimeler = new string[10];
        public void kelimeleriAta()
        {
            kelimeler[0] = "okul";
            kelimeler[1] = "merhaba";
            kelimeler[2] = "bilgisayar";
            kelimeler[3] = "geometri";
            kelimeler[4] = "tahta";
            kelimeler[5] = "apartman";
            kelimeler[6] = "para";
            kelimeler[7] = "karınca";
            kelimeler[8] = "muvaffakiyetsizleştiricileştiriveremeyebileceklerimizdenmişsinizcesine";//:D en uzun kelimeymiş
            kelimeler[9] = "aralık";   
        }
        
                

        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeleriAta(); 
            
        }

        private void btnYKelime_Click(object sender, EventArgs e)
        {
            pbAdam.Image = Properties.Resources.ADAM_ASMACA_1;
            lblKelime.Text = "";            
            buluncakKelime = kelimeler[r.Next(10)];
            for (int i = 0; i < buluncakKelime.Length; i++)
            {
                lblKelime.Text += "?";                
            }
            resimSayisi = 0;
            
            lbDenemeler.Items.Clear();
        }

        private void btnHarfdene_Click(object sender, EventArgs e)
        {
            char aranacakChar = char.Parse(txtTahminHarf.Text);
            char[] karakterler = buluncakKelime.ToCharArray();
            bool varmi = false;

            for (int i = 0; i <= lbDenemeler.Items.Count - 1; i++)
            {
                if (lbDenemeler.Items[i].ToString() == aranacakChar.ToString())
                {
                    MessageBox.Show("Bu harf daha önce girilmiştir. Başka Harf deneyin.");
                    return;
                }
            }

            lbDenemeler.Items.Add(aranacakChar.ToString());

            for (int i = 0; i < karakterler.Length; i++)
            {
                if (karakterler[i] == aranacakChar)
                {
                    lblKelime.Text = lblKelime.Text.Remove(i, 1);
                    lblKelime.Text = lblKelime.Text.Insert(i, aranacakChar.ToString());
                    varmi = true;
                }                
            }

            if (lblKelime.Text == buluncakKelime)
            {
                MessageBox.Show("Kelime'yi bildiniz. TEBRİKLER.");
                lblKelime.Text = buluncakKelime;
                return;
            }
            txtTahminHarf.Text = "";
        
            if (varmi == false)
            {
                 resimSayisi++;
                if (resimSayisi == 1) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_2; }
                if (resimSayisi == 2) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_3; }
                if (resimSayisi == 3) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_4; }
                if (resimSayisi == 4) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_5; }
                if (resimSayisi == 5) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_6; }
                if (resimSayisi == 6) { pbAdam.Image = Properties.Resources.ADAM_ASMACA_7; }

                if (resimSayisi == 7)
                 {    pbAdam.Image=Properties.Resources.ADAM_ASMACA_8;
                     MessageBox.Show("Bütün Haklarınız doldu oyunu kaybettiniz.");
                     lblKelime.Text = buluncakKelime;
                     return;
                 }
            }

            
        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text;
            if (tahmin == buluncakKelime)
            {
                MessageBox.Show("Kelime'yi bildiniz. TEBRİKLER.");
                lblKelime.Text = buluncakKelime;
            }
            else
            {
                MessageBox.Show("YANLIŞ TAHMİN");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lbDenemeler.Items[0].ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pbAdam_Click(object sender, EventArgs e)
        {

        }
    }
}
