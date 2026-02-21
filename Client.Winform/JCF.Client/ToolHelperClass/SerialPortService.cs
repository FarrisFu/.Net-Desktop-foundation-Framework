using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolHelperClass
{
    public class SerialPortService
    {
        private SerialPort _serialPort;
        private System.Timers.Timer _timeoutTimer;
        public List<string> ErrorMessage = new List<string>();
        private List<byte> _buffer = new List<byte>();
        private const byte FRAME_HEAD = 0xF8;
        private const byte FRAME_TAIL = 0xF9;
        public Stack<byte[]> reveiveFrame = new Stack<byte[]>();
        public SerialPortService(string PortName = "COM1", int baundrate = 9600, Parity parity = Parity.None, int dataBit = 8, StopBits stopBits = StopBits.None)
        {
            _serialPort = new SerialPort
            {
                PortName = PortName,
                BaudRate = baundrate,
                Parity = parity,
                DataBits = dataBit,
                StopBits = stopBits
            };
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Encoding = Encoding.ASCII;

            // 初始化超时定时器（比如 200ms）
            _timeoutTimer = new System.Timers.Timer(200);
            _timeoutTimer.Elapsed += TimeoutTimer_Elapsed;
            _timeoutTimer.AutoReset = false; // 只触发一次
        }

        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                if (bytesToRead > 0)
                {
                    byte[] received = new byte[bytesToRead];
                    _serialPort.Read(received, 0, bytesToRead);

                    lock (_buffer)
                    {
                        _buffer.AddRange(received);
                        _timeoutTimer.Stop();// 新数据到达，重置超时
                        _timeoutTimer.Start();  // 重新计时
                    }

                    ParseBufer();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Add($"Error SerialPort_DataReceived =>{ex.Message}");
            }
        }

        private void ParseBufer()
        {
            lock (_buffer)
            {
                while (true)
                {
                    int start = _buffer.IndexOf(FRAME_HEAD);
                    if (start == -1)
                    {
                        _buffer.Clear();// 没有头标志，清空
                        return;
                    }

                    int end = _buffer.IndexOf(FRAME_TAIL, start + 1);
                    if (end == -1)
                    {
                        // 没找到尾部，说明帧还不完整
                        if (start > 0)
                            _buffer.RemoveRange(0, start);// 去掉无效数据
                        return;
                    }

                    int length = end - start + 1;
                    byte[] frame = _buffer.Skip(start).Take(length).ToArray();

                    // 处理数据帧
                    reveiveFrame.Push(frame);

                    // 移除已处理部分
                    _buffer.RemoveRange(0, end + 1);
                }
            }
        }

        private void TimeoutTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_buffer)
            {
                _buffer.Clear();
            }
        }

        public bool Open()
        {
            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();

                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage.Add($"Error opening port: {ex.Message}");
                return false;
            }
        }
        public bool Close()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage.Add($"Error closing port: {ex.Message}");
                return false;
            }
        }
    }
}
