using System;

// README.md를 읽고 아래에 코드를 작성하세요.
string[] allowedExtensions = { ".txt", ".csv" };
Console.WriteLine("=== 경로 검증 테스트 ===");
try
{
    FilePathValidator.ValidatePath("C:/Users/data/report.txt");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}



try
{
    FilePathValidator.ValidatePath("");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}


try
{
    FilePathValidator.ValidatePath("***");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}


Console.WriteLine("\n=== 확장자 검증 테스트 ===");
try
{
    FilePathValidator.ValidateExtension(".txt", allowedExtensions);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}


try
{
    FilePathValidator.ValidateExtension(".csv", allowedExtensions);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}


try
{
    FilePathValidator.ValidateExtension(".exe", allowedExtensions);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}
