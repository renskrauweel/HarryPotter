using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Cryptographer class. Used for hashing strings
/// </summary>
public class Cryptographer
{
    /// <summary>
    /// Return hash
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns>byte[] hash</returns>
    public static byte[] GetHash(string inputString)
    {
        HashAlgorithm algorithm = MD5.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    /// <summary>
    /// Return hash string
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns>string hash string</returns>
    public static string GetHashString(string inputString)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
}