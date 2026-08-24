using System.Security.Cryptography;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Helpers;

public class SimpleRandom
{
    private static readonly object _lockObject = new object();
    private static long _counter = DateTime.UtcNow.Ticks;

    public static int Next(int maxValue)
    {
        lock (_lockObject)
        {
            string entropy = $"{_counter++}|{DateTime.UtcNow.Ticks}|{Guid.NewGuid()}";

            byte[] hash = GenerateHash(entropy);

            uint randomNumber = BitConverter.ToUInt32(hash, 0);

            return (int)(randomNumber % (uint)maxValue);
        }
    }

    private static byte[] GenerateHash(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        return sha256.ComputeHash(inputBytes);
    }
}