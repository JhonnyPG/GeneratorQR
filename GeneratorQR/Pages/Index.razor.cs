using MudBlazor;
using QRCoder;

namespace GeneratorQR.Pages
{
    public partial class Index
    {
        MudForm urlSubtimForm;
        public string submittedUrl { get; set; }
        public string QRCodeText { get; set; }

        private async Task submitUrl()
        {
            await urlSubtimForm.Validate();
            if(urlSubtimForm.IsValid)
                GenerateQRCode();
        }

        protected void GenerateQRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(submittedUrl, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qRCodeData);
            byte[] qrCodeAsByteArr = qrCode.GetGraphic(20);

            var ms = new MemoryStream(qrCodeAsByteArr);

            QRCodeText = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            submittedUrl = String.Empty;




        }
    }
}
