using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace server
{
    public partial class Form1 : Form
    {
        public  Socket server;
        private byte[] data = new byte[10];
        private int size = 1024;
        private int areaSize = 20;


        private int flagcounter = 0;
        private Boolean wait = false;
        private string opponentCoordinates;
        private int capturedFlagCounter = 0;
        private Boolean flagChoosing = true;
        private List<int> coordinates = new List<int>();
        private List<List<string>> playerFlags = new List<List<string>>();


        public Form1()
        {
            InitializeComponent();
            this.Text = "Player 2";
            Control.CheckForIllegalCrossThreadCalls = false;
            sendButton.Click += new EventHandler(sendbut_Click_1);
            attackCoords.Click += new EventHandler(enter_Click);

            sendButton.Enabled = false;
            attackCoords.Enabled = false;

        }

        private void sendbut_Click_1(object sender, EventArgs e)
        {
            byte[] message = Encoding.ASCII.GetBytes(attackCoords.Text);
            attackCoords.Clear();
            player2Result.Text = "";
            server.BeginSend(message, 0, message.Length, 0, new AsyncCallback(SendData), server);
        }

         private void enter_Click(object sender, EventArgs e)
        {
            player2Result.Text = "";
            player1Result.Text = "";
        }

        void AcceptConn(IAsyncResult iar)
        {
            Socket oldserver = (Socket)iar.AsyncState;
            server = oldserver.EndAccept(iar);
            Console.WriteLine("Connection from: " + server.RemoteEndPoint.ToString());
            Thread receiver = new Thread(new ThreadStart(ReceiveData));
            receiver.Start();
        }
        void Connected(IAsyncResult iar)
        {
            try
            {
                server.EndConnect(iar);
                Console.WriteLine("Connected to: " + server.RemoteEndPoint.ToString());
                Thread receiver = new Thread(new ThreadStart(ReceiveData));
                receiver.Start();
            }
            catch (SocketException)
            {
                Console.WriteLine("Error connecting");
            }
        }

        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
        }

        void ReceiveData()
        {
            int recv = 0;
            string stringData;
            while (true)
            {
                recv = server.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                opponentCoordinates = stringData;
                Console.WriteLine(opponentCoordinates);

                if (stringData == "exit")
                    break;
                else if (stringData == "0")
                {
                    player1Result.Text = "Lose !";
                    player2Result.Text = "Win !";
                    wait = false;
                    sendButton.Enabled = wait;
                    attackCoords.Enabled = wait;
                }

               else if (wait)
                {
                    player1Result.Text = "";
                    if (opponentCoordinates != "-1,-1")
                    {
                        capturedFlagCounter++;
                        player1Result.Text = "Hit!";
                        capturedFlagCount.Text = capturedFlagCounter + "";
                        if (capturedFlagCount.Text == "5")
                        {
                            player1Result.Text = "Win !";
                            player2Result.Text = "Lose !";
                            server.Send(Encoding.ASCII.GetBytes("win"));
                        }
                    }
                    else
                    {
                        player1Result.Text = "Miss!";
                    }

                    wait = false;
                    sendButton.Enabled = wait;
                    attackCoords.Enabled = wait;
                }
                else
                {
                    isHit();
                    Console.WriteLine(" Karşıdan Gelen Mesaj : " + stringData);
                }
                opponentCoordinates = "";
            }
            stringData = "exit";
            byte[] message = Encoding.ASCII.GetBytes(stringData);
            server.Send(message);
            server.Close();
            Console.WriteLine("Connection stopped");
            return;
        }

        private void isHit()
        {
            Boolean hit = false, repeatedHit = false;
            int flagIndex = -1;
            string flagCoords = "-1,-1";
            for (int flag = 0; flag < playerFlags.Count; flag++)
            {
                if (playerFlags.ElementAt(flag).Contains(opponentCoordinates))
                {

                    if (!(player1Flags.Items[flag] + "").Contains("(Captured)"))
                    {
                        hit = true;
                        player2Result.Text = "Hit!";
                        flagIndex = flag;

                        flagCoords = player1Flags.Items[flag] + "";

                        player1Flags.Items.RemoveAt(flag);
                        player1Flags.Items.Insert(flag, flagCoords + " (Captured) ");
                    }
                }
            }
            if (hit == false && repeatedHit == false)
            {
                player2Result.Text = "Miss!";
            }

            server.Send(Encoding.ASCII.GetBytes(flagCoords));
            wait = true;
            sendButton.Enabled = wait;
            attackCoords.Enabled = wait;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            var MouseX = coordinates.X;
            var MouseY = coordinates.Y;

            var coorText = MouseX + "," + MouseY;

            if (flagChoosing)
            {
                flagcounter++;
                // FlagCoordinates1.Items.Add(flagcounter+". flag : "+coorText);
                player1Flags.Items.Add(coorText);
                var coords = coorText.Split(',');

                this.coordinates.Add(int.Parse(coords[0]));
                this.coordinates.Add(int.Parse(coords[1]));

                List<string> flag = new List<string>();
                for (int x = this.coordinates.ElementAt(0) - areaSize / 2; x < this.coordinates.ElementAt(0) + areaSize / 2; x++)
                {
                    for (int y = this.coordinates.ElementAt(1) - areaSize / 2; y < this.coordinates.ElementAt(1) + areaSize / 2; y++)
                    {
                        var coord_temp = x + "," + y;
                        flag.Add(coord_temp);
                    }
                }
                playerFlags.Add(flag);
                this.coordinates.Clear();
                if (flagcounter == 5)
                {
                    flagChoosing = false;
                    sendButton.Enabled = wait;
                    attackCoords.Enabled = wait;

                    for (int i = 0; i < playerFlags.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". Flag : {");
                        for (int c = 0; c < areaSize * areaSize; c++)
                        {
                            Console.Write(playerFlags.ElementAt(i).ElementAt(c) + ", ");
                            if ((c + 1) % 16 == 0) { Console.WriteLine(""); }
                        }
                        Console.WriteLine("}");
                    }
                }
            }
            else { attackCoords.Text = coorText; }
        }

        private void listen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("“Listening for a client...”");
             Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            newsock.Bind(iep);
            newsock.Listen(5);
            newsock.BeginAccept(new AsyncCallback(AcceptConn), newsock);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("“Listening for a client...”");
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
           ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(iep);
            server.Listen(5);
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }
    }
}