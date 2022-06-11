using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Data.SQLite;
using SpeechLib;
using System.Speech.Synthesis;
using System.Threading;
using System.Media;

namespace Z_Voice
{
    public partial class Form1 : Form
    {
        Form2 f2;
        Boolean com = false;
        Boolean comz = false;
        Boolean openeyesstart = false;
        Boolean blinkr = false;
        Boolean blinkrreturn = false;
        Boolean blinkl = false;
        Boolean angry = false;
        Boolean angryreturn = false;
        Boolean shutdowneyes = false;
        static String spch;

        static String locationn = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename = "myDataBase.db";
        static String fullpath= System.IO.Path.Combine(locationn, filename);
        static String connectionString = String.Format("Data Source = {0}", fullpath);

        static String locationn2 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename2 = "app_history.db";
        static String fullpath2 = System.IO.Path.Combine(locationn2, filename2);
        static String connectionString2 = String.Format("Data Source = {0}", fullpath2);

        static String locationn3 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename3 = "recogn.db";
        static String fullpath3 = System.IO.Path.Combine(locationn3, filename3);
        static String connectionString3 = String.Format("Data Source = {0}", fullpath3);

        static String locationn5 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename5 = "remm.db";
        static String fullpath5 = System.IO.Path.Combine(locationn5, filename5);
        static String connectionString5 = String.Format("Data Source = {0}", fullpath5);

        static String locationn6 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename6 = "speeches.db";
        static String fullpath6 = System.IO.Path.Combine(locationn6, filename6);
        static String connectionString6 = String.Format("Data Source = {0}", fullpath6);

        static String locationn7 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename7 = "status.db";
        static String fullpath7 = System.IO.Path.Combine(locationn7, filename7);
        static String connectionString7 = String.Format("Data Source = {0}", fullpath7);

        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechRecognitionEngine recognizercmd = new SpeechRecognitionEngine();
        private SoundPlayer myPlayer;

        public static DateTime Today { get; }

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            saveactstartup();

        }





        ///Boundary






        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm12 = "SELECT * FROM settings WHERE id = 1";
            var con12 = new SQLiteConnection(connectionString);
            con12.Open();
            var cmd12 = new SQLiteCommand(stm12, con12);
            SQLiteDataReader rdr12 = cmd12.ExecuteReader();

            while(rdr12.Read())
            {

                string stm123 = "SELECT * FROM commands";
                var con123 = new SQLiteConnection(connectionString);
                con123.Open();
                var cmd123 = new SQLiteCommand(stm123, con123);
                SQLiteDataReader rdr123 = cmd123.ExecuteReader();

                while (rdr123.Read())
                {
                    if (rdr123["cmd"].ToString() == e.Result.Text)
                    {
                        if (rdr12["att"].ToString() == "Friendly")
                        {
                            if (rdr123["cmd"].ToString() == "Hey Z")
                            {
                                com = true;
                                heyz();
                            }
                            else if (rdr123["cmd"].ToString() == "Shutdown")
                            {
                                com = true;
                                shut();
                            }
                            else if (rdr123["cmd"].ToString() == e.Result.Text)
                            {
                                voice.Speak(rdr123["speachf"].ToString());
                            }
                        }
                        else if (rdr12["att"].ToString() == "Normal")
                        {
                            if (rdr123["cmd"].ToString() == "Hey Z")
                            {
                                com = true;
                                heyz();
                            }
                            else if (rdr123["cmd"].ToString() == "Shutdown")
                            {
                                com = true;
                                shut();
                            }
                            else if (rdr123["cmd"].ToString() == e.Result.Text)
                            {
                                voice.Speak(rdr123["speachn"].ToString());
                            }
                        }
                        else if (rdr12["att"].ToString() == "Extreme")
                        {
                            if (rdr123["cmd"].ToString() == "Hey Z")
                            {
                                com = true;
                                heyz();
                            }
                            else if (rdr123["cmd"].ToString() == "Shutdown")
                            {
                                com = true;
                                shut();
                            }
                            else if (rdr123["cmd"].ToString() == e.Result.Text)
                            {
                                voice.Speak(rdr123["speache"].ToString());
                            }
                        }
                    }
                    else if(e.Result.Text == "Wink Right Eye")
                    {
                        blinkr = true;
                        timer2.Start();
                    }
                    else if (e.Result.Text == "Angry Eyes")
                    {
                        angry = true;
                        timer2.Start();
                    }
                }
            }
        }

        void heyz()
        {

            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm1 = "SELECT * FROM settings WHERE id = 1";
            var con1 = new SQLiteConnection(connectionString);
            con1.Open();
            var cmd1 = new SQLiteCommand(stm1, con1);
            SQLiteDataReader rdr1 = cmd1.ExecuteReader();
            rdr1.Read();

            Random rn = new Random();
            int rnum = rn.Next(1, 5);

            if (rdr1["att"].ToString() == "Friendly")
            {
                spch = "friendly";
            }
            else if (rdr1["att"].ToString() == "Normal")
            {
                spch = "normal";
            }
            else if (rdr1["att"].ToString() == "Extreme")
            {
                spch = "extreme";
            }

            string stm2 = "SELECT * FROM " + spch + " WHERE id = " + rnum;
            var con2 = new SQLiteConnection(connectionString6);
            con2.Open();
            var cmd2 = new SQLiteCommand(stm2, con2);
            SQLiteDataReader rdr2 = cmd2.ExecuteReader();
            rdr2.Read();
            voice.Speak(rdr2["resp"].ToString());
            con2.Close();

            con1.Close();

            recognizer.RecognizeAsyncCancel();
            this.Hide();
            f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        void shut()
        {

            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm1 = "SELECT * FROM settings WHERE id = 1";
            var con1 = new SQLiteConnection(connectionString);
            con1.Open();
            var cmd1 = new SQLiteCommand(stm1, con1);
            SQLiteDataReader rdr1 = cmd1.ExecuteReader();
            rdr1.Read();

            Random rn = new Random();
            int rnum = rn.Next(27, 31);

            if (rdr1["att"].ToString() == "Friendly")
            {
                spch = "friendly";
            }
            else if (rdr1["att"].ToString() == "Normal")
            {
                spch = "normal";
            }
            else if (rdr1["att"].ToString() == "Extreme")
            {
                spch = "extreme";
            }

            string stm2 = "SELECT * FROM " + spch + " WHERE id = " + rnum;
            var con2 = new SQLiteConnection(connectionString6);
            con2.Open();
            var cmd2 = new SQLiteCommand(stm2, con2);
            SQLiteDataReader rdr2 = cmd2.ExecuteReader();
            rdr2.Read();
            voice.Speak(rdr2["resp"].ToString());
            con2.Close();

            con1.Close();

            recognizer.RecognizeAsyncCancel();
            shutdowneyes = true;
            timer2.Start();
        }





        ///Boundary





        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaCircleProgressBar1.Increment(1);
        }


     

        void PlaySoundFile()
        {
            myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = Application.StartupPath.ToString() + @"\sounds\space_signals.wav";
            myPlayer.Play();
        }

        void PlaySoundFile2()
        {
            myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = Application.StartupPath.ToString() + @"\sounds\space_message.wav";
            myPlayer.Play();
        }

        void saveactstartup()
        {
            string function = "Online";
            string query = "UPDATE online_status SET status = '" + function + "', color = 'green' WHERE id = 1";

            SQLiteConnection conn = new SQLiteConnection(connectionString7);
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            DateTime dt = DateTime.UtcNow.Date;

            string function2 = "Run Successful";
            string query2 = "INSERT INTO startup (status, date_start) " +
                "VALUES " +
                "(" +
                "'" + function2 + "', " +
                "'" + dt.ToString("dd/MM/yyyy") + "' " +
                ")";

            SQLiteConnection conn2 = new SQLiteConnection(connectionString3);
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            conn2.Open();
            cmd2.ExecuteNonQuery();
            conn2.Close();
        }



                                              /*Boundary*/





       void totalshut()
        {
            

            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm112 = "SELECT * FROM settings WHERE id = 1";
            var con112 = new SQLiteConnection(connectionString);
            con112.Open();
            var cmd112 = new SQLiteCommand(stm112, con112);
            SQLiteDataReader rdr112 = cmd112.ExecuteReader();
            rdr112.Read();

            Random rn12 = new Random();
            int rnum12 = rn12.Next(16, 18);

            if (rdr112["att"].ToString() == "Friendly")
            {
                spch = "friendly";
            }
            else if (rdr112["att"].ToString() == "Normal")
            {
                spch = "normal";
            }
            else if (rdr112["att"].ToString() == "Extreme")
            {
                spch = "extreme";
            }

            string stm212 = "SELECT * FROM " + spch + " WHERE id = " + rnum12;
            var con212 = new SQLiteConnection(connectionString6);
            con212.Open();
            var cmd212 = new SQLiteCommand(stm212, con212);
            SQLiteDataReader rdr212 = cmd212.ExecuteReader();
            rdr212.Read();
            voice.Speak(rdr212["resp"].ToString());
            con212.Close();

            con112.Close();


            DialogResult result = MessageBox.Show("System Shutdown?", "Confirmation Request", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                totalshutcon();
            }
            else if (result == DialogResult.No)
            {

                string stm1123 = "SELECT * FROM settings WHERE id = 1";
                var con1123 = new SQLiteConnection(connectionString);
                con1123.Open();
                var cmd1123 = new SQLiteCommand(stm1123, con1123);
                SQLiteDataReader rdr1123 = cmd1123.ExecuteReader();
                rdr1123.Read();

                Random rn123 = new Random();
                int rnum123 = rn123.Next(19, 21);

                if (rdr1123["att"].ToString() == "Friendly")
                {
                    spch = "friendly";
                }
                else if (rdr1123["att"].ToString() == "Normal")
                {
                    spch = "normal";
                }
                else if (rdr1123["att"].ToString() == "Extreme")
                {
                    spch = "extreme";
                }

                string stm21233 = "SELECT * FROM " + spch + " WHERE id = " + rnum123;
                var con21233 = new SQLiteConnection(connectionString6);
                con21233.Open();
                var cmd21233 = new SQLiteCommand(stm21233, con21233);
                SQLiteDataReader rdr21233 = cmd21233.ExecuteReader();
                rdr21233.Read();
                voice.Speak(rdr21233["resp"].ToString());
                con21233.Close();

                con1123.Close();

                recognizer.RecognizeAsyncStop();

            }
        }


        void totalshutcon()
        {
            
            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm11232 = "SELECT * FROM settings WHERE id = 1";
            var con11232 = new SQLiteConnection(connectionString);
            con11232.Open();
            var cmd11232 = new SQLiteCommand(stm11232, con11232);
            SQLiteDataReader rdr11232 = cmd11232.ExecuteReader();
            rdr11232.Read();

            Random rn1232 = new Random();
            int rnum1232 = rn1232.Next(11, 15);

            if (rdr11232["att"].ToString() == "Friendly")
            {
                spch = "friendly";
            }
            else if (rdr11232["att"].ToString() == "Normal")
            {
                spch = "normal";
            }
            else if (rdr11232["att"].ToString() == "Extreme")
            {
                spch = "extreme";
            }

            string stm21232 = "SELECT * FROM " + spch + " WHERE id = " + rnum1232;
            var con21232 = new SQLiteConnection(connectionString6);
            con21232.Open();
            var cmd21232 = new SQLiteCommand(stm21232, con21232);
            SQLiteDataReader rdr21232 = cmd21232.ExecuteReader();
            rdr21232.Read();
            voice.Speak(rdr21232["resp"].ToString());
            con21232.Close();

            con11232.Close();

            DateTime dt = DateTime.UtcNow.Date;
            string time = DateTime.Now.ToString("h:mm tt");

            string function21212 = "Computer Shutdown";
            string query21212 = "INSERT INTO activity_memory (function, time_opened, date_opened) " +
                "VALUES " +
                "(" +
                "'" + function21212 + "', " +
                "'" + time + "', " +
                "'" + dt.ToString("dd/MM/yyyy") + "' " +
                ")";

            SQLiteConnection conn21212 = new SQLiteConnection(connectionString2);
            SQLiteCommand cmd21212 = new SQLiteCommand(query21212, conn21212);
            conn21212.Open();
            cmd21212.ExecuteNonQuery();
            conn21212.Close();

            recognizer.RecognizeAsyncStop();
        }

        void restart()
        {

        }

        void shutdown()
        {
            if (com == true)
            {

                DateTime dt = DateTime.UtcNow.Date;
                string time = DateTime.Now.ToString("h:mm tt");

                string function212124 = "System Shutdown";
                string query212124 = "INSERT INTO activity_memory (function, time_opened, date_opened) " +
                    "VALUES " +
                    "(" +
                    "'" + function212124 + "', " +
                    "'" + time + "', " +
                    "'" + dt.ToString("dd/MM/yyyy") + "' " +
                    ")";

                SQLiteConnection conn212124 = new SQLiteConnection(connectionString2);
                SQLiteCommand cmd212124 = new SQLiteCommand(query212124, conn212124);
                conn212124.Open();
                cmd212124.ExecuteNonQuery();
                conn212124.Close();

                string function2 = "Offline";
                string query2 = "UPDATE online_status SET status = '" + function2 + "', color = 'red' WHERE id = 1";

                SQLiteConnection conn2 = new SQLiteConnection(connectionString7);
                SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
                conn2.Open();
                cmd2.ExecuteNonQuery();
                conn2.Close();


                recognizer.RecognizeAsyncStop();
                PlaySoundFile2();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Environment.Exit(1);
            }
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleProgressBar2_Click(object sender, EventArgs e)
        {

        }

        void eyesopen()
        {
            openeyesstart = true;
            timer2.Start();
        }


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            int loadingSpeed = 3;
            int loadingspeed2 = 2;

            if (openeyesstart == true)
            {

                //downlid
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + loadingSpeed);
                panel4.Location = new Point(panel4.Location.X, panel4.Location.Y + loadingSpeed);

                //uplid
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - loadingSpeed);
                panel3.Location = new Point(panel3.Location.X, panel3.Location.Y - loadingSpeed);

                Label2.Location = new Point(Label2.Location.X, Label2.Location.Y + loadingspeed2);

                if (panel2.Location.Y == 37 && panel3.Location.Y == 37)
                {
                    openeyesstart = false;
                    timer2.Stop();
                }

            }
            else if(shutdowneyes == true)
            {
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - loadingSpeed);
                panel4.Location = new Point(panel4.Location.X, panel4.Location.Y - loadingSpeed);

                //uplid
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + loadingSpeed);
                panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + loadingSpeed);

                Label2.Location = new Point(Label2.Location.X, Label2.Location.Y - loadingspeed2);

                if (panel2.Location.Y == 52 && panel3.Location.Y == 52)
                {
                    shutdowneyes = false;
                    timer2.Stop();
                    Thread.Sleep(500);
                    Environment.Exit(1);
                }
            }
            else if(blinkr == true)
            {
                //blink right eye
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - loadingSpeed);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + loadingSpeed);

                if (panel1.Location.Y == 67 && panel2.Location.Y == 52)
                {
                    blinkr = false;
                    timer2.Stop();
                    blinkrreturn = true;
                    timer3.Start();
                }
            }
            else if (angry == true)
            {
                //blink right eye
                panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + loadingSpeed);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + loadingSpeed);

                if (panel3.Location.Y == 52 && panel2.Location.Y == 52)
                {
                    Thread.Sleep(1000);
                    angry = false;
                    timer2.Stop();
                    angryreturn = true;
                    timer3.Start();
                }
            }
        }

        private void Label2_Click_1(object sender, EventArgs e)
        {
            Label2.ForeColor = Color.White;

            try
            {

                recognizer.SetInputToDefaultAudioDevice();

                string stm = "SELECT * FROM commands";
                var con = new SQLiteConnection(connectionString);
                con.Open();
                var cmd = new SQLiteCommand(stm, con);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GrammarBuilder gr = new GrammarBuilder();
                    gr.Append(new Choices(rdr["cmd"].ToString(),"Wink Right Eye", "Wink Left Eye", "Angry Eyes"));
                    recognizer.LoadGrammar(new Grammar(gr));
                }
                con.Close();

                recognizer.SpeechRecognized += recognizer_SpeechRecognized;
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                eyesopen();

            }
            catch (Exception x)
            {

                SpVoice voice = new SpVoice();
                voice.Voice = voice.GetVoices().Item(1);

                string stm1 = "SELECT * FROM settings WHERE id = 1";
                var con1 = new SQLiteConnection(connectionString);
                con1.Open();
                var cmd1 = new SQLiteCommand(stm1, con1);
                SQLiteDataReader rdr1 = cmd1.ExecuteReader();
                rdr1.Read();

                Random rn = new Random();
                int rnum = rn.Next(22, 26);

                if (rdr1["att"].ToString() == "Friendly")
                {
                    spch = "friendly";
                }
                else if (rdr1["att"].ToString() == "Normal")
                {
                    spch = "normal";
                }
                else if (rdr1["att"].ToString() == "Extreme")
                {
                    spch = "extreme";
                }

                string stm2 = "SELECT * FROM " + spch + " WHERE id = " + rnum;
                var con2 = new SQLiteConnection(connectionString6);
                con2.Open();
                var cmd2 = new SQLiteCommand(stm2, con2);
                SQLiteDataReader rdr2 = cmd2.ExecuteReader();
                rdr2.Read();
                voice.Speak(rdr2["resp"].ToString());
                con2.Close();

                con1.Close();

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int loadingSpeed = 3;

            if (blinkrreturn == true)
            {
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + loadingSpeed);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - loadingSpeed);

                if (panel1.Location.Y == 82 && panel2.Location.Y == 37)
                {
                    blinkrreturn = false;
                    timer3.Stop();
                }
            }
            else if(angryreturn == true)
            {
                panel3.Location = new Point(panel3.Location.X, panel3.Location.Y - loadingSpeed);
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - loadingSpeed);

                if(panel3.Location.Y == 37 && panel2.Location.Y == 37)
                {
                    angryreturn = false;
                    timer3.Stop();
                }
            }
        }
    }
}
