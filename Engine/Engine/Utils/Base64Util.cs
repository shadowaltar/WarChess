namespace Engine.Utils;
public class Base64Util
{
    public static void ReadBase64IntoFile(string base64TextFilePath, string outputFilePath)
    {
        try
        {
            var content = File.ReadAllText(base64TextFilePath);
            var bytes = Convert.FromBase64String(content);
            File.WriteAllBytes(outputFilePath, bytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
