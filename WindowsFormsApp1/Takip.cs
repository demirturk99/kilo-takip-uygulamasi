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
using System.IO;               //Dosya işlemleri için gerekli olan kütüphane
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Takip : Form
    {

        BoyKiloclass cagirbk = new BoyKiloclass();    // oluşturduğum classtan

        public Takip()
        {
            InitializeComponent();
        }

        static public float index2;   //değerleri diğer formdan çekmek için static public değer atadım.
        static public float boy2;
        static public float kilo2;

        private void Takip_Load(object sender, EventArgs e)
        {

            FileStream fsbilgial = new FileStream("c:/karu/karu.txt", FileMode.Open, FileAccess.Read); //txt dosyasını açıp okutturdum.
            StreamReader srbilgial = new StreamReader(fsbilgial);

            string bilgi = srbilgial.ReadLine();
            while (bilgi != null)        //dosya boş olana kadar okutturup listboxa veriyi yazdırdım.
            {
                listBox1.Items.Add(bilgi);
                bilgi = srbilgial.ReadLine();
            }

            srbilgial.Close();   // başka işlemler yapabilmek için komutu kapatmamaız gerekiyor.
            fsbilgial.Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {

            textBox3.Text = index2 + ("");   //textboxa butona basıldığında değerleri getir dedim.
            textBox2.Text = kilo2 + ("");
            textBox1.Text = boy2 + ("");
        }

        private void button2_Click(object sender, EventArgs e)         
            
        {
            // getirdiğim veriyi listboxa düzenli bir şeklide çekmek için;
            listBox1.Items.Add(dateTimePicker1.Value + "  KİLO: " + textBox2.Text + "kg" + "  BOY:" + textBox1.Text + "cm" + "  ENDEKSİNİZ:" + textBox3.Text +"(cm2/kg)");
        }
       

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            kaydet();                                                          //kaydeti tanımladım

        }
        void kaydet ()                                                       //kaydetin fonksiyonu

        {

            FileStream fsbilgi = new FileStream("c:/karu/karu.txt", FileMode.Create, FileAccess.Write); // dosyaları yazabilmesi için girdiğim komut yeni dosya oluşturuyor.
            StreamWriter swbilgi = new StreamWriter(fsbilgi);
                for (int i = 0; i < listBox1.Items.Count; i ++)
            {
                swbilgi.WriteLine(listBox1.Items[i].ToString());    //listboxta itemleri yazdırmak için girdğim komut

           }
            swbilgi.Close();                                       // eğer kapatmazsak işlemi başka bir okuma yazma işlemi yapamayız.
            fsbilgi.Close();
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try                                          // bir şey seçmeden silim işlemi yapılırsa alınan hatayı önlemek için

            {

                int indeksno = listBox1.SelectedIndex;       //indeks numarasına göre silim işlemi
                listBox1.Items.RemoveAt(indeksno);
                kaydet();

            }

            catch
            {

                MessageBox.Show("Veri seçiniz.");

            }


        }
        
    }

}
