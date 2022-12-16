using QRCoder;
using BarcodeLib;
using System.Drawing;

while (true)
{
    Console.WriteLine("QRCode, Barcode");
    switch (Console.ReadLine())
    {
        case "QRCode":
            {
                Console.WriteLine("Введите текст для кодирования");
                var text = Console.ReadLine();
                EncodeAsQRCode(text);
                break;
            }
        case "Barcode":
            {
                Console.WriteLine("Введите текст для кодирования");
                var text = Console.ReadLine();
                try
                {
                    EncodeAsBarcode(text);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    goto case "Barcode";
                }
                break;
            }
        default:
            break;
    }

}

void EncodeAsQRCode(string text)
{
    QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
    QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new QRCode(qrCodeData);
    Bitmap qrCodeImage = qrCode.GetGraphic(20);
    qrCodeImage.Save("QRCode.jpg");
}

void EncodeAsBarcode(string text)
{
    Barcode barcode = new Barcode();
    barcode.Encode(TYPE.EAN13, text);
    barcode.SaveImage("Barcode.jpg", SaveTypes.JPG);
}