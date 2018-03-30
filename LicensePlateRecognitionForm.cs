//----------------------------------------------------------------------------
//  Copyright (C) 2004-2018 by EMGU Corporation. All rights reserved.
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

using System.Diagnostics;
using Emgu.CV.Util;
using System.Text.RegularExpressions;
using System.IO;
using LicensePlateRecognition.Utils;
using System.Linq;
using LicensePlateRecognition.OCR_Method;

namespace LicensePlateRecognition
{
    public partial class LicensePlateRecognitionForm : Form
    {
        private LicensePlateDetector _licensePlateDetector;
        private Mat img;

        public LicensePlateRecognitionForm()
        {
            InitializeComponent();
            _licensePlateDetector = new LicensePlateDetector("x64/");
            //Mat m = new Mat("license-plate.jpg");
            //UMat um = m.GetUMat(AccessType.ReadWrite);
            //imageBox1.Image = um;
            //ProcessImage(m);
        }

        private bool ProcessImage(IInputOutputArray image, int ocr_mode, int count)
        {
            Stopwatch watch = Stopwatch.StartNew(); // time the detection process
            List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
            List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
            List<RotatedRect> licenseBoxList = new List<RotatedRect>();
            List<string> words = new List<string>();
            var result = false;
            bool validValue = false;
            if (count != 3)
            {
                words = _licensePlateDetector.DetectLicensePlate(
                image,
                licensePlateImagesList,
                filteredLicensePlateImagesList,
                licenseBoxList,
                ocr_mode);
            }
            else
            {
                UMat filteredPlate = new UMat();
                StringBuilder strBuilder = new StringBuilder();
                CvInvoke.CvtColor(img, filteredPlate, ColorConversion.Bgr2Gray);
                strBuilder = ComputerVisionOCR.GetText(filteredPlate);

                if (strBuilder != null)
                {
                    List<String> licenses = new List<String>
                    {
                        strBuilder.ToString()
                    };
                    licenses.ForEach(
                        x =>
                        {
                            words.Add(x);
                        });
                }
            }

            words.ForEach(w =>
            {
                string replacement2 = Regex.Replace(w, @"\t|\n|\r", "");
                string replacement = Regex.Replace(replacement2, "[^0-9a-zA-Z]+", "");
                if (replacement.Length >= 6 && replacement.Length <= 8 && replacement != null && FilterLicenceSpain(replacement))
                {
                    validValue = true;
                }
            });

            if (validValue || count == 5 || ocr_mode == 3)
            {
                ShowResults(image, watch, licensePlateImagesList, filteredLicensePlateImagesList, licenseBoxList, words, count);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Check if the license has a valid value
        /// </summary>
        /// <param name="replacement"></param>
        /// <returns></returns>
        private bool FilterLicenceSpain(string replacement)
        {
            var result = false;
            int countInterger = 0;
            int countChar = 0;
            var charList = replacement.ToCharArray();
            foreach (var character in charList)
            {
                try
                {
                    int.Parse(character.ToString());
                    countInterger++;
                }
                catch (Exception)
                {
                    countChar++;
                }
            }

            if (countInterger >= 3 && countChar >= 2)
            {
                result = true;
            }

            return result;
        }

        private void ShowResults(IInputOutputArray image, Stopwatch watch, List<IInputOutputArray> licensePlateImagesList, List<IInputOutputArray> filteredLicensePlateImagesList, List<RotatedRect> licenseBoxList, List<string> words, int count)
        {
            watch.Stop(); //stop the timer
            processTimeLabel.Text = String.Format("License Plate Recognition time: {0} milli-seconds \nIteration number = {1}", watch.Elapsed.TotalMilliseconds, count);

            panel1.Controls.Clear();
            Point startPoint = new Point(10, 10);
            for (int i = 0; i < words.Count; i++)
            {
                Mat dest = new Mat();
                CvInvoke.VConcat(licensePlateImagesList[i], filteredLicensePlateImagesList[i], dest);
                string replacement2 = Regex.Replace(words[i], @"\t|\n|\r", "");
                string replacement = Regex.Replace(replacement2, "[^0-9a-zA-Z]+", "");
                AddLabelAndImage(
                   ref startPoint,
                   String.Format("License: {0}", replacement),
                   dest);
                PointF[] verticesF = licenseBoxList[i].GetVertices();
                Point[] vertices = Array.ConvertAll(verticesF, Point.Round);
                using (VectorOfPoint pts = new VectorOfPoint(vertices))
                    CvInvoke.Polylines(image, pts, true, new Bgr(Color.Red).MCvScalar, 2);
            }
        }

        private void AddLabelAndImage(ref Point startPoint, String labelText, IImage image)
        {
            Label label = new Label();
            panel1.Controls.Add(label);
            label.Text = labelText;
            label.Width = 100;
            label.Height = 30;
            label.Location = startPoint;
            startPoint.Y += label.Height;

            ImageBox box = new ImageBox();
            panel1.Controls.Add(box);
            box.ClientSize = image.Size;
            box.Image = image;
            box.Location = startPoint;
            startPoint.Y += box.Height + 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///Clear multiple image 
            inputTextBox.Text = "";
            MyGlobal.imageClassList.Clear();
            MyGlobal.imageList.Clear();

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    img = CvInvoke.Imread(openFileDialog1.FileName);
                    imageBox1.Image = img;
                    textBox1.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show(String.Format("Invalide File: {0}", openFileDialog1.FileName));
                    return;
                }

                //UMat uImg = img.GetUMat(AccessType.ReadWrite);
                //ProcessImage(uImg);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TesseractBtn_Click_1(object sender, EventArgs e)
        {
            //CheckInputType();
            UMat uImg = img.GetUMat(AccessType.ReadWrite);
            ProcessImageMethod(uImg, 1);

        }

        private void CheckInputType()
        {
            if (textBox1.Text.Length == 0)
            {
                int.TryParse(indiceB.Text, out int value);
                var root = SetImageDescription(value);
                CheckLicenceDataBase(value);
                img = CvInvoke.Imread(root);
            }
        }

        private void ProcessImageMethod(UMat uImg, int ocr_Method)
        {
            for (int count = 1; count <= 5; count++)
            {
                if (ProcessImage(uImg, ocr_Method, count))
                {
                    break;
                }
            }
        }

        private void GoogleBtn_Click(object sender, EventArgs e)
        {
            CheckInputType();
            UMat uImg = img.GetUMat(AccessType.ReadWrite);
            ProcessImageMethod(uImg, 2);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            imageBox1.Image = img;
        }

        private void CVisionButton_Click(object sender, EventArgs e)
        {
            CheckInputType();
            UMat uImg = img.GetUMat(AccessType.ReadWrite);
            ProcessImageMethod(uImg, 3);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var value = default(int);
            int.TryParse(indiceB.Text, out value);
            var x = SetImageDescription(value);

            NextImage();

            DeleteLicenceDataBase(value);
            File.Delete(x);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //remove one image texbox text
            textBox1.Text = "";
            inputTextBox.Text = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    inputB.Text = fbd.SelectedPath;
                    string[] files = Directory.GetFiles(inputB.Text);
                    var count = 0;
                    foreach (var file in files)
                    {
                        var split = inputB.Text.Split(new string[] { "\\" }, StringSplitOptions.None);
                        var ini = split[split.Length - 1];
                        var fileText = file.Substring(file.IndexOf(ini) + ini.Length + 1, file.Length - file.IndexOf(ini) - ini.Length - 1);
                        inputTextBox.Text += fileText + "\r\n";

                        ImageStructure imageStructure = GetImageStructure(count, fileText);
                        MyGlobal.imageClassList.Add(imageStructure);
                        count++;
                    }

                    if (MyGlobal.imageClassList.Count != 0)
                    {
                        SetImageDescription(0);
                        CheckLicenceDataBase(0);
                    }
                }
            }
        }

        public static class MyGlobal
        {
            public static List<string> imageList = new List<string>();

            public static List<ImageStructure> imageClassList = new List<ImageStructure>();
        }

        private static ImageStructure GetImageStructure(int count, string fileText)
        {
            return new ImageStructure
            {
                Id = count,
                ImageName = fileText
            };
        }
        private string SetImageDescription(int indexImage)
        {
            var first = MyGlobal.imageClassList[indexImage];
            var index = first.ImageName.IndexOf(".");
            var name = first.ImageName.Substring(0, index);
            var extension = first.ImageName.Substring(index + 1, first.ImageName.Length - index - 1);
            nameB.Text = "";
            indiceB.Text = first.Id.ToString();
            var result = inputB.Text + "\\" + first.ImageName;
            imageBox1.Load(result);
            imageBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            return result;
        }

        public void CheckLicenceDataBase(int index)
        {
            var first = MyGlobal.imageClassList[index];
            try
            {
                using (var context = new ImageDataBaseEntities())
                {
                    IQueryable<ImagesLicence> imageSelected = GetImageDetails(first, context);
                    if (imageSelected.Any())
                    {
                        nameB.Text = imageSelected.FirstOrDefault().carLicence;
                    }
                }
            }
            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        public void DeleteLicenceDataBase(int index)
        {
            var first = MyGlobal.imageClassList[index];
            try
            {
                using (var context = new ImageDataBaseEntities())
                {
                    IQueryable<ImagesLicence> imageSelected = GetImageDetails(first, context);
                    if (imageSelected.Any())
                    {
                        context.ImagesLicences.Remove(imageSelected.FirstOrDefault());
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        private static IQueryable<ImagesLicence> GetImageDetails(ImageStructure first, ImageDataBaseEntities context)
        {
            return from img in context.ImagesLicences
                   where img.name == first.ImageName
                   select img;
        }

        private static IQueryable<ImagesLicence> GetImageDetails(string name, ImageDataBaseEntities context)
        {
            return from img in context.ImagesLicences
                   where img.name == name
                   select img;
        }

        private void beforeB_Click(object sender, EventArgs e)
        {
            if (indiceB.Text.Length > 0 && indiceB.Text != String.Empty && indiceB.Text != "0")
            {
                try
                {
                    var value = default(int);
                    int.TryParse(indiceB.Text, out value);
                    if (value != 0)
                    {
                        value--;
                        SetImageDescription(value);
                        var root = SetImageDescription(value);
                        img = CvInvoke.Imread(root);
                        CheckLicenceDataBase(value);
                    }
                }
                catch (Exception)
                { }
            }
        }

        private void nextB_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void NextImage()
        {
            if (indiceB.Text.Length > 0 && indiceB.Text != String.Empty)
            {
                try
                {
                    var value = default(int);
                    int.TryParse(indiceB.Text, out value);

                    value++;
                    var root = SetImageDescription(value);
                    img = CvInvoke.Imread(root);
                    CheckLicenceDataBase(value);
                }
                catch (Exception)
                { }
            }
        }

        private void SaveDbButton_Click(object sender, EventArgs e)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                //String str = "Data Source=ESBA9336;Initial Catalog=ImageDataBase;Persist Security Info=True;User ID=sa;Password=Sunshine123";

                //SqlConnection con = new SqlConnection(str);

                var imageDto = new ImagesLicence
                {
                    dateAdded = DateTime.Now,
                    active = true,
                    carLicence = nameB.Text,
                    localRoute = inputB.Text,
                    name = MyGlobal.imageClassList[int.Parse(indiceB.Text)].ImageName
                };



                using (var context = new ImageDataBaseEntities())
                {
                    IQueryable<ImagesLicence> imageSelected = GetImageDetails(imageDto.name, context);
                    if (imageSelected.Any())
                    {
                        imageSelected.FirstOrDefault().carLicence = nameB.Text;
                    }
                    else
                    {
                        context.ImagesLicences.Add(imageDto);
                    }

                    context.SaveChanges();
                    logger.Trace("New car licence saved name: {0}, car licence: {1}", imageDto.name, imageDto.carLicence);
                }

            }
            catch (Exception es)

            {
                MessageBox.Show(es.Message);
            }
        }

        private void indiceB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (indiceB.Text.Length > 0 && indiceB.Text != String.Empty)
                {
                    try
                    {
                        var value = default(int);
                        int.TryParse(indiceB.Text, out value);
                        if (value != 0)
                        {
                            var root = SetImageDescription(value);
                            img = CvInvoke.Imread(root);
                            CheckLicenceDataBase(value);
                        }
                    }
                    catch (Exception)
                    { }
                }
            }
        }
    }
}