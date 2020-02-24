using UnityEngine;

using System.Net;
using System.IO;
using System.Text;
using Assets.Scripts.Config;

public class NetworkUtility : MonoBehaviour
{
    static string MAIN_URL = Config.MAIN_URL;
    static int timeout = 5;

    public string HTTP_GET(string URL_PATH)
    {
        System.Uri url = new System.Uri(MAIN_URL + URL_PATH);
        try
        {
            string response = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = timeout * 1000;
            //request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법

            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            HttpStatusCode status = res.StatusCode;

            Stream resStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(resStream);
            response = streamReader.ReadToEnd();

            streamReader.Close();
            resStream.Close();
            res.Close();

            return response;
        }
        catch (System.Exception e)
        {
           return e.ToString();
        }
    }

    public string HTTP_POST(string str, string URL_PATH)
    {
        System.Uri url = new System.Uri(MAIN_URL + URL_PATH);
        try
        {
            string response = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = timeout * 1000;

            request.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(str); // 인코딩 설정
            request.ContentLength = data.Length;

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();

            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            Stream resStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(resStream, Encoding.UTF8);
            response = streamReader.ReadToEnd();

            streamReader.Close();
            resStream.Close();
            res.Close();

            return response;
        }
        catch (System.Exception e)
        {
            return e.ToString();
        }
    }

    public void HTTP_FILE(string URL_PATH)
    {
        System.Uri url = new System.Uri(MAIN_URL + URL_PATH);
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Get;
            WebResponse res = request.GetResponse();

            var buffer = new byte[1024];
            int pos = 0;
            int count;

            Stream stream = res.GetResponseStream();
            var fs = new FileStream("f.png", FileMode.Create);

            do
            {
                count = stream.Read(buffer, pos, buffer.Length);
                fs.Write(buffer, 0, count);
            } while (count > 0);

            fs.Close();
            stream.Close();
        }
        catch (System.Exception e)
        {
            e.ToString();
        }
    }
}
