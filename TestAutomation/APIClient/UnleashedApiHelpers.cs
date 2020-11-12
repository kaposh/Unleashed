using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace APIClient
{
	class UnleashedApiHelpers
	{
        public static string ApiHost { get => "https://api.unleashedsoftware.com"; }
        /// <summary>
        /// Get headers required for authentication
        /// </summary>
        /// <param name="requestUri">Request uri</param>
        /// <returns>Dictionary of headers</returns>
        public static Dictionary<string, string> GetAuthenticationHeaders(Uri requestUri)
        {
            var arguments = GetArgumentsString(requestUri);
            return new Dictionary<string, string>(){
                { "api-auth-id", ApiId },
                { "api-auth-signature", GetSignature(arguments, ApiKey) },
                { "Accept", "application/json"},
                { "Content-Type", "application/json; charset=Windows-1252" }
            };
        }

        // These values should be ideally taken from environmental variables
        private static string ApiId { get => "7a800e1d-77b6-4d05-b1f8-378b4f09eee1"; }
        private static string ApiKey { get => "htiApNudeXbpuYlZHkFfANFaMJagbYk2qSpVJ032G4Bu74TlsmyFZeMzmw9Rbt5NsPVbrvXdGdvIEDF1tPhWw=="; }
        /// <summary>
        /// Get arguments substring from full request uri
        /// </summary>
        /// <param name="requestUri">Request uri</param>
        /// <returns>Substring containing only arguments part of uri</returns>
        private static string GetArgumentsString(Uri requestUri)
        {
            var requestUriParts = requestUri.ToString().Split('?');
            return requestUriParts.Length > 1 ? requestUriParts[requestUriParts.Length - 1] : "";
        }

        /// <summary>
        /// Get encoded signature 
        /// </summary>
        /// <param name="args">Arguments substring of request uri</param>
        /// <param name="privateKey">Private key</param>
        /// <returns></returns>
        private static string GetSignature(string args, string privateKey)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] key = encoding.GetBytes(privateKey);
            var myhmacsha256 = new HMACSHA256(key);
            byte[] hashValue = myhmacsha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myhmacsha256.Clear();
            return hmac64;
        }
    }
}
