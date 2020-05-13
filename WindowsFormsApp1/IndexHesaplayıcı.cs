/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2019-2020 BAHAR DÖNEMİ
**
** PROJE NUMARASI.........: 01
** ÖĞRENCİ ADI............: Mehmet Demirtürk
** ÖĞRENCİ NUMARASI.......: B191200037
** DERSİN ALINDIĞI GRUP...: A
****************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                      //Dosya yazdırmak okumak için gerekli kütüphane
using System.Xml.Schema;

namespace WindowsFormsApp1
{
    public partial class IndexHesaplayıcı : Form

    {
        BoyKiloclass cagirbk = new BoyKiloclass();   // classı çağırdım

        public IndexHesaplayıcı()
        {

            InitializeComponent();

        }

       
           
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {

                float boy = Convert.ToInt32(txtBoy.Text);
                float kilo = Convert.ToInt32(txtKilo.Text);
                
                cagirbk.karesi = boy * boy;
                cagirbk.bolum = cagirbk.karesi / 10000;          //classı kullandım
                cagirbk.index = kilo / cagirbk.bolum;
                cagirbk.idealkg = cagirbk.karesi * 22.3 / 10000;
                cagirbk.gunluksu = kilo / 25;


                Takip.index2 = cagirbk.index;   //diğer formdaki değşkenlere değer atadım.
                Takip.boy2 = boy;
                Takip.kilo2 = kilo;

            }
            catch
            {
                labelhata.Text = "Geçersiz Sayı Tekrar Hesapla";        // geçersiz bir değer girildiğinde hata versin.
            }

            label8.Text = cagirbk.gunluksu + "lt";


            if (cagirbk.index < 18.5)                                  // endeks değer aralıklarında durumu göstermesi için if else yapılarını kullandım.

            {

                label3.Text = "Zayıf: " + cagirbk.index;
                label7.Text = cagirbk.idealkg + " kg";
                durum.Text = "Zayıfsınız";
                    
            }


            else if (18 <= cagirbk.index && cagirbk.index <= 24)

            {
                label3.Text = "Normal: " + cagirbk.index;
                label7.Text = cagirbk.idealkg + " kg";
                durum.Text = "Kilonuz Normal";
            }

            else if (cagirbk.index < 30 && cagirbk.index > 24)

            {

                label3.Text = "Kilolu: " + cagirbk.index;
                label7.Text = cagirbk.idealkg + " kg";
                durum.Text = "Kilolusunuz";
            }

            else

            {
                label3.Text = "Obez: " + cagirbk.index;
                label7.Text = cagirbk.idealkg + " kg";
                durum.Text = "Obezsiniz";
            }

            switch (durum.Text)                                      // durumlara göre resim göstermesi için switch case yapılarını kullandım.
            {
                case "Zayıfsınız":

                    pictureBox1.Visible = true;

                    break;

                case "Kilonuz Normal":

                    pictureBox2.Visible = true;                                            

                    break;

                case "Kilolusunuz":

                    pictureBox1.Visible = true;

                    break;

                case "Obezsiniz":

                    pictureBox1.Visible = true;

                    break;


            }


        }
      

private void txtBoy_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);        //sadece sayı girilebilmesi için
            }
        }

        private void txtKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);          //sadece sayı girilebilemsi için
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void IndexHesaplayıcı_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\karu\karu.txt"))    // kayıtlı belge var mı diye soruyorum
            {

                MessageBox.Show("Eski Kayıtlarınız bulundu.");               //eğer kayıtlı text dosyası varsa kayıt bulundu diyor.

            }

            else
            {

                Directory.CreateDirectory(@"C:\karu");            //yoksa yeni dosya ve dosya yolu oluştruluyor
                FileStream fs = File.Create(@"C:\karu\karu.txt");
                fs.Close();

            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Takip form2 = new Takip();       //formdan forma geçiş için
            form2.Show();


        }

        private void txtBoy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKilo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
