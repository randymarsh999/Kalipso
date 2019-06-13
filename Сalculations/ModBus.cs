using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TModBus
{
    List<byte> buff;
    public const ushort myPolinom = 0xA001;

    public TModBus()
    {
        buff = new List<byte>();
    }

    public byte[] getFirmCommand(byte com, byte[] data, byte adr)
    {
        ushort crcMdb;
        buff.Clear();
        buff.Add(adr);
        buff.Add(0x42);
        buff.Add(com);
        if (data != null)
            for (int i = 0; i < data.Length; i++)
                buff.Add(data[i]);
        crcMdb = getCrc(buff.ToArray());
        buff.Add((byte)(crcMdb & 0xFF));
        buff.Add((byte)((crcMdb >> 8) & 0xFF));
        return buff.ToArray();
    }

    ushort getCrc(byte[] mdbBuf)
    {
        ushort crc;
        byte tmpB;
        crc = 0xFFFF;
        for (int i = 0; i < mdbBuf.Length; i++)
        {
            tmpB = mdbBuf[i];
            for (int j = 0; j < 8; j++)
            {
                crc = (ushort)(crc ^ (tmpB & 1));
                if ((crc & 1) != 0)
                    crc = (ushort)((crc >> 1) ^ myPolinom);
                else
                    crc = (ushort)(crc >> 1);
                tmpB = (byte)(tmpB >> 1);
            }
        }
        return crc;
    }

}

