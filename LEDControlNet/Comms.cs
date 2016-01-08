using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace LEDControlNet
{
    class Comms : IDisposable
    {
        bool disposed;
        // Interface for the Serial Port at which an Arduino Board is connected.
        SerialPort arduinoBoard = new SerialPort();


        public void OpenArduinoConnection()
        {
            if (!arduinoBoard.IsOpen)
            {
                arduinoBoard.DataReceived += arduinoBoard_DataReceived;
                arduinoBoard.PortName = "COM4";
                arduinoBoard.BaudRate = 9600;
                arduinoBoard.Open();
            }
            else
            {
                throw new InvalidOperationException("The Serial Port is already open!");
            }
            arduinoBoard.Write("STATUS#");
            arduinoBoard.Write("VALUE#");
        }

        public void WriteArdunioData(string data)
        {
            if (arduinoBoard.IsOpen)
            {
               // arduinoBoard.Write("1#");
                Console.WriteLine("Sending :" + data);
                arduinoBoard.Write(data+"#");
            }
            else
            {
                throw new InvalidOperationException("Can not write to Serial Port");
            }
        }
        void arduinoBoard_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = arduinoBoard.ReadTo("\x03");//Read until the EOT code
            Console.WriteLine("Recieved: " + data);

        }

        public string ScanPorts()
        {
            SerialPort currentPort;
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    currentPort = new SerialPort(port, 9600);
                    Console.WriteLine(currentPort.PortName);
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Closing");
                    arduinoBoard.Close();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
      /*  private bool DetectArduino(SerialPort currentPort)
        {
            try
            {
                //The below setting are for the Hello handshake
                byte[] buffer = new byte[5];
                buffer[0] = Convert.ToByte(16);
                buffer[1] = Convert.ToByte(128);
                buffer[2] = Convert.ToByte(0);
                buffer[3] = Convert.ToByte(0);
                buffer[4] = Convert.ToByte(4);
                int intReturnASCII = 0;
                char charReturnValue = (Char)intReturnASCII;
                currentPort.Open();
                currentPort.Write(buffer, 0, 5);
                Thread.Sleep(1000);
                int count = currentPort.BytesToRead;
                string returnMessage = "";
                while (count > 0)
                {
                    intReturnASCII = currentPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }
                ComPort.name = returnMessage;
                currentPort.Close();
                if (returnMessage.Contains("HELLO FROM ARDUINO"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }*/
    }
       
}
