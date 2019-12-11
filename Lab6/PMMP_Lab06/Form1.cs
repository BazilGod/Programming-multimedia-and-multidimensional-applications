using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;

//DiresctShow
using DirectShowLib;
using Emgu.CV.Dpm;

namespace PMMP_Lab06
{
    public partial class Form1 : Form
    {
        #region Variables
        #region Camera Capture Variables
        private Emgu.CV.VideoCapture _capture = null; //Camera
        private bool _captureInProgress = false; //Variable to track camera state
        int CameraDevice = 0; //Variable to track camera device selected
        VideoDevice[] WebCams; //List containing all the camera available
        #endregion
        #region Camera Settings
        int Brightness_Store = 0;
        int Contrast_Store = 0;
        int Sharpness_Store = 0;

        CascadeClassifier faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
        //for eye
        CascadeClassifier eyeCascade = new CascadeClassifier("haarcascade_eye.xml");

        CascadeClassifier bodyCascade = new CascadeClassifier("haarcascade_fullbody.xml");
        #endregion
        #endregion
        public Form1()
        {
            InitializeComponent();
            Slider_Enable(false);

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new VideoDevice[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new VideoDevice(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID);
                Camera_Selection.Items.Add(WebCams[i].ToString());
            }
            if (Camera_Selection.Items.Count > 0)
            {
                Camera_Selection.SelectedIndex = 0;
                captureButton.Enabled = true;
            }
        }


        private void Slider_Enable(bool State)
        {
            /*Brigtness_SLD.Enabled = State;
            Contrast_SLD.Enabled = State;
            Sharpness_SLD.Enabled = State;*/
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    captureButton.Text = "Start Capture"; 
                    Slider_Enable(false);
                    _capture.Pause();
                    _captureInProgress = false;
                }
                else
                {
                    captureButton.Text = "Stop"; 
                    Slider_Enable(true);
                    _capture.Start();
                    _captureInProgress = true;
                }

            }
            else
            {
                SetupCapture(Camera_Selection.SelectedIndex);
                CaptureButton_Click(null, null);
            }
        }
        private void SetupCapture(int Camera_Identifier)
        {
            CameraDevice = Camera_Identifier;
            if (_capture != null) _capture.Dispose();
            try
            {
                _capture = new VideoCapture(CameraDevice);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            Mat frame1 = new Mat();
            _capture.Retrieve(frame);
            _capture.Retrieve(frame1);
            if (RetrieveBgrFrame.Checked)
            {
                var imageToDisplay = frame.ToImage<Bgr, byte>();
                var faces = faceCascade.DetectMultiScale(frame.ToImage<Gray, byte>(), 1.1, 10, Size.Empty); //the actual face detection happens here

                foreach (var face in faces)
                {
                    imageToDisplay.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                }

                var eyes = eyeCascade.DetectMultiScale(frame.ToImage<Gray, byte>(), 1.1, 10, Size.Empty); //the actual eye detection happens here

                foreach (var eye in eyes)
                {
                    imageToDisplay.Draw(eye, new Bgr(Color.AliceBlue), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                }

                var des = new HOGDescriptor();
                des.SetSVMDetector(HOGDescriptor.GetDefaultPeopleDetector());

                foreach (var pedestrain in des.DetectMultiScale(imageToDisplay, 0, new Size(8, 8), new Size(0, 0)).AsEnumerable())
                {
                    imageToDisplay.Draw(pedestrain.Rect, new Bgr(Color.Red), 1);
                }

                DisplayImage(imageToDisplay.ToBitmap());
            }
        }

        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (captureBox.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                captureBox.Image = Image;
            }
        }
    }
}
