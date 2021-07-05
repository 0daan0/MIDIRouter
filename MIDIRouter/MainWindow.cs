using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using NAudio;
using NAudio.Midi;

namespace MIDIRouter
{

    public partial class MainWindow : Form
    {
        #region dllimport
        // MCI INterface
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command,
           StringBuilder returnValue, int returnLength,
           IntPtr winHandle);

        // Midi API
        [DllImport("winmm.dll")]
        private static extern int midiOutGetNumDevs();

        [DllImport("winmm.dll")]
        private static extern int midiOutGetDevCaps(Int32 uDeviceID,
           ref MidiOutCaps lpMidiOutCaps, UInt32 cbMidiOutCaps);

        [DllImport("winmm.dll")]
        private static extern int midiOutOpen(ref int handle,
           int deviceID, MidiCallBack proc, int instance, int flags);

        [DllImport("winmm.dll")]
        private static extern int midiOutShortMsg(int handle,
           ulong message);

        [DllImport("winmm.dll")]
        private static extern int midiOutClose(int handle);

        private delegate void MidiCallBack(int handle, int msg,
           int instance, int param1, int param2);
        #endregion

        public class InputPort
        {
            private NativeMethods.MidiInProc midiInProc;
            private IntPtr handle;

            public InputPort()
            {
                midiInProc = new NativeMethods.MidiInProc(MidiProc);
                handle = IntPtr.Zero;
            }

            public static int InputCount
            {
                get { return NativeMethods.midiInGetNumDevs(); }
            }

            public bool Close()
            {
                bool result = NativeMethods.midiInClose(handle)
                    == NativeMethods.MMSYSERR_NOERROR;
                handle = IntPtr.Zero;
                return result;
            }

            public bool Open(int id)
            {
                return NativeMethods.midiInOpen(
                    out handle,
                    id,
                    midiInProc,
                    IntPtr.Zero,
                    NativeMethods.CALLBACK_FUNCTION)
                        == NativeMethods.MMSYSERR_NOERROR;
            }

            public bool Start()
            {
                return NativeMethods.midiInStart(handle)
                    == NativeMethods.MMSYSERR_NOERROR;
            }

            public bool Stop()
            {
                return NativeMethods.midiInStop(handle)
                    == NativeMethods.MMSYSERR_NOERROR;
            }

            private void MidiProc(IntPtr hMidiIn,
                int wMsg,
                IntPtr dwInstance,
                int dwParam1,
                int dwParam2)
            {
                // Receive messages here
            }
        }

        internal static class NativeMethods
        {
            internal const int MMSYSERR_NOERROR = 0;
            internal const int CALLBACK_FUNCTION = 0x00030000;

            internal delegate void MidiInProc(
                IntPtr hMidiIn,
                int wMsg,
                IntPtr dwInstance,
                int dwParam1,
                int dwParam2);

            [DllImport("winmm.dll")]
            internal static extern int midiInGetNumDevs();

            [DllImport("winmm.dll")]
            internal static extern int midiInClose(
                IntPtr hMidiIn);

            [DllImport("winmm.dll")]
            internal static extern int midiInOpen(
                out IntPtr lphMidiIn,
                int uDeviceID,
                MidiInProc dwCallback,
                IntPtr dwCallbackInstance,
                int dwFlags);

            [DllImport("winmm.dll")]
            internal static extern int midiInStart(
                IntPtr hMidiIn);

            [DllImport("winmm.dll")]
            internal static extern int midiInStop(
                IntPtr hMidiIn);
        }

        //// midi callback input 
        //private delegate void MidiCallBack(int handle, int msg,
        //int instance, int param1, int param2);

        static string Mci(string command)
        {
            StringBuilder reply = new StringBuilder(256);
            mciSendString(command, reply, 256, IntPtr.Zero);
            return reply.ToString();
        }

        // virtual midi ports
        public  TeVirtualMIDI portIn;
        public TeVirtualMIDI portOut;
        public  TeVirtualMIDI PianoOut;
        public TeVirtualMIDI Piano2Out;

        // user midi command
        public string txMidi = "";
        public string userMidiVolumme = "";

        private string appName = "Disklavier Companion";
        private string appVersion = "Application-version: v 2.0 c.2019";
        private string teMidiVerison = "using tevMidi dll-version:" + TeVirtualMIDI.versionString;
        private string vMidiDriverVersion = "using driver-version: " + TeVirtualMIDI.driverVersionString;

        #region midi channels
        // list to keep track witch channel is used for other instruments than piano
        public List<string> otherInstruments;

        // list to keep track witch channel is used for an instrument
        public List<string> Mididevices;

        // list to keep track witch channels are used for piano
        public List<string> PianoChannels;

        // buffer list for non piano commands
        public List<string> midiBuffer;
        
        /// <summary>
        /// Stores the current instrument per channel
        /// </summary>

        public int delayTimeSynth = MIDIRouter.Properties.Settings.Default.delayTimeSynth;
        public int delayTimePiano = MIDIRouter.Properties.Settings.Default.delayTimePiano;

        private string RemapInstrument = null;
        private bool remapCh1 = false;
        private string RemapedChannel = null;
        private bool PianoInTrack = false;
        private bool firstRun = true;
        private bool setPianoCh1 = false;
        public bool synthPiano;
        private bool vMidiPort = false;
        private bool karToPiano = false;
        public string karChan;
        public bool mainInit = false;
        public bool sysLogging = false;
        
        private string RemapInput; 

        private string ProgramChange = "C";
        private string NoteOn = "90";
        private string NoteOff = "80";
        private string ControlChange = "B";
        private string PolyphonicAftertouch = "A";
        private string ChannelAftertouch = "D";
        private string PichWhele = "E";
        private string SysEx = "F0";

        private int pOutRes;
        private int sOutRes;
        private int pHandle = 0;
        private int sHandle = 0;
        bool exit = false;
        bool recordMidi = false;
        bool saveRecordMidi = false;
        MidiIn midiIn;
        #endregion

        #region publicFunctions
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static int [] StringToIntAray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToInt32(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static int[] ByteArrayToIntArray(byte[] ba)
        {
            int[] bytesAsInts = ba.Select(x => (int)x).ToArray();

            return bytesAsInts;
        }
        public string byteArrayToString(byte[] ba)
        {

            string hex = BitConverter.ToString(ba);

            return hex.Replace("-", "");

        }
        public string byteArrayReverseString(byte[] ba)
        {
            Array.Reverse(ba, 0, ba.Length);
            string hex = byteArrayToString(ba);

            return hex;
        }
        public ulong stringToReverseLong(string c)
        {
            byte[] bar = StringToByteArray(c);
            string rev = byteArrayReverseString(bar);
            if (rev.Length > 6)
            {
                UInt64 result = UInt64.Parse(rev, System.Globalization.NumberStyles.AllowHexSpecifier);
                return result;
            }
            else
            {
                UInt32 result = UInt32.Parse(rev, System.Globalization.NumberStyles.AllowHexSpecifier);
                return result;
            }
        }
     
        public void DkcDisplay(string message)
        {
            try
            {
                    this.Invoke((MethodInvoker)(() => DkcDisplay1.ResetText()));
                    this.Invoke((MethodInvoker)(() => DkcDisplay1.Text = message.ToString()));
            }
            catch
            {
            }
        }
        public void testMIDI()       
        {        
            // Set piano instrument to piano
            sendToPiano("C000");
            // Set synth instrument to strings
            sendToSynth("C000");
            string velos = "7F";
            //int i = 22;
            int i = 67;
            //while (i != 109)
            while (i != 65)
            {
                string noteNr = i.ToString("X");
                sendToSynth(NoteOn + noteNr + velos);
                sendToPiano(NoteOn + noteNr + velos);
                i--;                
                Thread.Sleep(500);
                sendToSynth(NoteOff + noteNr + velos);
                sendToPiano(NoteOff + noteNr + velos);
            }
          
        }
        public void playStoredMidi()
        {
            log("PLAY_STORED_MIDI_DATA");
            Thread playThread = new Thread(playMidiMusic);
            playThread.Start();
        }
        public void playMidiMusic()
        {
            try
            {
                var list = MIDIRouter.Properties.Settings.Default.SavedMusic.Cast<string>().ToList();
                foreach (string c in list)
                {

                    string time = c.Split(':')[0];
                    string note = c.Split(':')[1];

                    //log(c);

                    if (!note.StartsWith(ControlChange) && (!note.StartsWith(ProgramChange)))
                    {
                        string c2 = note.Substring(1, 1);
                        //get the status bit
                        string stbit = note.Substring(0, 1);
                        //get the data
                        string data = note.Substring(2);
                        // prepare piano midi command
                        string pianoCommand = stbit + "0" + data;
                        sendToPiano(pianoCommand);
                    }
                    sendToSynth(note);
                    Thread.Sleep(int.Parse(time));
                }
            }
            catch
            {
                log("FAILED_PLAY_LOCAL_MIDI");
            }
        }
		public void WorkThreadFunction() {

			byte[] command;
            otherInstruments = new List<string>();
            PianoChannels = new List<string>();
            midiBuffer = new List<string>();
            Mididevices = new List<string>();
            System.Collections.Specialized.StringCollection MidiMusic = new System.Collections.Specialized.StringCollection();
            //StringCollection MidiMusic = new StringCollection();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();

			try {
				while ( true )
                {                    
                    watch.Reset();
					command = portIn.getCommand();
                    string c = byteArrayToString(command);
                    
                    // record incomming midi
                    if (recordMidi)
                    {
                        watch.Start();
                        var elapsedMs = watch.ElapsedMilliseconds * 1000000;
                        
                        MidiMusic.Add(elapsedMs.ToString()+":"+ c);
                        //log(elapsedMs.ToString() + " time " + c);
                        if (saveRecordMidi)
                        {
                            MIDIRouter.Properties.Settings.Default.SavedMusic = MidiMusic;
                            saveRecordMidi = false;
                            recordMidi = false;
                        }
                                                                  
                    }

                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        RxIn.BackColor = System.Drawing.Color.Red;
                        log("RX:"+c+ "Byte:"+command);
                    }
                    else
                    {
                        RxIn.BackColor = System.Drawing.Color.Transparent;
                        TxPiano.BackColor = System.Drawing.Color.Transparent;
                        TxSynth.BackColor = System.Drawing.Color.Transparent;
                    }
 
                    #region Instrument redirection 
                    
                    /// process program change commands
                    if (c.StartsWith(ProgramChange))
                    {
                        //Get the channel hex nr.
                        string c2 = c.Substring(1, 1);
                        log(c2);

                        //get the instrument hex nr.
                        string c1 = c.Substring(2, 2);
                        log(c1);

                        //Parse hex to int for channel and instrument 
                        int instrumentNr = int.Parse(c1, System.Globalization.NumberStyles.HexNumber);
                        int channelNr = int.Parse(c2, System.Globalization.NumberStyles.HexNumber);
                        log(channelNr.ToString());
                        log(instrumentNr.ToString());

                        log("Channel list items:" + otherInstruments.Count.ToString());

                        if (instrumentNr >= 5)
                        {
                            log("INSTR(SYNTH?):" + instrumentNr + "_ON_CH:" + channelNr);
                            otherInstruments.Add(c2);
                            sendToSynth(c);
                        }
                        else 
                        {
                            log("INSTR(PIANO?):" + instrumentNr + "_ON_CH:" + channelNr);
                            sendToPiano(c);

                            if (synthPiano)
                            {
                                sendToSynth(c);
                            }
                        }
                     
                        #region oldChannelSelect
                        //if (channelNr == 0)
                        //{
                        //    log("INSTRUMENT_CH0: " + instrumentNr+" HEX: "+c1);
                        //    // check if there is a piano on channel 1
                        //    if (instrumentNr <= 5) 
                        //    {
                        //        // no need to change, send command to midi out ports
                        //        log("Already piano nr: " + instrumentNr + " on ch1");
                        //        sendToPiano(c);
                        //        if (synthPiano)
                        //        {
                        //            sendToSynth(c);
                        //        }
                        //        PianoChannels.Add(c2);
                        //    }
                        //    else
                        //    {
                        //        // store original instrument from channel 1 to be remapped after all channels are filled and we find a empty channel
                        //        RemapInstrument = c1;
                        //        log("no piano on ch1, moving " + instrumentNr);
                        //        remapCh1 = true;

                        //        // send program change to piano on channel 1
                        //        sendToPiano("C000");
                        //        if (synthPiano)
                        //        {
                        //            sendToSynth(c);
                        //        }
                        //    }
                        //}
                        
                        //else
                        //{
                        //    // check if the instrument is a piano, if so store channel nr in the list to redirect all note data from that channel to to channel 1
                        //    if (c.StartsWith(ProgramChange) && instrumentNr <= 5 && channelNr != 9)
                        //    {
                        //        // store all channels that are used by a piano
                        //        log("found piano on ch" + channelNr);
                        //        PianoChannels.Add(c2);
                        //        PianoInTrack = true;
    
                        //    }
                        //    else
                        //    {
                        //        // nothing to process just continue
                        //        sendToSynth(c);
                        //    }

                        //}
                        #endregion
                    }


                    #endregion

                    #region old
                    //else if (c.StartsWith(NoteOn))
                    //{
                    //    if (remapCh1 && (PianoInTrack) && (RemapInstrument != null) && (MidiChannels.Contains("")))
                    //    {
                    //        int channel = MidiChannels.FindIndex(a => a == "");
                    //        channel++;
                    //        log("FREE Chanel " + channel.ToString("X"));
                    //        RemapedChannel = channel.ToString("X");
                    //        portOut.sendCommand(StringToByteArray("C" + channel.ToString("X") + RemapInstrument));

                    //    }
                    //    else if (!PianoInTrack)
                    //    {
                    //        // no piano in track set original instrument on ch1
                    //        portOut.sendCommand(StringToByteArray("C0"+RemapInstrument));
                    //    }

                    //}

                    #endregion

                    #region Reset
                    // Handle Sysex messages
                    if (c.StartsWith(SysEx))
                    {
                        log("SYSTEM_DATA:" + c.ToString());
                        if (c.Length > 10)
                        {
                            if (c.StartsWith("F043710303"))
                            {
                               Invoke((MethodInvoker)(() => DkcDisplay1.ResetText()));
                               Invoke((MethodInvoker)(() => DkcDisplay1.AppendText(ConvertHex(c))));
                            }
                            if (c.StartsWith("F043710302"))
                            {
                               Invoke((MethodInvoker)(() => DkcDisplay2.ResetText()));
                               Invoke((MethodInvoker)(() => DkcDisplay2.AppendText(ConvertHex(c))));
                            }
                              
                            string cha = ConvertHex(c.ToString());
                            log("SysString: " + cha);
                            //DkcDisplay(cha);
                        }
                        
                        
                        // if message is reset, clear all local midi data 
                        if (c == "F07E7F0901F7")
                        {
                            log("RESET");
                            PianoChannels.Clear();
                            RemapInstrument = null;
                            remapCh1 = false;
                            RemapedChannel = null;
                            PianoInTrack = false;
                            firstRun = true;
                            otherInstruments.Clear();
                            log(otherInstruments.Count.ToString());
                                           
                            sendToPiano(byteArrayToString(command));
                            sendToSynth(byteArrayToString(command));


                        }
                        sendToPiano(byteArrayToString(command));
                        sendToSynth(byteArrayToString(command));
                    }

                    #endregion

                    #region MIDI Music DATA 
                    // analyse note data for piano notes and send it to piano or synth
                    if (!c.StartsWith(ProgramChange))
                    {
                        //Get the channel hex nr.
                        string c2 = c.Substring(1, 1);
                        //get channel int
                        int channelNr = int.Parse(c2, System.Globalization.NumberStyles.HexNumber);
                        //get the status bit
                        string stbit = c.Substring(0, 1);
                        //get the data
                        string data = c.Substring(2);
                        // prepare piano midi command
                        string pianoCommand = stbit + "0" + data;
                        
                        // redirecting note data to correct midi output 
                        if (otherInstruments.Contains(c2))
                        {
                            // note is for synth if karaoke channel is selected redirect to piano
                            if (karToPiano && c2 == karChan)
                            {
                                log("SEND_TO_PIANO(KARCHAN): " + pianoCommand);
                                sendToPiano(pianoCommand);
                            }
                            // else send to synth
                            else
                            {
                                log("SEND_TO_SYNTH: "+c);
                                sendToSynth(c);
                            }
                        }
                        // if note is not for known synth instrument we can assume it is piano. check if it is not on the drum channel (mostly it wil be drums on ch9*10)
                        else if (channelNr != 9)
                        {
                            log("SEND_TO_PIANO: " + pianoCommand);
                            sendToPiano(pianoCommand);
                        }
                        // not found know instrument and note is inteded for ch9*10 it must be drums
                        else
                        {
                            sendToSynth(c);
                        }


                        #region old NOTE DATA
                        //// check if note is intended for piano
                        //if (PianoChannels.Count >= 1 && PianoChannels.Contains(c2))
                        //{
                        //    sendToPiano(pianoCommand);
                        //    // send note to synth if piano synth is enabled
                        //    if (synthPiano)
                        //    {
                        //        sendToSynth(c);
                        //    }
                        //}
                        //// if note is not for piano check if note is karaoke channel 
                        //else if (!(PianoChannels.Count >= 1 && PianoChannels.Contains(c2)))
                        //{
                        //    // if note is selected karaoke channel send to piano else send it to synth
                        //    if (karToPiano && c2 == karChan)
                        //    {
                        //        sendToPiano(pianoCommand);
                        //    }
                        //    else
                        //    {
                        //        sendToSynth(c);
                        //    }
                        //}

                        ////else if ((c2 == "0")&&(remapCh1)&&(RemapedChannel!=null))
                        ////{
                        ////    portOut.sendCommand(StringToByteArray(stbit + RemapedChannel + data));
                        ////    //log("REMAP_DATA: " + stbit + RemapedChannel + data);
                        ////}                   
                        #endregion
                    }
                    // if data is undifined send it to both (synth and piano)
                    else
                    {
                        sendToPiano(byteArrayToString(command));
                        sendToSynth(byteArrayToString(command));
                    }
                    #endregion 
				}

			} 
            catch ( Exception ex ) 
            {
                this.Invoke((MethodInvoker)(() => logWindow.logText = "thread aborting: " + ex.Message));
			}
		}
        public void loadSettings()
        {
            // load saved Piano MIDI output device 
            if (MIDIRouter.Properties.Settings.Default.pMidiDeviceName != "")
            {
                //selectMIDI(MIDIRouter.Properties.Settings.Default.pMidiDeviceName, 0);
                log("LOADING_SAVED_PMIDIOUT: " + MIDIRouter.Properties.Settings.Default.pMidiDeviceName);
                lbPianoOutDevice.Text = MIDIRouter.Properties.Settings.Default.pMidiDeviceName.ToString();
            }
            // load saved Synth MIDI output device
            if (MIDIRouter.Properties.Settings.Default.sMidiDeviceName != "")
            {
                //selectMIDI(MIDIRouter.Properties.Settings.Default.sMidiDeviceName, 1);
                log("LOADING_SAVED_SMIDIOUT: " + MIDIRouter.Properties.Settings.Default.sMidiDeviceName);
                lbEnsambleOutput.Text = MIDIRouter.Properties.Settings.Default.sMidiDeviceName.ToString();

            }

            tbDelayTimeSynth.Value = MIDIRouter.Properties.Settings.Default.delayTimeSynth;
            tbDelayTimePiano.Value = MIDIRouter.Properties.Settings.Default.delayTimePiano;

        }
        public string SendResponse(HttpListenerRequest request) 
        {
            return string.Format("<HTML><BODY>"+ appName + teMidiVerison + vMidiDriverVersion +"<br>{0}</BODY></HTML>", appVersion);
        }

        #endregion 
        logging logWindow = new logging();
       
        public MainWindow()
        {
            
            InitializeComponent();
            logWindow.Hide();
            WebServer ws = new WebServer(SendResponse, "http://localhost:8080/info/");
            ws.Run();
            
            logWindow.logText = appName;
            logWindow.logText = appVersion;
            logWindow.logText = "teVirtualMIDI";
            logWindow.logText = teMidiVerison;
            logWindow.logText = vMidiDriverVersion;

            #region VirtualMIDI init

            TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);

            Guid manufacturer = new Guid("aa4e075f-3504-4aab-9b06-9a4104a91cf0");
            Guid product = new Guid("bb4e075f-3504-4aab-9b06-9a4104a91cf0");

            portIn = new TeVirtualMIDI("DKC-In", 65535, TeVirtualMIDI.TE_VM_FLAGS_INSTANTIATE_RX_ONLY, ref manufacturer, ref product);
            portOut = new TeVirtualMIDI("DKC-Synth-Out", 65535, TeVirtualMIDI.TE_VM_FLAGS_INSTANTIATE_TX_ONLY, ref manufacturer, ref product);
            PianoOut = new TeVirtualMIDI("DKC-Piano1-Out", 65535, TeVirtualMIDI.TE_VM_FLAGS_INSTANTIATE_TX_ONLY, ref manufacturer, ref product);
            Piano2Out = new TeVirtualMIDI("DKC-Piano2-Out", 65535, TeVirtualMIDI.TE_VM_FLAGS_INSTANTIATE_TX_ONLY, ref manufacturer, ref product);
            # endregion
          
            //start background worker thread 
            Thread midiInputThread = new Thread(new ThreadStart(WorkThreadFunction));
            midiInputThread.Start();
            midiInputThread.IsBackground = true;
            TeVirtualMIDI.logging(TeVirtualMIDI.TE_VM_LOGGING_MISC | TeVirtualMIDI.TE_VM_LOGGING_RX | TeVirtualMIDI.TE_VM_LOGGING_TX);
            // close background worker thread if exit is true
            if (exit)
            {
                midiInputThread.Abort();
            }            

        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // Get the local MIDI devices 
            getMidiDevices();

            //load local application settings
            loadSettings();
            log("loading settings ...");
            //Play startup MIDI test
            playStoredMidi();
        }

        #region privatFunctions
        private async void sendToSynth(string c)
        {

            TxSynth.BackColor = System.Drawing.Color.Green;
            await Task.Delay(delayTimeSynth);
            if (vMidiPort)
            {
                portOut.sendCommand(StringToByteArray(c));
            }
            else if (!vMidiPort)
            {
                try
                {
                    var sOutRes = midiOutShortMsg(sHandle, stringToReverseLong(c));
                  
                }
                catch
                {
                    log("ERROR_SENDING_DATA_TO_SYNTH_MIDI: "+c);
                }
            }
            TxPiano.BackColor = System.Drawing.Color.Transparent;
        }
       
        private async void sendToPiano(string c)
        {
            TxPiano.BackColor = System.Drawing.Color.Green;
            await Task.Delay(delayTimePiano);
            if (vMidiPort)
            {
                PianoOut.sendCommand(StringToByteArray(c));
             
                
            }
            else if (!vMidiPort)
            {
                try
                {
                    var pOutRes = midiOutShortMsg(pHandle, stringToReverseLong(c));
                    if (synthPiano)
                    { 
                        var sOutRes = midiOutShortMsg(sHandle, stringToReverseLong(c)); 
                    }
                }
                catch
                {
                    log("ERROR_SENDING_DATA_TO_PIANO_MIDI: "+c);
                }
            }
            TxSynth.BackColor = System.Drawing.Color.Transparent;
        }

        private void LoggingWindow_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            sendToPiano(txMidi);
            sendToSynth(txMidi);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public static string ConvertHex(String hexString)
        {
            hexString = hexString.Substring(10);
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        #region get midi devices    
        private void getMidiDevices()
        {
            int nrDevices = midiOutGetNumDevs();
            int i = 0;
            while (i != nrDevices)
            {
                MidiOutCaps myCaps = new MidiOutCaps();
                var res = midiOutGetDevCaps(i, ref myCaps,
                   (UInt32)Marshal.SizeOf(myCaps));
                log("MIDI Device "+i.ToString()+" : " + myCaps.szPname);
                Mididevices.Add(i+myCaps.szPname);
                this.Invoke((MethodInvoker)(() => lbEnsambleOutput.Items.Add(i+myCaps.szPname)));
                this.Invoke((MethodInvoker)(() => lbPianoOutDevice.Items.Add(i+myCaps.szPname)));
                i++;
            }

            //using Naudio lib
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                lbPianoInDevice.Items.Add(MidiIn.DeviceInfo(device).ProductName);
            }
            if (lbPianoInDevice.Items.Count > 0)
            {
                lbPianoInDevice.SelectedIndex = 0;
            }
        }
        #endregion 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                synthPiano = true;
            }
            else
            {
                synthPiano = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            delayTimeSynth = tbDelayTimeSynth.Value;
            this.lbDelaySynth.Text = tbDelayTimeSynth.Value.ToString();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVirtualMIDI.Checked)
            {
                vMidiPort = true;
                lbPianoOutDevice.Enabled = false;
                lbEnsambleOutput.Enabled = false;
            }
            else 
            {
                vMidiPort = false;
                lbPianoOutDevice.Enabled = true;
                lbEnsambleOutput.Enabled = true;
            }
        }

        private void lbPianoOutDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pHandle != 0)
            {
                if (pHandle != sHandle)
                {
                    log("CLOSING_PIANO_MIDI_DEVICE");
                    var res = midiOutClose(pHandle);
                }
                else
                {
                    log("PIANO_MIDI_DEVICE_STILL_IN_USE!!");
                }
            }
            selectMIDI(lbPianoOutDevice.SelectedItem.ToString(), 0);

        }

        private void lbEnsambleOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sHandle != 0)
            {
                // if midi out is not using by other output then close device
                if (sHandle != pHandle)
                {
                    log("CLOSING_SYNTH_MIDI_DEVICE");
                    var res = midiOutClose(sHandle);
                }
                else
                {
                    log("SYNTH_MIDI_DEVICE_STILL_IN_USE!!");
 
                }
            }
            selectMIDI(lbEnsambleOutput.SelectedItem.ToString(), 1);
        }

        private void selectMIDI(string DeviceName, int OutputType)
        {

            int deviceID = int.Parse(DeviceName.Substring(0, 1));
            if (OutputType == 0)
            {
                if (lbPianoOutDevice.SelectedItem.ToString() == lbEnsambleOutput.Text)
                {
                    pHandle = sHandle;
                }
                else
                {                 
                    pOutRes = deviceID;
                    pHandle = 0;
                    int deviceNumber = deviceID;
                    pOutRes = midiOutOpen(ref pHandle, deviceNumber,
                       null, 0, 0);
                    log("SEL_PIANO_DEV: " + pOutRes + " handle: " + pHandle);
                }
            }
            if (OutputType == 1)
            {
                if (lbEnsambleOutput.SelectedItem.ToString() == lbPianoOutDevice.Text )
                {
                    sHandle = pHandle;
                }
                else
                {          
                    sOutRes = deviceID;
                    sHandle = 0;
                    int deviceNumber = deviceID;
                    sOutRes = midiOutOpen(ref sHandle, deviceNumber,
                       null, 0, 0);
                    log("SEL_SYNTH_DEV: " + sOutRes +" handle: "+ sHandle);
                }
            }
        }

        private void tbDelayTimePiano_Scroll_1(object sender, EventArgs e)
        {
            delayTimePiano = tbDelayTimePiano.Value;
            this.lbDelayPiano.Text = tbDelayTimePiano.Value.ToString();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                karToPiano = true;
            }
            else
            {
                karToPiano = false;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            karChan = textBox1.Text;
           
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }
        private void MainWindow_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            saveSettings();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread midiTestThread = new Thread(new ThreadStart(testMIDI));
            midiTestThread.Start();
            midiTestThread.IsBackground = true;        
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = true;
            saveSettings();

                pOutRes = midiOutClose(pHandle);
                sOutRes = midiOutClose(sHandle);
            
            this.Close();
        }
        private void saveSettings()
        {  
            MIDIRouter.Properties.Settings.Default.pMidiDeviceName = lbPianoOutDevice.SelectedItem.ToString();
            log("SAVING_SELECTED_PMIDIOUT: " + lbPianoOutDevice.SelectedItem.ToString());
            MIDIRouter.Properties.Settings.Default.sMidiDeviceName = lbEnsambleOutput.SelectedItem.ToString();
            log("SAVING_SELECTED_SMIDIOUT: " + lbEnsambleOutput.SelectedItem.ToString());
            MIDIRouter.Properties.Settings.Default.delayTimeSynth = tbDelayTimeSynth.Value;         
            MIDIRouter.Properties.Settings.Default.delayTimePiano = tbDelayTimePiano.Value;
            MIDIRouter.Properties.Settings.Default.Save();
            log("SAVING_SYNTH_DELAY: " + MIDIRouter.Properties.Settings.Default.delayTimeSynth);
            log("SAVING_SYNTH_DELAY: " + MIDIRouter.Properties.Settings.Default.delayTimePiano);
        }

        private void startMidiIn(int devIndex)
        {
            if (midiIn != null)
            {
                midiIn.Close();
                log("Close MIDI input");
            }
            midiIn = new MidiIn(devIndex);
            midiIn.MessageReceived += midiIn_MessageReceived;
           //midiIn.MessageReceived += midiIn_SysexMessageReceived;
            midiIn.ErrorReceived += midiIn_ErrorReceived;
            midiIn.Start();
            log("Open MIDI input: " + MidiIn.DeviceInfo(devIndex).ProductName.ToString());
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            exit = true;
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            testMIDI();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbPianoInDevice_SelectedIndexChanged(object sender, EventArgs e)
        {          
            startMidiIn(lbPianoInDevice.SelectedIndex);
        }

        #endregion

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            sendToPiano(MX80.reset);
            sendToPiano(MX80.testMode);
            sendToPiano(MX80.enableMidiOut);
            sendToPiano(MX80.record);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            log(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            
            log(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        void midiIn_SysexMessageReceived(object sender, MetaEvent e)
        {
            log("SysEx:"+e);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //send reset to piano
            DkcDisplay1.ResetText();         
            DkcDisplay1.AppendText("         Reset Piano");
            sendToPiano(MX80.reset);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendToPiano(MX80.play);
        }

        private void DkcPrev_Click(object sender, EventArgs e)
        {

        }   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loggingToolStripMenuItem.Checked)
            {
                logWindow.Show();
            }
            else
            {
                logWindow.Hide();
            }
            

        }

        public void log(string logmessage)
        {
           // if (log)
            {
                try
                {


                    this.Invoke((MethodInvoker)(() => logWindow.logText = logmessage));
                }
                catch
                {
                }
            }
        }

        private void DkcVolume_Scroll(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
