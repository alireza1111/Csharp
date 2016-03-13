using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Produktionsdata_syningsbänk
{
    public partial class Planering : Form
    {
        int failNum;
        int mmError;
        int count;
        private Planering mainForm;
        //int start;
        //int slut;
        //int fel;
        //char klass;
        //int[] yta;
        //string[] tjöckhet;
        //string[] planhet;
        //string[] slutkom;
        int i = 0;
        Avmärkningar[] avmIn = new Avmärkningar[60];
        string strConn;

       // DBConnectioin dBConnectioin = new DBConnectioin();



        // Avmärkningar avmtmp = new Avmärkningar();
        public Planering()
        {
            
            InitializeComponent();
            for (int n = 0; n < 60; n++)
                avmIn[n] = new Avmärkningar();

            //string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            showDG();
           // groupBox6.Controls.OfType(Of RadioButton)


        }

        /*        private void syningsbänkBindingNavigatorSaveItem_Click(object sender, EventArgs e)
                {
                    this.Validate();
                    this.syningsbänkBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.prodDBDataSet);

                }

                private void syningsbänkBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
                {
                    this.Validate();
                    this.syningsbänkBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.prodDBDataSet);
                }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prodDBDataSet.Syningsbänk' table. You can move, or remove it, as needed.
            this.SyningsbänkTableAdapter.Fill(this.prodDBDataSet.Syningsbänk);
            // TODO: This line of code loads data into the 'prodDBDataSet.Syningsbänk' table. You can move, or remove it, as needed.
           // this.syningsbänkTableAdapter.Fill(this.prodDBDataSet.Syningsbänk);
            // TODO: This line of code loads data into the 'prodDBDataSet.Syningsbänk' table. You can move, or remove it, as needed.
            //         this.syningsbänkTableAdapter.Fill(this.prodDBDataSet.Syningsbänk);
            tboxDatum.Text = System.DateTime.Today.ToShortDateString().ToString();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            //Avmärkningar[] avmIn = new Avmärkningar[60];

                //if (comboAvmärkKod.Text == "")
                //{
                //    MessageBox.Show("You must enter a value for field 'Kod'!");

                //}
                //else
                //{


                    BandData BD = new BandData();

                    failNum++;
                    //     mmError = Convert.ToInt16(tboxSlut.Text) - Convert.ToInt16(tboxStart.Text);

                    avmIn[i] = new Avmärkningar();

                    avmIn[i].ytak = CheckedYta();
                    avmIn[i].Planhet = CheckedPlanhet();
                    avmIn[i].tjöckhet = CheckedTjocklek();
                    avmIn[i].Start = Convert.ToInt16(tboxStart.Text);
                    avmIn[i].Slut = Convert.ToInt16(tboxSlut.Text);
                    avmIn[i].s = "S";
                    avmIn[i].Fel = comboAvmärkKod.Text;

                    avmIn[i].Kommentar = textBox1.Text;
                    //int r = Int32.TryParse(tboxBredd.Text,BD.bredd);

                    BD.bredd = Convert.ToInt32(tboxBredd.Text);
                    if (BD.bredd > 0)
                    {
                        float f = (1 - mmError / (float.Parse(tboxBredd.Text))) * 100;
                        Utbyte.Text = string.Format("{0}", f);
                    }

                    else Utbyte.Text = "0";


                    listBox1.Items.Add(avmIn[i].ToString());
            }
                
                catch (Exception exp)
            {
                MessageBox.Show("Du bör ange ett värde för alla obligatoriska fält. ");
                }

                i++;
                tboxStart.Text = tboxSlut.Text;
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                rb11.Checked = false;
                rb12.Checked = false;
                rb13.Checked = false;
                rb14.Checked = false;
                rb15.Checked = false;
                rb16.Checked = false;
                rb17.Checked = false;
                rb18.Checked = false;
                textBox1.Text = "";
                comboAvmärkKod.Text = "";
                tboxSlut.Text = "";
            }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mmError = 0;
            failNum = 0;
            i = 0;
            Array.Clear(avmIn, 0, avmIn.Length);
            listBox1.Items.Clear();
            for (int n = 0; n < 60; n++)
                avmIn[n] = new Avmärkningar();
            tboxStart.Text = "0";
            tboxSlut.Text = "";
            tboxBredd.Text = "";
            Utbyte.Text = "";
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
            rb6.Checked = false;
            rb7.Checked = false;
            rb8.Checked = false;
            rb9.Checked = false;
            rb10.Checked = false;
            rb11.Checked = false;
            rb12.Checked = false;
            rb13.Checked = false;
            rb14.Checked = false;
            rb15.Checked = false;
            rb16.Checked = false;
            rb17.Checked = false;
            rb18.Checked = false;

            string commonFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string myAppFolder = Path.Combine(commonFolder, "MyAppDataFolder");
            AppDomain.CurrentDomain.SetData("DataDirectory", myAppFolder);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int count=listBox1.Items.Count;

            string strConn;
            //New way to acheive connection

             

           //cs = connections

            //ORIGINAL CONNECTION

            //SqlConnection cs = new SqlConnection();

            //   strConn  = string.Format("{0}",ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            //   cs.ConnectionString = strConn;
            ////////////////////////////////////////////////////////
            SqlConnection cs = new SqlConnection();
           //FUNKAR// cs.ConnectionString = @"Server=2345pc037\SQLExpress; AttachDbFilename= \\2345fs01\\Users\\U361056\\Munkfors Stålverkets\\Release\\prodDB.mdf;Database=prodDB;Integrated Security=true";
            //Funkar jätte bra//cs.ConnectionString = "Data Source=2345pc037\\SQLExpress;Initial Catalog=prodDB1;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false;";
            cs.ConnectionString = "Data Source= 2345pc037\\SQLExpress;Initial Catalog= prodDB;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false";
            //    //Trusted_Connection=Yes"; //(LocalDB)\PRFInstance\prodDB.mdf;" +
            //    //"Integrated Security=True";//(LocalDB)\PRFInstance;Integrated Security=True";

            //@"Data Source=2345pc037\SQLEXPRESS;Initial Catalog=prodDB;Integrated Security=true";
            try
            {
                for (int j = 0; j < avmIn.Count(); j++)
                {
                    try
                    {
                        cs.Open();
                        Console.WriteLine("Kopplad till databas! ");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kan inte koppla till databas");
                    }

                    SqlCommand cmd = new SqlCommand("insert into prodDB.dbo.Syningsbänk (Ordernr,Datum,Synare,Stålsort,Ringnr,KlassningsKod,Yta,Ra,Rz,MinTj,MaxTj,Tjkod" +
                                                                          ",AvmärkKommentar, Bredd, RingVikt, Start,Slut, Fel, Klassering, YtaKod,Tjocklek,Planhet,SlutKommentar, Leverantör, Charge)" +
                                                                            "values (@Ordernr,@Datum,@Synare,@Stålsort,@Ringnr,@KlassningsKod,@Yta,@Ra,@Rz,@MinTj ,@MaxTj,@Tjkod" +
                                                          ",@AvmärkKommentar, @Bredd, @RingVikt, @Start,@Slut, @Fel,@Klassering, @YtaKod, @Tjocklek ,@Planhet, @SlutKommentar, @Leverantör, @Charge)", cs);


                    cmd.Parameters.AddWithValue("@Ordernr", tboxOrdernr.Text);
                    cmd.Parameters.AddWithValue("@Datum", DateTime.Parse(tboxDatum.Text).Date);
                    cmd.Parameters.AddWithValue("@Synare", comboSynare.Text);
                    cmd.Parameters.AddWithValue("@Ringnr", tboxRingnr.Text);
                    cmd.Parameters.AddWithValue("@KlassningsKod", comboKlassningKod.Text);
                    cmd.Parameters.AddWithValue("@Vikt", tboxRingVikt.Text);
                    cmd.Parameters.AddWithValue("@Stålsort", comboStålsort.Text);
                    cmd.Parameters.AddWithValue("@Leverantör", comboLeverantör.Text);
                    cmd.Parameters.AddWithValue("@Charge", tboxCharge.Text);
                    cmd.Parameters.AddWithValue("@Yta", tboxYta.Text);
                    cmd.Parameters.AddWithValue("@Ra", tboxRa.Text);
                    cmd.Parameters.AddWithValue("@Rz", tboxRz.Text);
                    cmd.Parameters.AddWithValue("@MinTj", tboxMinTjocklek.Text);
                    cmd.Parameters.AddWithValue("@MaxTj", tboxMaxTjocklek.Text);
                    cmd.Parameters.AddWithValue("@Tjkod", comboAvmärkKod.Text);
                    cmd.Parameters.AddWithValue("@Bredd", tboxBredd.Text);
                    cmd.Parameters.AddWithValue("@RingVikt", tboxRingVikt.Text);
                    cmd.Parameters.AddWithValue("@SlutKommentar", textBox2.Text);

                    cmd.Parameters.AddWithValue("@Start", avmIn[j].Start);
                    cmd.Parameters.AddWithValue("@Slut", avmIn[j].Slut);
                    cmd.Parameters.AddWithValue("@Fel", avmIn[j].Fel);
                    cmd.Parameters.AddWithValue("@Klassering", avmIn[j].s);
                    cmd.Parameters.AddWithValue("@Planhet", avmIn[j].Planhet);
                    cmd.Parameters.AddWithValue("@Tjocklek", avmIn[j].tjöckhet);
                    cmd.Parameters.AddWithValue("@YtaKod", avmIn[j].ytak);
                    cmd.Parameters.AddWithValue("@AvmärkKommentar", avmIn[j].Kommentar);

                    //  cmd.Parameters.AddWithValue("@Härdat", comboHärdat.SelectedItem);
                    //  cmd.Parameters.AddWithValue("@Slutvalsat", comboSlutvalsat.SelectedItem);
                    // SqlCommand com = new SqlCommand("insert into prodDB.dbo.Syningsbänk ())


                    try
                    {
                        int res = cmd.ExecuteNonQuery();
                        //  SqlCommand cm= new SqlCommand("Select count(*) from prodDB.dbo.Syningsbänk",cs);
                        if (res > 0)
                        {
                            // MessageBox.Show("Record(s) added to the database.");
                            //Console.WriteLine("Database contains total record: " + cm);
                            rb1.Checked = false;
                            rb2.Checked = false;
                            rb3.Checked = false;
                            rb4.Checked = false;
                            rb5.Checked = false;
                            rb6.Checked = false;
                            rb7.Checked = false;
                            rb8.Checked = false;
                            rb9.Checked = false;
                            rb10.Checked = false;
                            rb11.Checked = false;
                            rb12.Checked = false;
                            rb13.Checked = false;
                            rb14.Checked = false;
                            rb15.Checked = false;
                            rb16.Checked = false;
                            rb17.Checked = false;
                            rb18.Checked = false;
                            listBox1.Items.Clear();
                            tboxStart.Text = "0";
                            tboxBredd.Text = "";
                            tboxCharge.Text = "";
                            tboxMaterialnr.Text = "";
                            tboxMaxTjocklek.Text = "";
                            tboxMinTjocklek.Text = "";
                            tboxOrdernr.Text = "";
                            tboxRa.Text = "";
                            tboxRingnr.Text = "";
                            tboxRingVikt.Text = "";
                            tboxRz.Text = "";
                            tboxSlut.Text = "";
                            tboxYta.Text = "";
                            Utbyte.Text = "";
                            textBox2.Text = "";
                        }
                    }


                    catch (SqlException ex)
                    {

                        //MessageBox.Show("You must enter a value for all requirted fields!");
                       Console.WriteLine("Du bör ange ett värde för alla obligatoriska fält. ");
                        //Console.WriteLine(ex.Message);

                        // mainForm = new Planering();
                        //mainForm.Show();
                    }

                    catch (NullReferenceException NREXC)
                    {
                        MessageBox.Show(NREXC.Message);
                    }


                    //Application.Run(new Planering());

                    cs.Close();
                }
            }
            catch (NullReferenceException exp3)
            {
                MessageBox.Show(exp3.Message);
            }

            MessageBox.Show(count + " order läggs till databas.");
            showDG();


            for (int n = 0; n < 60; n++)
                avmIn[n] = new Avmärkningar();
        }

        private void tboxDatum_TextChanged(object sender, EventArgs e)
        {

        }



        private String CheckedYta()
        {
            if (rb1.Checked)
            {
                //rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb1.Text;
            }
            if (rb2.Checked)
            {
                rb1.Checked = false;
                //rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb2.Text;
            }
            if (rb4.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                //rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb4.Text;
            }
            if (rb3.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                //rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb3.Text;
            }
            if (rb6.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                //rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb6.Text;
            }
            if (rb5.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                //rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb5.Text;
            }
            if (rb7.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                //rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb7.Text;
            }
            if (rb8.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                //rb8.Checked = false;
                rb9.Checked = false;
                rb10.Checked = false;
                return rb8.Text;
            }
            if (rb9.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                //rb9.Checked = false;
                rb10.Checked = false;
                return rb9.Text;
            }
            if (rb10.Checked)
            {
                rb1.Checked = false;
                rb2.Checked = false;
                rb3.Checked = false;
                rb4.Checked = false;
                rb5.Checked = false;
                rb6.Checked = false;
                rb7.Checked = false;
                rb8.Checked = false;
                rb9.Checked = false;
                //rb10.Checked = false;
                return rb10.Text;
            }

            else
                return " ";
        }


        private String CheckedTjocklek()
        {
            if (rb12.Checked)
            {
                rb11.Checked = false;
               // rb12.Checked = false;
                rb13.Checked = false;
                rb14.Checked = false;
                rb15.Checked = false;
                return rb12.Text;
            }
            if (rb11.Checked)
            {
                //rb11.Checked = false;
                rb12.Checked = false;
                rb13.Checked = false;
                rb14.Checked = false;
                rb15.Checked = false;
                return rb11.Text;
            }
            if (rb14.Checked)
            {
                rb11.Checked = false;
                rb12.Checked = false;
                rb13.Checked = false;
                //rb14.Checked = false;
                rb15.Checked = false;
                return rb14.Text;
            }
            if (rb13.Checked)
            {
                rb11.Checked = false;
                rb12.Checked = false;
              //  rb13.Checked = false;
                rb14.Checked = false;
                rb15.Checked = false;
                return rb13.Text;
            }
            if (rb15.Checked)
            {
                rb11.Checked = false;
                rb12.Checked = false;
                rb13.Checked = false;
                rb14.Checked = false;
                //rb15.Checked = false;
                return rb15.Text;
            }
            else
                return " ";
        }
        private String CheckedPlanhet()
        {
            if (rb16.Checked)
            {
                return rb16.Text;
            }
            if (rb18.Checked)
            {
                return rb18.Text;
            }
            if (rb17.Checked)
            {
                return rb17.Text;
            }
            else
                return " ";
        }
        private void rb4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ordernrTextBox_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void tboxRingnr_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void breddTextBox_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void tboxRingVikt_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void tboxMaterialnr_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void tboxYta_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void tboxRa_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboLeverantör_Validated_1(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboStålsort_Validated(object sender, EventArgs e)
        {

        }
        private void comboAg_Validated(object sender, EventArgs e)
        {

        }
        private void comboKlassningKod_Validated_1(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboSlutvalsat_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboHärdat_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboAvmärkKod_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void comboSynare_Validated_1(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           try{ // Avmärkningar[] avmIn = new Avmärkningar[60];
            BandData BD = new BandData();
            failNum++;

            mmError = Convert.ToInt16(tboxSlut.Text) - Convert.ToInt16(tboxStart.Text);


            avmIn[i].ytak = CheckedYta();
            avmIn[i].Planhet = CheckedPlanhet();
            avmIn[i].tjöckhet = CheckedTjocklek();
            avmIn[i].Start = Convert.ToInt16(tboxStart.Text);
            avmIn[i].Slut = Convert.ToInt16(tboxSlut.Text);
            avmIn[i].s = "N";
            avmIn[i].Kommentar = textBox1.Text;
            avmIn[i].Fel = comboAvmärkKod.Text;
            //int r = Int32.TryParse(tboxBredd.Text,BD.bredd);

            BD.bredd = Convert.ToInt32(tboxBredd.Text);
            if (BD.bredd > 0)
            {
                float f = (1 - mmError / (float.Parse(tboxBredd.Text))) * 100;
                Utbyte.Text = string.Format("{0}", f);
            }
            else Utbyte.Text = "0";


            listBox1.Items.Add(avmIn[i].ToString());
           }
              catch (Exception exp)
            {
                MessageBox.Show("Du bör ange ett värde för alla obligatoriska fält. ");
                Console.WriteLine(exp);
                }
            
            tboxStart.Text = tboxSlut.Text;

            tboxStart.Text = tboxSlut.Text;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
            rb6.Checked = false;
            rb7.Checked = false;
            rb8.Checked = false;
            rb9.Checked = false;
            rb10.Checked = false;
            rb11.Checked = false;
            rb12.Checked = false;
            rb13.Checked = false;
            rb14.Checked = false;
            rb15.Checked = false;
            rb16.Checked = false;
            rb17.Checked = false;
            rb18.Checked = false;
            textBox1.Text = " ";
            comboAvmärkKod.Text = " ";
            tboxSlut.Text = "";
            i++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {//  Avmärkningar[] avmIn = new Avmärkningar[60];
                BandData BD = new BandData();
                failNum++;
                mmError = Convert.ToInt16(tboxSlut.Text) - Convert.ToInt16(tboxStart.Text);


                avmIn[i].ytak = CheckedYta();
                avmIn[i].Planhet = CheckedPlanhet();
                avmIn[i].tjöckhet = CheckedTjocklek();
                avmIn[i].Start = Convert.ToInt16(tboxStart.Text);
                avmIn[i].Slut = Convert.ToInt16(tboxSlut.Text);
                avmIn[i].s = "B";
                avmIn[i].Kommentar = textBox1.Text;
                avmIn[i].Fel = comboAvmärkKod.Text;
                //int r = Int32.TryParse(tboxBredd.Text,BD.bredd);

                BD.bredd = Convert.ToInt32(tboxBredd.Text);
                if (BD.bredd > 0)
                {
                    float f = (1 - mmError / (float.Parse(tboxBredd.Text))) * 100;
                    Utbyte.Text = string.Format("{0}", f);
                }
                else Utbyte.Text = "0";


                listBox1.Items.Add(avmIn[i].ToString());
            }
            catch (Exception exp)
            {
                MessageBox.Show("Du bör ange ett värde för alla obligatoriska fält. ");
            }
            tboxStart.Text = tboxSlut.Text;

            tboxStart.Text = tboxSlut.Text;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
            rb6.Checked = false;
            rb7.Checked = false;
            rb8.Checked = false;
            rb9.Checked = false;
            rb10.Checked = false;
            rb11.Checked = false;
            rb12.Checked = false;
            rb13.Checked = false;
            rb14.Checked = false;
            rb15.Checked = false;
            rb16.Checked = false;
            rb17.Checked = false;
            rb18.Checked = false;
            textBox1.Text = " ";
            comboAvmärkKod.Text = " ";
            tboxSlut.Text = "";
            i++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {// Avmärkningar avmIn = new Avmärkningar();
                BandData BD = new BandData();
                failNum++;
                mmError = Convert.ToInt16(tboxSlut.Text) - Convert.ToInt16(tboxStart.Text);


                avmIn[i].ytak = CheckedYta();
                avmIn[i].Planhet = CheckedPlanhet();
                avmIn[i].tjöckhet = CheckedTjocklek();
                avmIn[i].Start = Convert.ToInt16(tboxStart.Text);
                avmIn[i].Slut = Convert.ToInt16(tboxSlut.Text);
                avmIn[i].s = "U";
                avmIn[i].Kommentar = textBox1.Text;
                avmIn[i].Fel = comboAvmärkKod.Text;
                //int r = Int32.TryParse(tboxBredd.Text,BD.bredd);

                BD.bredd = Convert.ToInt32(tboxBredd.Text);
                if (BD.bredd > 0)
                {
                    float f = (1 - mmError / (float.Parse(tboxBredd.Text))) * 100;
                    Utbyte.Text = string.Format("{0}", f);
                }
                else Utbyte.Text = "0";


                listBox1.Items.Add(avmIn[i].ToString());
            }
            catch (Exception exp)
            {
                MessageBox.Show("Du bör ange ett värde för alla obligatoriska fält. ");
            }
            tboxStart.Text = tboxSlut.Text;

            tboxStart.Text = tboxSlut.Text;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
            rb6.Checked = false;
            rb7.Checked = false;
            rb8.Checked = false;
            rb9.Checked = false;
            rb10.Checked = false;
            rb11.Checked = false;
            rb12.Checked = false;
            rb13.Checked = false;
            rb14.Checked = false;
            rb15.Checked = false;
            rb16.Checked = false;
            rb17.Checked = false;
            rb18.Checked = false;
            textBox1.Text = " ";
            comboAvmärkKod.Text = " ";
            tboxSlut.Text = "";
            i++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s;

            s = textBox3.Text;
            var sök = new List<string>();
            //for (int i = 1; i == 100; i++)
            //    sök[i] = " ";
             SqlConnection connect = new SqlConnection();
             //FUNKAR JÄTTE BRA: connect.ConnectionString = "Data Source=2345pc037\\SQLExpress;Initial Catalog=prodDB1;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false;";
             connect.ConnectionString = "Data Source= 2345pc037\\SQLExpress;Initial Catalog= prodDB;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false";
            connect.Open();
            //FUNKAR//connect.ConnectionString = @"Data Source=2345pc037\SQLEXPRESS;Initial Catalog=prodDB;Integrated Security=true";
           // string f = string.Format("{0}",'"+string.Format("{0}",textBox3.Text)+"' );
            SqlCommand cmd = new SqlCommand(
                                                            " Select * from prodDB.dbo.Syningsbänk where Ordernr like '"+(textBox3.Text) +"'  or"+
                                                                                      " Datum like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                           " Synare like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                               " Stålsort like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                   " RingNr like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                       " KlassningsKod like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                           " Yta like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                               " Ra like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                   " Rz like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                       " MinTj like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                           " MaxTj like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                               " Tjkod like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                                   " AvmärkKommentar like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                                       " Bredd like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                                           " RingVikt like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                                               " Start like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                                                   " Slut like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                        " Fel like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                            " Klassering like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                " YtaKod like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                    " Tjocklek like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                        " Planhet like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                            " SlutKommentar like '" + string.Format("{0}", textBox3.Text) + "'  or" +
                                                                                                                " Leverantör like '" + textBox3.Text+"'  or" +
                                                                                                                    " Charge like '%''"+textBox3.Text+"''%' " , connect);

           // cmd.Parameters.AddWithValue("'"+string.Format("{0}",textBox3.Text)+"' ", s );

            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();
            dAdapter.Fill(dSet);
            dataGridView1.DataSource = dSet.Tables[0];
            //if (sök == null)
            //    MessageBox.Show("Couldn't find any mached text! ");
            //listBox1.Items.Add(sök);

            connect.Close();
            //string.Format("{0}",textBox3.Text)
        }
        private void showDG()
        {
            //**ORIGINAL
            //SqlConnection cs = new SqlConnection();

            //strConn = string.Format("{0}", ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            //SqlConnection cs = new SqlConnection();
            ////cs.ConnectionString = @"Server=2345pc037\SQLExpress; AttachDbFilename= \\2345fs01\\Users\\U361056\\Munkfors Stålverkets\\Release\\prodDB.mdf;Database=prodDB;Integrated Security=true";
            ////cs.ConnectionString = @"Server=2345pc037\SQLExpress; Integrated Security=true";

            //    cs.ConnectionString = "Data Source=2345pc037\\SQLExpress;Initial Catalog=prodDB1;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false;";

            //    cs.Open();




            //    SqlCommand cmd = new SqlCommand();

            //    cmd.Connection = cs;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "SELECT * FROM prodDB1.dbo.Syningsbänk";
            //    SqlDataAdapter dbAdapter = new SqlDataAdapter(cmd);

            //    DataTable dtRecords = new DataTable();
            //    dbAdapter.Fill(dtRecords);
            //    dataGridView1.DataSource = dtRecords; //dataGrid

            //**ORIGINAL
            //SqlConnection cs = new SqlConnection();

            //strConn = string.Format("{0}", ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlConnection cs2 = new SqlConnection();
            //cs.ConnectionString = @"Server=2345pc037\SQLExpress; AttachDbFilename= \\2345fs01\\Users\\U361056\\Munkfors Stålverkets\\Release\\prodDB.mdf;Database=prodDB;Integrated Security=true";
            //cs.ConnectionString = @"Server=2345pc037\SQLExpress; Integrated Security=true";
           //FUNKAR JÄTTE BRA: cs2.ConnectionString = "Data Source=2345pc037\\SQLExpress;Initial Catalog=prodDB1;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false";
            cs2.ConnectionString = "Data Source= 2345pc037\\SQLExpress;Initial Catalog= prodDB;User ID=NTSERVICES;Password=slaeB83;Integrated Security=false";
            cs2.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cs2;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM prodDB.dbo.Syningsbänk";

            SqlDataAdapter dbAdapter = new SqlDataAdapter(cmd);

            DataTable dtRecords = new DataTable();
            dbAdapter.Fill(dtRecords);
            dataGridView1.DataSource = dtRecords; //dataGrid



        }

        private void button9_Click(object sender, EventArgs e)
        {
            showDG();
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void rb9_CheckedChanged(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void rb13_CheckedChanged(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb12_CheckedChanged(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb11_CheckedChanged(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb14_CheckedChanged(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb13_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb15_CheckedChanged(object sender, EventArgs e)
        {
            CheckedTjocklek();
        }

        private void rb1_Click(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void rb2_Click(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void rb3_Click(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void rb4_Click(object sender, EventArgs e)
        {
            CheckedYta();
        }

        private void tboxSlut_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        Bitmap dataGridViewImage = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(dataGridViewImage, new Rectangle(0, 0,this.dataGridView1.Width,this.dataGridView1.Height));
            e.Graphics.DrawImage(dataGridViewImage, 0, 0);
        }
        
         

        private void tboxSlut_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tboxStart.Text) >= Convert.ToInt32(tboxSlut.Text))
            {
                MessageBox.Show("Slut avnmärkning måste inte bli mindre än Start.");
            }
            if (Convert.ToInt32(tboxSlut.Text)>Convert.ToInt32(tboxBredd.Text))
            {
                MessageBox.Show("Slut avmärkning måste inte bli mer än Bredd fält.");
            }
        }

        private void tboxStart_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tboxStart.Text) >= Convert.ToInt32(tboxSlut.Text))
            {
                MessageBox.Show("Slut avnmärkning måste inte bli mindre än Start.");
            }
            if (Convert.ToInt32(tboxStart.Text) > Convert.ToInt32(tboxBredd.Text))
            {
                MessageBox.Show("Start avmärkning måste inte bli mer än Bredd fält.");
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void tboxStart_Enter(object sender, EventArgs e)
        {
            int n;
            if (!(Int32.TryParse(tboxBredd.Text,out n)))
            {
                MessageBox.Show("Du måste änge Bredd värde först.");
                tboxBredd.Focus();
            }
        }

        private void tboxSlut_Enter(object sender, EventArgs e)
        {
            int n;
            if (!(Int32.TryParse(tboxBredd.Text, out n)))
            {
                MessageBox.Show("Du måste änge Bredd värde först.");
                tboxBredd.Focus();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //DataTable dtR= new DataTable()
            
            ////cmd.Connection = ;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM prodDB.dbo.Syningsbänk";

            //SqlDataAdapter dbAdapter = new SqlDataAdapter(cmd);

            //DataTable dtRecords = new DataTable();
            //dbAdapter.Fill(dtRecords);
        }




    }
}
