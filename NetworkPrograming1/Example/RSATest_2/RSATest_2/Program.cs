﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Alice
{
    public static void Main(string[] args)
    {
        byte[] encryptedSessionKey = null;
        byte[] encryptedMessage = null;
        byte[] iv = null;
        byte[] nonce = null;
        Bob bob = new Bob();
        {
            using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider())
            {
                // Get Bob's public key
                rsaKey.ImportCspBlob(bob.key);
                nonce = bob.key;
                Send(rsaKey, "Secret message", out iv, out encryptedSessionKey, out encryptedMessage);

            }
        }
                bob.Receive(nonce, iv, encryptedSessionKey, encryptedMessage);
    }

    private static void Send(RSA key, string secretMessage, out byte[] iv, out byte[] encryptedSessionKey, out byte[] encryptedMessage)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            iv = aes.IV; // Khởi tạo Vector đối xứng

            // Encrypt the session key
            // Tạo dữ liệu trao đổi khoá mã hoá không đối xứng RSA
            RSAOAEPKeyExchangeFormatter keyFormatter = new RSAOAEPKeyExchangeFormatter(key);
            // Tạo key trao đổi dữ liệu được gửi đến người nhận
            encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, typeof(Aes));

            // Encrypt the message
            using (MemoryStream ciphertext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                cs.Close();

                encryptedMessage = ciphertext.ToArray();
            }
        }
    }
}
public class Bob : IDisposable
{
    public byte[] key;
    private RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    public Bob()
    {
        key = rsaKey.ExportCspBlob(false); 
    }
    public void Receive(byte[] nonce, byte[] iv, byte[] encryptedSessionKey, byte[] encryptedMessage)
    {
        nonce = rsaKey.ExportCspBlob(false);
        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.IV = iv;

            // Decrypt the session key
            RSAOAEPKeyExchangeDeformatter keyDeformatter = new RSAOAEPKeyExchangeDeformatter(rsaKey);
            aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey);

            // Decrypt the message
            using (MemoryStream plaintext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                cs.Close();

                string message = Encoding.UTF8.GetString(plaintext.ToArray());
                Console.WriteLine(message);
            }
        }
    }
    public void Dispose()
    {
        rsaKey.Dispose();
    }
}

