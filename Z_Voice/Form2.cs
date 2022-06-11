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
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;


namespace Z_Voice
{
    public partial class Form2 : Form
    {
        Form1 f1;

        Boolean com = false;
        static String spch;

        static String locationn = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename = "myDataBase.db";
        static String fullpath = System.IO.Path.Combine(locationn, filename);
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

        static String locationn8 = Application.StartupPath.ToString() + @"\VoiceDB";
        static String filename8 = "action_words.db";
        static String fullpath8 = System.IO.Path.Combine(locationn8, filename8);
        static String connectionString8 = String.Format("Data Source = {0}", fullpath8);

        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        private SoundPlayer myPlayer;

        SerialPort port;

        public Form2()
        {
            InitializeComponent();
        }

        private void init()
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            recognizer.SetInputToDefaultAudioDevice();

            string stmsql = "SELECT * FROM controlpanel";
            var consql = new SQLiteConnection(connectionString);
            consql.Open();
            var cmdsql = new SQLiteCommand(stmsql, consql);
            SQLiteDataReader rdrsql = cmdsql.ExecuteReader();

            
                while (rdrsql.Read())
                {

                    GrammarBuilder gr = new GrammarBuilder();
                    gr.Append(new Choices(rdrsql["cmd"].ToString(), "Shake your hand"));
                    recognizer.LoadGrammar(new Grammar(gr));
                }
            

            consql.Close();


            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(1);

            string stm12 = "SELECT * FROM settings WHERE id = 1";
            var con12 = new SQLiteConnection(connectionString);
            con12.Open();
            var cmd12 = new SQLiteCommand(stm12, con12);
            SQLiteDataReader rdr12 = cmd12.ExecuteReader();

            while (rdr12.Read())
            {

                string stm123 = "SELECT * FROM controlpanel";
                var con123 = new SQLiteConnection(connectionString);
                con123.Open();
                var cmd123 = new SQLiteCommand(stm123, con123);
                SQLiteDataReader rdr123 = cmd123.ExecuteReader();

                while (rdr123.Read())
                {
                    if (e.Result.Text == rdr123["cmd"].ToString())
                    {
                        if (rdr12["att"].ToString() == "Friendly")
                        {
                            if (rdr123["cmd"].ToString() == "Exit")
                            {
                                com = true;
                                voice.Speak(rdr123["speachf"].ToString());
                                exit();
                            }
                        }
                        else if (rdr12["att"].ToString() == "Normal")
                        {
                            if (rdr123["cmd"].ToString() == "Exit")
                            {
                                com = true;
                                voice.Speak(rdr123["speachn"].ToString());
                                exit();
                            }
                        }
                        else if (rdr12["att"].ToString() == "Extreme")
                        {
                            if (rdr123["cmd"].ToString() == "Exit")
                            {
                                com = true;
                                voice.Speak(rdr123["speache"].ToString());
                                exit();
                            }
                        }
                    }
                    else if(e.Result.Text == "Shake your hand")
                    {
                        port = new SerialPort();
                        port.PortName = "COM4";
                        port.BaudRate = 9600;
                        port.Open();

                        port.WriteLine("1");
                        port.Close();
                    }
                }
            }

        }

        void exit()
        {
            recognizer.RecognizeAsyncStop();
            this.Hide();
            f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
       
        }
    }
}
