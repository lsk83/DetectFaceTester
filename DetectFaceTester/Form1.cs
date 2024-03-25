using OpenCvSharp;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace DetectFaceTester
{
    public partial class Form1 : Form
    {

        private Rect[] _faceRect;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var rect in _faceRect ?? Enumerable.Empty<Rect>())
            {
                Graphics g = e.Graphics;
                using var pen = new Pen(Color.Red, 2);
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }


        }

        private void txtTest_Click(object sender, EventArgs e)
        {
            try
            {                
                var eyeCascade     = new CascadeClassifier("haarcascade_eye.xml");
                var sourcFilePath  = txtImagePath.Text;

                if (!File.Exists("haarcascade_eye.xml"))
                    throw new Exception("얼굴인식에 필요한 haarcascade 데이터를 찾을 수 없습니다.");

                if (!File.Exists(sourcFilePath))
                    throw new Exception("작업할 이미지 소스가 없습니다.");

                using Mat image = Cv2.ImRead(sourcFilePath, ImreadModes.Color);
                pictureBox1.Image = Image.FromFile(sourcFilePath);
                _faceRect = eyeCascade.DetectMultiScale(image);

                var blurredImage = ApplyBlurToRegion(image, _faceRect,15);

                var dirPath      = Path.GetDirectoryName(sourcFilePath);
                var fileName     = Path.GetFileNameWithoutExtension(sourcFilePath);
                var ext          = Path.GetExtension(sourcFilePath);
                var destFilePath = @$"{dirPath}\\{fileName}_blured{ext}";
                Cv2.ImWrite(@$"{dirPath}\\{fileName}_blured{ext}", blurredImage);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = destFilePath;
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public Mat ApplyBlurToRegion(Mat image, Rect[] regions, int blurAmount)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            Mat result = image.Clone();

            foreach (Rect region in regions)
            {
                // 특정 영역에 대해 Blur 처리 수행
                Mat regionMat = result[region];
                Cv2.Blur(regionMat, regionMat, new OpenCvSharp.Size(blurAmount, blurAmount));
            }

            return result;
        }

        private Bitmap MatToBitmap(Mat mat)
        {
            using (var ms = mat.ToMemoryStream())
            {
                return (Bitmap)Image.FromStream(ms);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "파일 선택";
            dlg.Filter = "이미지 파일 (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            dlg.Multiselect = false; 

            if(dlg.ShowDialog() == DialogResult.OK)
                txtImagePath.Text = dlg.FileName;            
        }
    }
}
