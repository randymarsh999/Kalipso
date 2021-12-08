using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalipso.Сalculations
{
    /// <summary>
    /// class for calculation of crc sum
    /// </summary>
    public class CRC
    {
        /// <summary>
        /// Расчет контрольной суммы
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>Modbus CRC16 array</returns>
        public static byte[] ModbusCRC16Calc(byte[] Message)
        {
            //выдаваемый массив CRC
            byte[] CRC = new byte[2];
            ushort Register = 0xFFFF; // создаем регистр, в котором будем сохранять высчитанный CRC
            ushort Polynom = 0xA001; //Указываем полином, он может быть как 0xA001(старший бит справа), так и его реверс 0x8005(старший бит слева, здесь не рассматривается), при сдвиге вправо используется 0xA001

            for (int i = 0; i < Message.Length; i++) // для каждого байта в принятом\отправляемом сообщении проводим следующие операции(байты сообщения без принятого CRC)
            {
                Register = (ushort)(Register ^ Message[i]); // Делим через XOR регистр на выбранный байт сообщения(от младшего к старшему)

                for (int j = 0; j < 8; j++) // для каждого бита в выбранном байте делим полученный регистр на полином
                {
                    if ((ushort)(Register & 0x01) == 1) //если старший бит равен 1 то
                    {
                        Register = (ushort)(Register >> 1); //сдвигаем на один бит вправо
                        Register = (ushort)(Register ^ Polynom); //делим регистр на полином по XOR
                    }
                    else //если старший бит равен 0 то
                    {
                        Register = (ushort)(Register >> 1); // сдвигаем регистр вправо
                    }
                }
            }

            CRC[1] = (byte)(Register >> 8); // присваеваем старший байт полученного регистра младшему байту результата CRC (CRClow)
            CRC[0] = (byte)(Register & 0x00FF); // присваеваем младший байт полученного регистра старшему байту результата CRC (CRCHi) это условность Modbus — обмен байтов местами.
            return CRC;
        }







        //-----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        uint[] table;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public uint ComputeChecksum(byte[] bytes)
        {
            uint crc = 0xffffffff;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(((crc) & 0xff) ^ bytes[i]);
                crc = (uint)((crc >> 8) ^ table[index]);
            }
            return ~crc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }
        /// <summary>
        /// 
        /// </summary>
        public void Crc32()
        {
            uint poly = 0xedb88320;
            table = new uint[256];
            uint temp = 0;
            for (uint i = 0; i < table.Length; ++i)
            {
                temp = i;
                for (int j = 8; j > 0; --j)
                {
                    if ((temp & 1) == 1)
                    {
                        temp = (uint)((temp >> 1) ^ poly);
                    }
                    else
                    {
                        temp >>= 1;
                    }
                }
                table[i] = temp;
            }
        }
    }
}



/// <summary>
/// 
/// </summary>
public class Crc16
{
    const ushort polynomial = 0xA001;
    ushort[] table = new ushort[256];
    /// <summary>
    /// Computes the checksum.
    /// </summary>
    /// <param name="bytes">The bytes.</param>
    /// <returns></returns>
    public ushort ComputeChecksum(byte[] bytes)
    {
        ushort crc = 0;
        for (int i = 0; i < bytes.Length; ++i)
        {
            byte index = (byte)(crc ^ bytes[i]);
            crc = (ushort)((crc >> 8) ^ table[index]);
        }
        return crc;
    }
    /// <summary>
    /// Computes the checksum bytes.
    /// </summary>
    /// <param name="bytes">The bytes.</param>
    /// <returns></returns>
    public byte[] ComputeChecksumBytes(byte[] bytes)
    {
        ushort crc = ComputeChecksum(bytes);
        return BitConverter.GetBytes(crc);
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Crc16"/> class.
    /// </summary>
    public Crc16()
    {
        ushort value;
        ushort temp;
        for (ushort i = 0; i < table.Length; ++i)
        {
            value = 0;
            temp = i;
            for (byte j = 0; j < 8; ++j)
            {
                if (((value ^ temp) & 0x0001) != 0)
                {
                    value = (ushort)((value >> 1) ^ polynomial);
                }
                else
                {
                    value >>= 1;
                }
                temp >>= 1;
            }
            table[i] = value;
        }
    }
}
