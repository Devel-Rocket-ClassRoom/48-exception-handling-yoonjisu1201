using System;
using System.Collections.Generic;
using System.Text;

class FilePathValidator
{
    public static void ValidatePath(string path) //경로 검증
    {
        var array = path.ToCharArray();
        bool isInclud = false;
        char isInclud_char = default;
        for (int i = 0; i < array.Length; i++)
        {
            switch (array[i])
            {
                case '<':
                case '>':
                case '|':
                case '"':
                case '*':
                case '?':
                    isInclud = true;
                    isInclud_char = array[i];
                    break;
            }
        }
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException("경로는 null이거나 비어있을 수 없습니다.");
        }
        else if (path.Length > 260)
        {
            throw new ArgumentOutOfRangeException("경로 길이가 260자를 초과합니다.");
        }
        else if (isInclud)    // 금지문자 포함
        {
            throw new ArgumentException($"경로에 금지 문자 '{isInclud_char}'가 포함되어 있습니다.");
        }
        else
        {
            Console.WriteLine($"경로가 유효합니다: {path}");
        }
    }

    public static void ValidateExtension(string extension, string[] allowedExtensions)  //확장자 검증
    {
        string[] allowed = allowedExtensions;
        bool isallowed = false;
        for (int i = 0; i < allowed.Length; i++)
        {
            if (allowed[i] == extension)
            {
                isallowed = true;
            }
        }

        if (isallowed == false)
        {
            throw new ArgumentException($"허용되지 않은 확장자입니다: {extension}");
        }
        else
        {
            Console.WriteLine($"확장자가 유효합니다: {extension}");
        }

    }
}