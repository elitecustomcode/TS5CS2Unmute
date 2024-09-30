using CounterStrike2GSI;
using Microsoft.Extensions.DependencyInjection;
using Narod.SteamGameFinder;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using TS5CS2Unmute.Models;
using Websocket.Client;

namespace TS5CS2Unmute
{
    public partial class Form1 : Form
    {
        private bool isMuted;
        private Uri url;
        private ManualResetEvent exitEvent;
        private WebsocketClient client;

        public Form1()
        {
            InitializeComponent();
            toolTipAssign.SetToolTip(buttonAssign, "First Press this Button, then quickly go to Teamspeak/Hotkey Assigment and press the assign Button for Toggle Microphone");
            buttonAssign.Enabled = false;
            buttonAssign.Visible = false;
            buttonGSIDownload.Enabled = false;
            buttonGSIDownload.Visible = false;
            labelStatus.Text = "Not connected to Teamspeak";
            isMuted = false;
            url = new Uri("ws://localhost:5899");
            exitEvent = new ManualResetEvent(false);
            client = null;

            GameStateListener gsl = new GameStateListener(3000);
            var config = gsl.GenerateGSIConfigFile("TS5Unmute");
            if (!config)
            {
                labelCS2File.Text = "Couldn't write the CS2 Gamestate file";
                buttonGSIDownload.Enabled = true;
                buttonGSIDownload.Visible = true;
            }
            gsl.RoundConcluded += Gsl_RoundConcluded;
            gsl.Start();

            var auth = new Models.Auth();
            auth.type = "auth";
            auth.payload = new Models.Payload();
            auth.payload.identifier = "ts5.cs2.auto.unmute";
            auth.payload.version = "1.0";
            auth.payload.name = "Teamspeak 5 CS2 Auto Unmute";
            auth.payload.description = "This tool autmatically unmutes your Teamspeak 5 Mic when the Round is over";
            auth.payload.content = new Models.Content();
            auth.payload.content.apiKey = String.Empty;
            //TODO CHECK IF API KEY EXISTS
            string ts5ApiKey = (string)Properties.Settings.Default["ts5ApiKey"];
            if (!string.IsNullOrEmpty(ts5ApiKey))
            {
                auth.payload.content.apiKey = ts5ApiKey;
            }

            client = new WebsocketClient(url);

            Task.Run(() => { WebSocketThread(auth); });
        }

        private void Gsl_RoundConcluded(CounterStrike2GSI.EventMessages.RoundConcluded game_event)
        {
            if (isMuted)
            {
                unmute();
            }
        }

        private void WebSocketThread(Models.Auth auth)
        {
            bool isRunning = false;
            while (!isRunning)
            {
                Process[] pname = Process.GetProcessesByName("Teamspeak");
                if (pname.Length != 0)
                {
                    isRunning = true;
                    this.Invoke(() => buttonAssign.Enabled = true);
                    this.Invoke(() => buttonAssign.Visible = true);
                }
                else
                {
                    this.Invoke(() => labelStatus.Text = "Teamspeak is not started yet");
                    this.Invoke(() => Refresh());
                }
                System.Threading.Thread.Sleep(1000);
            }
            using (client)
            {
                client.ReconnectTimeout = TimeSpan.FromDays(1);
                client.MessageReceived.Subscribe(MessageReceived);
                client.Start();

                Task.Run(() => client.Send(JsonConvert.SerializeObject(auth)));

                exitEvent.WaitOne();
            }
        }

        private async void MessageReceived(ResponseMessage msg)
        {
            try
            {
                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(msg.Text);
                if (authResponse != null && authResponse.status != null && authResponse.status.code == 0 && !string.IsNullOrEmpty(authResponse.payload.apiKey))
                {
                    Properties.Settings.Default["ts5ApiKey"] = authResponse.payload.apiKey;
                    Properties.Settings.Default.Save();
                    this.Invoke(() => labelStatus.Text = "Connection to Teamspeak succesfull");
                    this.Invoke(() => Refresh());
                }
                if (authResponse != null && authResponse.payload != null)
                {
                    if (authResponse.payload.flag == "inputMuted" && authResponse.payload.newValue.Value)
                    {
                        this.Invoke(() => isMuted = true);
                        this.Invoke(() => labelStatus.Text = "Microphon is muted");
                        this.Invoke(() => Refresh());
                    }
                    else if (authResponse.payload.flag == "inputMuted" && !authResponse.payload.newValue.Value)
                    {
                        this.Invoke(() => isMuted = false);
                        this.Invoke(() => labelStatus.Text = "Microphon is unmuted");
                        this.Invoke(() => Refresh());
                    }
                }
            }
            catch (Exception ex)
            {
                //Sometimes, there is a Message we dont care about. The model is not prepared for that message, but it doesnt matter
            }
        }

        public void unmute()
        {
            var sendButton = new SendButton();
            sendButton.type = "buttonPress";
            sendButton.payload = new PayloadSend();
            sendButton.payload.state = false;
            sendButton.payload.button = "muteKey";
            Task.Run(() => client.Send(JsonConvert.SerializeObject(sendButton)));
            Task.Run(() => System.Threading.Thread.Sleep(200)).Wait();
            sendButton.payload.state = true;
            Task.Run(() => client.Send(JsonConvert.SerializeObject(sendButton)));
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            Task.Run(() => assignButtonTask());
        }

        private void assignButtonTask()
        {
            this.Invoke(() => buttonAssign.Text = "Assign Hotkey in 5 Seconds");
            this.Invoke(() => Refresh());
            System.Threading.Thread.Sleep(1000);
            this.Invoke(() => buttonAssign.Text = "Assign Hotkey in 4 Seconds");
            this.Invoke(() => Refresh());
            System.Threading.Thread.Sleep(1000);
            this.Invoke(() => buttonAssign.Text = "Assign Hotkey in 3 Seconds");
            this.Invoke(() => Refresh());
            System.Threading.Thread.Sleep(1000);
            this.Invoke(() => buttonAssign.Text = "Assign Hotkey in 2 Seconds");
            this.Invoke(() => Refresh());
            System.Threading.Thread.Sleep(1000);
            this.Invoke(() => buttonAssign.Text = "Assign Hotkey in 1 Seconds");
            this.Invoke(() => Refresh());
            System.Threading.Thread.Sleep(1000);
            unmute();
            this.Invoke(() => buttonAssign.Text = "Assign Pressed");
            this.Invoke(() => Refresh());
        }

        private void buttonGSIDownload_Click(object sender, EventArgs e)
        {
            string path = "";
            SteamGameLocator steamGameLocator = new SteamGameLocator();
            if(steamGameLocator.getIsSteamInstalled())
            {
                string steamGameInstallDir = "";
                try
                {
                    steamGameInstallDir = steamGameLocator.getGameInfoByFolder("Counter-Strike Global Offensive").steamGameLocation;
                }
                catch (Exception ex)
                {
                    //NOTHING, PATH DONT EXIST
                }
                if (!string.IsNullOrEmpty(steamGameInstallDir))
                {
                    path = steamGameInstallDir.Replace("\\\\", "\\");
                }
                else
                {
                    List<string> paths = steamGameLocator.getSteamLibraryLocations();
                    path = paths.FirstOrDefault().Replace("\\\\", "\\");
                }
            }
            else
            {
                path = "C:\\";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Config File|*.cfg";
            saveFileDialog.Title = "Save Game State Integration File";
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.FileName = "gamestate_integration_TS5Unmute.cfg";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                var text = System.IO.File.ReadAllText("Ressources\\gamestate_integration_TS5Unmute.cfg");
                using (var writer = File.AppendText(saveFileDialog.FileName))
                {
                    writer.Write(text);
                }
            }
        }
    }
}
