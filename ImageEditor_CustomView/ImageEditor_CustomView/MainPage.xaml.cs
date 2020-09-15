using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;

namespace ImageEditor_CustomView
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            imageEditor.Source = ImageSource.FromResource("ImageEditor_CustomView.Buldingimage.jpeg", assembly);
            imageEditor.RotatableElements = ImageEditorElements.CustomView;
            var footerToolbarItem = new FooterToolbarItem() { Icon = ImageSource.FromResource("ImageEditor_CustomView.Icons.ITypogy3.png"), Text = "CustomView" };
            footerToolbarItem.SubItems = new ObservableCollection<Syncfusion.SfImageEditor.XForms.ToolbarItem>()
            {
                new Syncfusion.SfImageEditor.XForms.ToolbarItem() { Name = "CustomView1", Icon = ImageSource.FromResource("ImageEditor_CustomView.Icons.ITypogy1.png") ,Text="ITypogy1" },
                new Syncfusion.SfImageEditor.XForms.ToolbarItem() { Name = "CustomView2", Icon = ImageSource.FromResource("ImageEditor_CustomView.Icons.ITypogy2.png") ,Text="ITypogy2" }

            };
            imageEditor.ToolbarSettings.ToolbarItems.Add(footerToolbarItem);

            imageEditor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;

        }
        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            if (e.ToolbarItem.Name == "CustomView1")
            {
                AddCustomView(e.ToolbarItem.Text);
            }
            if (e.ToolbarItem.Name == "CustomView2")
            {
                AddCustomView(e.ToolbarItem.Text);
            }
        }

        private void AddCustomView(string imageName)
        {
            var sampleName = "ImageEditor_CustomView.Icons." + imageName + ".png";
            Image customImage = new Image();
            customImage.Source = ImageSource.FromResource(sampleName);
            imageEditor.AddCustomView(customImage, new CustomViewSettings() { Bounds = new Rectangle(0, 0, 25, 25), CanMaintainAspectRatio = true, Angle = 45 });
        }

    }
}
