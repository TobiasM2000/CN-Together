using QRCoder;
using System.Drawing.Imaging;


namespace CN_Together.Pages
{
    public partial class Index
    {
        private string QRCodeString = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            this.RoomManager.UpdateMessagesEvent += this.UpdateView;

            this.QRCodeString = this.GenerateQRString();
        }

        private string GenerateQRString()
        {
            using (var ms = new MemoryStream())
            {
                var uri = new Uri(this.NavigationManager.Uri);
                var generator = new PayloadGenerator.Url($"{uri.Scheme}://{uri.Authority}/login");
                var payload = generator.ToString();

                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);

                using (var oBitmap = qrCode.GetGraphic(20))
                {
                    oBitmap.Save(ms, ImageFormat.Png);
                    return "data:image/png;base64, " + Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private void ResetRoom()
        {
            this.RoomManager.ResetHints(Data.Enums.Team.Red);
        }

        public async void UpdateView()
        {
            await this.InvokeAsync(() => { this.StateHasChanged(); });
        }

    }
}
