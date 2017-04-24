using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace UWPRLeaveManagement.Models
{
    public class RandomNumGen
    {
        public string GenerateRandomData()
        {
            // Define the length, in bytes, of the buffer.
            uint length = 32;

            // Generate random data and copy it to a buffer.
            IBuffer buffer = CryptographicBuffer.GenerateRandom(length);

            // Encode the buffer to a hexadecimal string (for display).
            string randomHex = CryptographicBuffer.EncodeToHexString(buffer);

            return randomHex;
        }

        public static uint GenerateRandomNumber()
        {
            // Generate a random number.
            uint random = CryptographicBuffer.GenerateRandomNumber();
            return random;
        }
    }
}
