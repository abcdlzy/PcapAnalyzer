

using Networking.Files;
using Networking.Files.PcapNG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcapAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Btnreadfile_Click(object sender, EventArgs e)
        {
            byte[] read = new byte[9999];
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件|*.*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径        

                PcapNGFileReader packetReader = new PcapNGFileReader(FileToStream(file));
                var packets = packetReader.ReadPackets();

                byte[] readbyte = new byte[134520];
                int iter = 0;
                byte[] payload = { 0x66, 0x6c, 0x61, 0x67 };
                int payloaditer = 0;

                foreach (var item in packets)
                {
                    var data = item.Payload.ToArray();
                    if (data.Length == 113)
                    {
                        if (!(data[104] == 0xff && data[103] == 0xff))
                        {
                            ;
                        }


                    }
                }
                
                
            }
        }

        /*
         * 
         * 
         * 
         * 
         * 
         * 
     
            
        private void Btnreadfile_Click(object sender, EventArgs e)
        {
            byte[] read = new byte[9999];
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件|*.*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径        

                PcapNGFileReader packetReader = new PcapNGFileReader(FileToStream(file));
                var packets = packetReader.ReadPackets();

                byte[] readbyte = new byte[134520];
                int iter = 0;
                string payload = "flag{";
                foreach (var item in packets)
                {
                    var data = item.Payload.ToArray();
                    if (data.Length == 113)
                    {
                        for (int i = 105; i < 113; i++)
                        {
                            if ((data[i] >= 0x30 && data[i] <= 0x39) || (data[i] >= 0x61 && data[i] <= 0x66))
                            {
                                readbyte[iter] = data[i];
                                iter++;

                            }

                        }
                        ;
                    }

                ;
                    //StreamToFile(BytesToStream(System.Text.Encoding.Default.GetBytes(str)), file + "6.txt");
                }
            }
        }


        private void Btnreadfile_Click(object sender, EventArgs e)
        {
            byte[] read = new byte[9999];
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件|*.*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径        

                PcapNGFileReader packetReader = new PcapNGFileReader(FileToStream(file));
                var packets = packetReader.ReadPackets();
                bool isRead = false;
                byte[] readbyte = new byte[65500];
                int iterCount = 100;
                foreach (var item in packets)
                {
                    var data = item.Payload.ToArray();
                    //读取数据
                    if (isRead)
                    {
                        for (int j = 99; j >= 0; j--)
                        {
                            int sub = 99 - j;
                            readbyte[iterCount + j] = (byte)(data[data.Length - sub - 1]);

                        }
                        iterCount += 100;
                        isRead = false;
                    }
                    //处理是否读取保存下一个包
                    if (data.Length > 91 && data.Length < 95 && data[data.Length - 4] == 0x30 && data[data.Length - 3] == 0x30 && data[data.Length - 2] == 0x64 && data[data.Length - 1] == 0x00)
                    {
                        isRead = true;
                    }
                    else
                    {
                        isRead = false;
                    }

                }

                int endloc = 100;
                int count = 1000;
                for (int i = 100; i < 65500; i++)
                {
                    if (readbyte[i] == 0)
                    {
                        endloc = i;
                        count--;
                        if (count == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        count = 1000;
                        endloc = 100;
                    }
                }
                byte[] getval = new byte[endloc - 1100];
                for (int i = 0; i < getval.Length; i++)
                {
                    getval[i] = (byte)(readbyte[i + 100] ^ 0xFF);
                }

                StreamToFile(BytesToStream(getval), file + ".exe");
            }
        }
        */

        /// <summary>
        /// byte[]转换成Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// Stream转换成byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin); // 设置当前流的位置为流的开始
            return bytes;
        }

        /// <summary>
        /// 从文件读取Stream
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stream FileToStream(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read); // 打开文件
            byte[] bytes = new byte[fileStream.Length]; // 读取文件的byte[]
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes); // 把byte[]转换成Stream
            return stream;
        }

        /// <summary>
        /// 将Stream写入文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        public void StreamToFile(Stream stream, string path)
        {
            byte[] bytes = new byte[stream.Length]; // 把Stream转换成byte[]
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin); // 设置当前流的位置为流的开始
            FileStream fs = new FileStream(path, FileMode.Create); // 把byte[]写入文件
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        private void Btntransmute_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] hexValuesSplit = tbinput.Text.Split('|');
            for (int i = 0; i < hexValuesSplit.Length; i++)
            {
                // Convert the number expressed in base-16 to an integer.
                if (hexValuesSplit[i] != "")
                {
                    int value = Convert.ToInt32(hexValuesSplit[i], 16);
                    // Get the character corresponding to the integral value.
                    string stringValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    sb.Append(stringValue);
                }
                
            }
            tboutput.Text = sb.ToString();
        }
    }
}
