using System;
using System.IO;

namespace FreeAllegiance.IGCCore.Util
{
	/// <summary>
	/// Reads .NET data types from a stream.
	/// </summary>
	public class DataReader
	{
		private const int BYTELENGTH = 1;
		private const int SHORTLENGTH = 2;
		private const int INTLENGTH = 4;
		private const int LONGLENGTH = 8;

		Stream _stream;

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="stream">The stream of bytes to be read</param>
		public DataReader (Stream stream)
		{
			_stream = stream;
		}

		#region Asserts
		/// <summary>
		/// Reads the next byte from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next byte from the stream</param>
		/// <param name="failmessage">The error message to be thrown if the byte does not equal value</param>
		/// <returns>true or false, depending on whether the read byte is the same as the specified value</returns>
		public bool Assert (byte value, string failmessage)
		{
			Byte b = (byte)_stream.ReadByte();
			if (b != value)
				throw new AssertFailedException(failmessage);

			return true;
		}

		/// <summary>
		/// Reads the next short from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next short from the stream</param>
		/// <param name="failmessage">The error message to be thrown if the short does not equal value</param>
		/// <returns>true or false, depending on whether the read short is the same as the specified value</returns>
		public bool Assert (short value, string failmessage)
		{
			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			if (ByteConversion.ToShort(temp, 0) != value)
				throw new AssertFailedException(failmessage);

			return true;
		}

		/// <summary>
		/// Reads the next int from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next int from the stream</param>
		/// <param name="failmessage">The error message to be thrown if the int does not equal value</param>
		/// <returns>true or false, depending on whether the read byte is the same as the specified value</returns>
		public bool Assert (int value, string failmessage)
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			if (ByteConversion.ToInt(temp, 0) != value)
				throw new AssertFailedException(failmessage);

			return true;
		}

		/// <summary>
		/// Reads the next long from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next long from the stream</param>
		/// <param name="failmessage">The error message to be thrown if the long does not equal value</param>
		/// <returns>true or false, depending on whether the read long is the same as the specified value</returns>
		public bool Assert (long value, string failmessage)
		{
			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);

			if (ByteConversion.ToLong(temp, 0) != value)
				throw new AssertFailedException(failmessage);

			return true;
		}
		#endregion

		public void Skip (int amount)
		{
			_stream.Seek(amount, SeekOrigin.Current);
		}

		public void Seek (int amount)
		{
			_stream.Seek(amount, SeekOrigin.Current);
		}

		/// <summary>
		/// Reads a byte from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next byte from the stream</returns>
		public byte ReadByte ()
		{
			return (byte)_stream.ReadByte();
		}

		/// <summary>
		/// Reads a int from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a int</returns>
		public int ReadInt ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			return ByteConversion.ToInt(temp, 0);
		}

		/// <summary>
		/// Reads a uint from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a uint</returns>
		public uint ReadUInt ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			return ByteConversion.ToUInt(temp, 0);
		}

		/// <summary>
		/// Reads a short from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 2 bytes from the stream cast as a short from</returns>
		public short ReadShort ()
		{
			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			return ByteConversion.ToShort(temp, 0);
		}

		/// <summary>
		/// Reads a ushort from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 2 bytes from the stream cast as a ushort</returns>
		public ushort ReadUShort ()
		{
			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			return ByteConversion.ToUShort(temp, 0);
		}

		/// <summary>
		/// Reads a float from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a float</returns>
		public float ReadFloat ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);
			
			return ByteConversion.ToFloat(temp, 0);
		}

		/// <summary>
		/// Reads a long from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 8 bytes from the stream cast as a long</returns>
		public long ReadLong ()
		{
			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);
			
			return ByteConversion.ToLong(temp, 0);
		}

		/// <summary>
		/// Reads a ulong from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 8 bytes from the stream cast as a ulong</returns>
		public ulong ReadULong ()
		{
			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);
			
			return ByteConversion.ToULong(temp, 0);
		}

		/// <summary>
		/// Reads an array of bytes from the stream, and advances the index accordingly.
		/// </summary>
		/// <param name="length">The number of bytes to retrieve from the stream</param>
		/// <returns>the bytes retrieved from the stream</returns>
		public byte[] ReadBytes (int length)
		{
			byte[] temp = new byte[length];
			_stream.Read(temp, 0, length);
			return temp;
		}

		/// <summary>
		/// Reads a string from the stream, advancing the index accordingly
		/// </summary>
		/// <param name="length">The length of the string to be read</param>
		/// <returns>the string read from the stream</returns>
		public string ReadString (int length)
		{
			byte[] temp = new byte[length];
			_stream.Read(temp, 0, length);
			
			return ByteConversion.GetString(temp);
		}
	}
}
