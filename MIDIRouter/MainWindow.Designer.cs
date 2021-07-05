namespace MIDIRouter
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbPianoOutDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbEnsambleOutput = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbTxMIDI = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.DkcDisplay2 = new System.Windows.Forms.RichTextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.DckReset = new System.Windows.Forms.Button();
            this.DkcRecord = new System.Windows.Forms.Button();
            this.DkcVolume = new System.Windows.Forms.TrackBar();
            this.DkcNext = new System.Windows.Forms.Button();
            this.DkcPrev = new System.Windows.Forms.Button();
            this.DkcStop = new System.Windows.Forms.Button();
            this.DkcDisplay1 = new System.Windows.Forms.RichTextBox();
            this.DckPlayPause = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxPiano = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.TxSynth = new System.Windows.Forms.Panel();
            this.RxIn = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbDelaySynth = new System.Windows.Forms.Label();
            this.tbDelayTimeSynth = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbDelayPiano = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDelayTimePiano = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbPianoInDevice = new System.Windows.Forms.ComboBox();
            this.cbVirtualMIDI = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DkcVolume)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTimeSynth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTimePiano)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Synth delay ";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 51);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 24);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Enable synth Piano";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbPianoOutDevice
            // 
            this.lbPianoOutDevice.FormattingEnabled = true;
            this.lbPianoOutDevice.Location = new System.Drawing.Point(63, 102);
            this.lbPianoOutDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbPianoOutDevice.Name = "lbPianoOutDevice";
            this.lbPianoOutDevice.Size = new System.Drawing.Size(223, 28);
            this.lbPianoOutDevice.TabIndex = 22;
            this.lbPianoOutDevice.SelectedIndexChanged += new System.EventHandler(this.lbPianoOutDevice_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Disklavier port";
            // 
            // lbEnsambleOutput
            // 
            this.lbEnsambleOutput.FormattingEnabled = true;
            this.lbEnsambleOutput.Location = new System.Drawing.Point(66, 218);
            this.lbEnsambleOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbEnsambleOutput.Name = "lbEnsambleOutput";
            this.lbEnsambleOutput.Size = new System.Drawing.Size(223, 28);
            this.lbEnsambleOutput.TabIndex = 24;
            this.lbEnsambleOutput.SelectedIndexChanged += new System.EventHandler(this.lbEnsambleOutput_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Synth port";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(18, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1470, 540);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Location = new System.Drawing.Point(674, 374);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(774, 152);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Debug";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.tbTxMIDI);
            this.groupBox5.Location = new System.Drawing.Point(27, 29);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(723, 80);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Console";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbTxMIDI
            // 
            this.tbTxMIDI.Location = new System.Drawing.Point(20, 31);
            this.tbTxMIDI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTxMIDI.Name = "tbTxMIDI";
            this.tbTxMIDI.Size = new System.Drawing.Size(608, 26);
            this.tbTxMIDI.TabIndex = 1;
            this.tbTxMIDI.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.DkcDisplay2);
            this.groupBox9.Controls.Add(this.checkBox3);
            this.groupBox9.Controls.Add(this.DckReset);
            this.groupBox9.Controls.Add(this.DkcRecord);
            this.groupBox9.Controls.Add(this.DkcVolume);
            this.groupBox9.Controls.Add(this.DkcNext);
            this.groupBox9.Controls.Add(this.DkcPrev);
            this.groupBox9.Controls.Add(this.DkcStop);
            this.groupBox9.Controls.Add(this.DkcDisplay1);
            this.groupBox9.Controls.Add(this.DckPlayPause);
            this.groupBox9.Location = new System.Drawing.Point(674, 29);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Size = new System.Drawing.Size(774, 323);
            this.groupBox9.TabIndex = 29;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Disklavier Control";
            this.groupBox9.Enter += new System.EventHandler(this.groupBox9_Enter);
            // 
            // DkcDisplay2
            // 
            this.DkcDisplay2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DkcDisplay2.BackColor = System.Drawing.Color.LightGreen;
            this.DkcDisplay2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DkcDisplay2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DkcDisplay2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DkcDisplay2.Location = new System.Drawing.Point(10, 83);
            this.DkcDisplay2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcDisplay2.Name = "DkcDisplay2";
            this.DkcDisplay2.ReadOnly = true;
            this.DkcDisplay2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.DkcDisplay2.Size = new System.Drawing.Size(460, 37);
            this.DkcDisplay2.TabIndex = 35;
            this.DkcDisplay2.Text = "";
            this.DkcDisplay2.WordWrap = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(10, 222);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(166, 24);
            this.checkBox3.TabIndex = 28;
            this.checkBox3.Text = "Second Disklavier";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // DckReset
            // 
            this.DckReset.Location = new System.Drawing.Point(682, 129);
            this.DckReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DckReset.Name = "DckReset";
            this.DckReset.Size = new System.Drawing.Size(68, 35);
            this.DckReset.TabIndex = 34;
            this.DckReset.Text = "Reset";
            this.DckReset.UseVisualStyleBackColor = true;
            this.DckReset.Click += new System.EventHandler(this.button9_Click);
            // 
            // DkcRecord
            // 
            this.DkcRecord.Location = new System.Drawing.Point(496, 131);
            this.DkcRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcRecord.Name = "DkcRecord";
            this.DkcRecord.Size = new System.Drawing.Size(112, 35);
            this.DkcRecord.TabIndex = 33;
            this.DkcRecord.Text = "Record";
            this.DkcRecord.UseVisualStyleBackColor = true;
            this.DkcRecord.Click += new System.EventHandler(this.button8_Click);
            // 
            // DkcVolume
            // 
            this.DkcVolume.LargeChange = 10;
            this.DkcVolume.Location = new System.Drawing.Point(501, 51);
            this.DkcVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcVolume.Maximum = 1000;
            this.DkcVolume.Name = "DkcVolume";
            this.DkcVolume.Size = new System.Drawing.Size(249, 56);
            this.DkcVolume.SmallChange = 2;
            this.DkcVolume.TabIndex = 32;
            this.DkcVolume.Tag = "";
            this.DkcVolume.TickFrequency = 100;
            this.DkcVolume.Scroll += new System.EventHandler(this.DkcVolume_Scroll);
            // 
            // DkcNext
            // 
            this.DkcNext.Location = new System.Drawing.Point(375, 131);
            this.DkcNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcNext.Name = "DkcNext";
            this.DkcNext.Size = new System.Drawing.Size(112, 35);
            this.DkcNext.TabIndex = 4;
            this.DkcNext.Text = "Next";
            this.DkcNext.UseVisualStyleBackColor = true;
            // 
            // DkcPrev
            // 
            this.DkcPrev.Location = new System.Drawing.Point(254, 131);
            this.DkcPrev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcPrev.Name = "DkcPrev";
            this.DkcPrev.Size = new System.Drawing.Size(112, 35);
            this.DkcPrev.TabIndex = 3;
            this.DkcPrev.Text = "Prev";
            this.DkcPrev.UseVisualStyleBackColor = true;
            this.DkcPrev.Click += new System.EventHandler(this.DkcPrev_Click);
            // 
            // DkcStop
            // 
            this.DkcStop.Location = new System.Drawing.Point(132, 131);
            this.DkcStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcStop.Name = "DkcStop";
            this.DkcStop.Size = new System.Drawing.Size(112, 35);
            this.DkcStop.TabIndex = 2;
            this.DkcStop.Text = "Stop";
            this.DkcStop.UseVisualStyleBackColor = true;
            // 
            // DkcDisplay1
            // 
            this.DkcDisplay1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DkcDisplay1.BackColor = System.Drawing.Color.LightGreen;
            this.DkcDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DkcDisplay1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DkcDisplay1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DkcDisplay1.Location = new System.Drawing.Point(10, 51);
            this.DkcDisplay1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DkcDisplay1.Name = "DkcDisplay1";
            this.DkcDisplay1.ReadOnly = true;
            this.DkcDisplay1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.DkcDisplay1.Size = new System.Drawing.Size(460, 37);
            this.DkcDisplay1.TabIndex = 2;
            this.DkcDisplay1.Text = "";
            this.DkcDisplay1.WordWrap = false;
            this.DkcDisplay1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // DckPlayPause
            // 
            this.DckPlayPause.Location = new System.Drawing.Point(10, 131);
            this.DckPlayPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DckPlayPause.Name = "DckPlayPause";
            this.DckPlayPause.Size = new System.Drawing.Size(112, 35);
            this.DckPlayPause.TabIndex = 0;
            this.DckPlayPause.Text = "Play/Pause";
            this.DckPlayPause.UseVisualStyleBackColor = true;
            this.DckPlayPause.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button3);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.button2);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.TxPiano);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.TxSynth);
            this.groupBox8.Controls.Add(this.RxIn);
            this.groupBox8.Location = new System.Drawing.Point(344, 362);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Size = new System.Drawing.Size(300, 168);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "MIDI Test";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(144, 29);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 35);
            this.button3.TabIndex = 28;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "Rx MIDI";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 31);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 35);
            this.button2.TabIndex = 27;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Tx Synth";
            // 
            // TxPiano
            // 
            this.TxPiano.Location = new System.Drawing.Point(21, 80);
            this.TxPiano.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxPiano.Name = "TxPiano";
            this.TxPiano.Size = new System.Drawing.Size(75, 20);
            this.TxPiano.TabIndex = 27;
            this.TxPiano.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tx Piano";
            // 
            // TxSynth
            // 
            this.TxSynth.Location = new System.Drawing.Point(105, 80);
            this.TxSynth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxSynth.Name = "TxSynth";
            this.TxSynth.Size = new System.Drawing.Size(75, 20);
            this.TxSynth.TabIndex = 28;
            // 
            // RxIn
            // 
            this.RxIn.Location = new System.Drawing.Point(189, 80);
            this.RxIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RxIn.Name = "RxIn";
            this.RxIn.Size = new System.Drawing.Size(75, 20);
            this.RxIn.TabIndex = 29;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lbDelaySynth);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbDelayTimeSynth);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(27, 306);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(308, 220);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Synthesizer Settings";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 175);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "ms";
            // 
            // lbDelaySynth
            // 
            this.lbDelaySynth.AutoSize = true;
            this.lbDelaySynth.Location = new System.Drawing.Point(128, 172);
            this.lbDelaySynth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDelaySynth.Name = "lbDelaySynth";
            this.lbDelaySynth.Size = new System.Drawing.Size(0, 20);
            this.lbDelaySynth.TabIndex = 27;
            // 
            // tbDelayTimeSynth
            // 
            this.tbDelayTimeSynth.LargeChange = 10;
            this.tbDelayTimeSynth.Location = new System.Drawing.Point(32, 126);
            this.tbDelayTimeSynth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDelayTimeSynth.Maximum = 1000;
            this.tbDelayTimeSynth.Name = "tbDelayTimeSynth";
            this.tbDelayTimeSynth.Size = new System.Drawing.Size(249, 56);
            this.tbDelayTimeSynth.SmallChange = 2;
            this.tbDelayTimeSynth.TabIndex = 26;
            this.tbDelayTimeSynth.TickFrequency = 100;
            this.tbDelayTimeSynth.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.lbDelayPiano);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbDelayTimePiano);
            this.groupBox3.Location = new System.Drawing.Point(27, 29);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(308, 268);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Disklavier Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "ms";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 89);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // lbDelayPiano
            // 
            this.lbDelayPiano.AutoSize = true;
            this.lbDelayPiano.Location = new System.Drawing.Point(126, 222);
            this.lbDelayPiano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDelayPiano.Name = "lbDelayPiano";
            this.lbDelayPiano.Size = new System.Drawing.Size(0, 20);
            this.lbDelayPiano.TabIndex = 29;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(30, 54);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(158, 24);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "Karaoke to Piano";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Piano delay ";
            // 
            // tbDelayTimePiano
            // 
            this.tbDelayTimePiano.LargeChange = 10;
            this.tbDelayTimePiano.Location = new System.Drawing.Point(30, 168);
            this.tbDelayTimePiano.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDelayTimePiano.Maximum = 1000;
            this.tbDelayTimePiano.Name = "tbDelayTimePiano";
            this.tbDelayTimePiano.Size = new System.Drawing.Size(249, 56);
            this.tbDelayTimePiano.SmallChange = 2;
            this.tbDelayTimePiano.TabIndex = 28;
            this.tbDelayTimePiano.TickFrequency = 100;
            this.tbDelayTimePiano.Scroll += new System.EventHandler(this.tbDelayTimePiano_Scroll_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbPianoInDevice);
            this.groupBox2.Controls.Add(this.cbVirtualMIDI);
            this.groupBox2.Controls.Add(this.lbEnsambleOutput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbPianoOutDevice);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(344, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(300, 323);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MIDI Devices";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 226);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Out";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 105);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Out";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "In";
            // 
            // lbPianoInDevice
            // 
            this.lbPianoInDevice.FormattingEnabled = true;
            this.lbPianoInDevice.Location = new System.Drawing.Point(63, 60);
            this.lbPianoInDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbPianoInDevice.Name = "lbPianoInDevice";
            this.lbPianoInDevice.Size = new System.Drawing.Size(223, 28);
            this.lbPianoInDevice.TabIndex = 27;
            this.lbPianoInDevice.SelectedIndexChanged += new System.EventHandler(this.lbPianoInDevice_SelectedIndexChanged);
            // 
            // cbVirtualMIDI
            // 
            this.cbVirtualMIDI.AutoSize = true;
            this.cbVirtualMIDI.Location = new System.Drawing.Point(28, 274);
            this.cbVirtualMIDI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVirtualMIDI.Name = "cbVirtualMIDI";
            this.cbVirtualMIDI.Size = new System.Drawing.Size(162, 24);
            this.cbVirtualMIDI.TabIndex = 26;
            this.cbVirtualMIDI.Text = "Virtual MIDI ports";
            this.cbVirtualMIDI.UseVisualStyleBackColor = true;
            this.cbVirtualMIDI.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1506, 30);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.loggingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.CheckOnClick = true;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.loggingToolStripMenuItem.Text = "Logging";
            this.loggingToolStripMenuItem.Click += new System.EventHandler(this.loggingToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(63, 143);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 28);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 151);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Out2";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "Disklavier Companion";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DkcVolume)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTimeSynth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDelayTimePiano)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox lbPianoOutDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lbEnsambleOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbVirtualMIDI;
        private System.Windows.Forms.TrackBar tbDelayTimeSynth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbDelayTimePiano;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label lbDelaySynth;
        private System.Windows.Forms.Label lbDelayPiano;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel TxPiano;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel RxIn;
        private System.Windows.Forms.Panel TxSynth;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ComboBox lbPianoInDevice;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button DckPlayPause;
        private System.Windows.Forms.Button DkcRecord;
        private System.Windows.Forms.Button DkcNext;
        private System.Windows.Forms.Button DkcPrev;
        private System.Windows.Forms.Button DkcStop;
        private System.Windows.Forms.Button DckReset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TrackBar DkcVolume;
        public System.Windows.Forms.RichTextBox DkcDisplay1;
        public System.Windows.Forms.RichTextBox DkcDisplay2;
        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTxMIDI;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

