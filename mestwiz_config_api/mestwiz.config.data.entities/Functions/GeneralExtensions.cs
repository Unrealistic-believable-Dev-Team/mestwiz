using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace mestwiz.config.data.entities.Functions
{

    public static class GeneralExtensions
    {
        private static readonly string Key = "R3._9028jKAl$&lX";

        public static async Task<T> ToObject<T>(this string cadena) where T : class
        {
            MemoryStream stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(cadena));
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public static async Task<bool> IsNullString(this string cadena)
        {
            return await Task.FromResult(string.IsNullOrEmpty(cadena) || string.IsNullOrWhiteSpace(cadena));
        }

        public async static Task<string> GetNewId(this object any)
        {
            string uuid = Guid.NewGuid().ToString("N");
            uuid += DateTime.Now.ToLongDateString();
            uuid = Convert.ToBase64String(Encoding.UTF8.GetBytes(uuid));
            return await Task.FromResult(uuid);
        }

        public async static Task<string> MD5Encrypt(this string cadena)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return await GetMd5HashWithMySecurityAlgo(md5Hash, cadena);                          
            }
        }

        static async Task<string> GetMd5HashWithMySecurityAlgo(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return await Task.FromResult(sBuilder.ToString());
        }


        public async static Task<string> SimpleEncrypt(this string cadena)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(cadena);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return await Task.FromResult(Convert.ToBase64String(array));
        }

        public async static Task<string> SimpleDecrypt(this string cadena)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cadena);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return await Task.FromResult(streamReader.ReadToEnd());
                        }
                    }
                }
            }

        }


        public static async Task<string> ToJsonString(this object data)
        {
            string json = string.Empty;
            using (var stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, data, data.GetType());
                stream.Position = 0;
                using var reader = new StreamReader(stream);
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<bool> IsValidEmail(this string email)
        {
            if (await email.IsNullString())
                throw new Exception("Email no válido");

            try
            {

                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return await Task.FromResult(false);
            }
            catch (ArgumentException e)
            {
                return await Task.FromResult(false);
            }
            catch(Exception e)
            {
                return await Task.FromResult(false);
            }

            try
            {
                if (!Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    throw new Exception("Email no válido");
            }
            catch (RegexMatchTimeoutException e)
            {
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

    }
}
