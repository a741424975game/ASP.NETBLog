using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;//用于写加密解密算法
using System.Text.RegularExpressions;//同上

/// <summary>
/// EncodeDecode 加密解密算法
/// </summary>

public class EncodeDecode
{
    private static int key=123;
    public EncodeDecode()
    {

    }

    public static string Encode(string str)
    {
       StringBuilder strB = new StringBuilder();
        byte[] strBytes= Encoding.Unicode.GetBytes(str);
        for (int i = 0; i < strBytes.Length; i++)
			{
			    strBytes[i]=(byte)(strBytes[i]^key);
            strB.AppendFormat("{0:D3}",strBytes[i]);
			}
        string encodeStr=strB.ToString();
        return encodeStr;
    }

    public static string Decode(string str)
    {
        MatchCollection matches =Regex.Matches(str,@"\d{3}");
        byte[] strBytes =new byte[matches.Count];
        for (int i = 0; i < matches.Count; i++)
			{
			    strBytes[i]=(byte)(byte.Parse(matches[i].Value)^key);
			}
        string decodeStr=Encoding.Unicode.GetString(strBytes);
        return decodeStr;
    }
}
